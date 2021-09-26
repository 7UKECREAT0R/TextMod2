using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Core
{
    /// <summary>
    /// Updates TextMod.
    /// </summary>
    public class Updater
    {
        public const long REPOSITORY_ID = 401384500;

        GitHubClient client;
        IReadOnlyList<Release> releases;

        public Updater()
        {
            client = new GitHubClient(new ProductHeaderValue("TextMod2"));
        }

        public void FetchReleases()
        {
            releases = client.Repository.Release.GetAll(REPOSITORY_ID).Result;
        }

        public Release LatestRelease
        {
            get
            {
                return releases[0];
            }
        }
        public int LatestReleaseID
        {
            get
            {
                return int.Parse(LatestRelease.TagName.Split('-')[1]);
            }
        }
        public string LatestReleaseURL
        {
            get
            {
                return "https://github.com/7UKECREAT0R/TextMod2/releases/download/" + LatestRelease.TagName + "/TextMod.2.zip";
            }
        }
        public bool IsOnLatest
        {
            get
            {
                return Program.CurrentVersion >= LatestReleaseID;
            }
        }
    }
}
