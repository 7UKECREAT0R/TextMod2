using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Variables;

namespace TextMod_2.Core
{
    /// <summary>
    /// Loads, compiles, and holds scripts.
    /// </summary>
    public class ScriptManager
    {
        public string[] scriptDirectory { get; private set; }
        public Script[] scripts { get; private set; }

        public ScriptManager() {}
        public void LoadScriptFiles(string directory)
        {
            scriptDirectory = Directory.GetFiles(directory, "*.cs", SearchOption.AllDirectories);
            scripts = scriptDirectory.Select(file => new Script(file)).ToArray();
            Debug.WriteLine("Loaded " + scriptDirectory.Length + " script(s) from the scripts directory.");
        }
        public void CompileScripts()
        {
            if (scriptDirectory == null || scriptDirectory.Length < 1)
                return;
            if (scripts == null || scripts.Length < 1)
                return;

            for (int i = 0; i < scripts.Length; i++)
            {
                Script script = scripts[i];
                script.Compile();
            }
        }

        /// <summary>
        /// Look through all compiled scripts and 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>If a command was run.</returns>
        public bool TryExecuteCommand(string input)
        {
            if (scripts == null || scripts.Length < 1)
                return false;

            if (input == null) return false;
            if (input.Length < 0) return false;
            input = input.TrimStart(TextModCore.PREFIX);
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 1) return false;

            string keyword = words[0].ToUpper();
            foreach (Script script in scripts)
            {
                if (!script.IsValidCompilation)
                    continue;
                foreach (Command command in script.compiledCommands)
                {
                    if(command.DictName.Equals(keyword))
                    {
                        string text;
                        int subLength = command.Name.Length + 1;
                        text = (input.Length > subLength) ? input.Substring(subLength) : null;
                        string output = command.Run(text);
                        ApplicationHook.SendMessage(output);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Similar to a command, however it is able
    ///  to be compiled and created dynamically.
    /// </summary>
    public class Script
    {
        public static readonly Assembly[] ASSEMBLIES = new List<Assembly> {
                typeof(object).GetTypeInfo().Assembly,
                typeof(Console).GetTypeInfo().Assembly,
                typeof(Enumerable).GetTypeInfo().Assembly,
                typeof(File).GetTypeInfo().Assembly,
                typeof(Assembly).GetTypeInfo().Assembly,
                typeof(CSharpArgumentInfo).GetTypeInfo().Assembly,
                typeof(CSharpSyntaxTree).GetTypeInfo().Assembly,
                typeof(System.Dynamic.CallInfo).GetTypeInfo().Assembly,
                typeof(RuntimeBinderException).GetTypeInfo().Assembly,
                typeof(System.Dynamic.ConvertBinder).GetTypeInfo().Assembly,
                typeof(System.Linq.Expressions.ExpressionType).GetTypeInfo().Assembly,
                typeof(MessageBox).GetTypeInfo().Assembly,
                typeof(Command).GetTypeInfo().Assembly,
                typeof(System.Security.CodeAccessPermission).GetTypeInfo().Assembly
        }.Distinct().ToArray();
        public static readonly PortableExecutableReference[] REFERENCES =
            ASSEMBLIES.Select(asm => MetadataReference.CreateFromFile(asm.Location)).ToArray();
        public static readonly CSharpCompilationOptions COMPILE_OPTIONS =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
            allowUnsafe: false, optimizationLevel: OptimizationLevel.Release, platform: Platform.AnyCpu);
        public static readonly Regex NAMESPACE = new Regex("namespace ", RegexOptions.Singleline);

        public readonly string fileName;
        public string code;
        internal bool compiled = false;
        internal SyntaxTree compiledTree = null;
        internal Command[] compiledCommands = null;
        internal RichPresenceVariable[] compiledVariables = null;

        internal byte[] assemblyData = null;
        internal Assembly compiledAssembly = null;

        /// <summary>
        /// Whether this script was successfully compiled.
        /// </summary>
        public bool IsValidCompilation
        {
            get
            {
                return compiled && compiledCommands != null && compiledAssembly != null && compiledTree != null;
            }
        }
        /// <summary>
        /// Read a .cs file and load it into this script (uncompiled).
        /// </summary>
        /// <param name="path"></param>
        public Script(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Couldn't locate script file.");
            code = File.ReadAllText(path);
            fileName = Path.GetFileName(path);
        }
        /// <summary>
        /// Attempt to compile and find the commands in this source file.
        /// </summary>
        public void Compile()
        {
            if (compiled)
            {
                MessageBox.Show("error: idk why its tryna compile this script again (" + fileName + ")");
                return;
            }

            compiledTree = CSharpSyntaxTree.ParseText(code);
            CSharpCompilation compilation = CSharpCompilation.Create(
                Path.GetFileNameWithoutExtension(fileName) + "_dynamic", new[]
                { compiledTree }, REFERENCES, COMPILE_OPTIONS);

            using (MemoryStream stream = new MemoryStream())
            {
                EmitResult compileResult = compilation.Emit(stream);
                if (!compileResult.Success)
                {
                    IEnumerable<Diagnostic> failures = compileResult.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);
                    string errors = string.Join("\n", failures.Select(d => "Line " + (d.Location
                        .GetLineSpan().StartLinePosition.Line + 1) + ": " + d.GetMessage()));
                    MessageBox.Show("Compile error(s) have occurred in " + fileName + "\n\n" + errors);
                    return;
                }

                Type command = typeof(Command);
                Type variable = typeof(RichPresenceVariable);
                // copy the memory to an array since the memorystream will be disposed.
                compiledAssembly = Assembly.Load(stream.ToArray());
                Type[] allTypes = compiledAssembly.GetTypes();
                var commandTypes = allTypes.Where(t => t.IsSubclassOf(command) && !t.IsAbstract);
                int commandCount = commandTypes.Count();
                var variableTypes = allTypes.Where(t => t.IsSubclassOf(variable) && !t.IsAbstract);
                int variableCount = variableTypes.Count();

                if (commandCount > 0)
                {
                    int i = 0;
                    compiledCommands = new Command[commandCount];
                    foreach (Type commandType in commandTypes)
                    {
                        Command cmd = (Command)Activator
                            .CreateInstance(commandType);
                        compiledCommands[i++] = cmd;
                    }
                    compiled = true;
                }
                if(variableCount > 0)
                {
                    int i = 0;
                    compiledVariables = new RichPresenceVariable[variableCount];
                    foreach (Type varType in variableTypes)
                    {
                        RichPresenceVariable rpv = (RichPresenceVariable)Activator
                            .CreateInstance(varType);
                        compiledVariables[i++] = rpv;
                    }
                    compiled = true;
                }
            }
        }
    }
}
