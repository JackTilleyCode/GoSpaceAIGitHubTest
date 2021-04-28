using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections.Specialized;
using Octokit;
using System.Net.Http.Headers;

namespace GoSpaceAIGitHubTest.APITesting.StepDefinitions
{
    [Binding]
    public class GitHubSteps
    {
        static List<MyArray> repoList;
        static HttpClient client;
        static HttpResponseMessage response;
        static string PAT = "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";
        static string repoName = "PleaseHireMe";
        static Octokit.Repository newRepository;
        static GitHubClient gitClient;
        
        [Given(@"Authenticated")]
        public void GivenAuthenticated()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");

            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", PAT);
        }
        [When(@"Send request to get repos")]
        public void WhenSendRequestToGetRepos()
        {
            Task.WaitAll(ExecuteGetReposAsync());
        }


        [Then(@"Repositories should be listed")]
        public void ThenRequestShouldReturnAListOfRepositories()
        {
            Assert.IsNotEmpty(repoList[0].full_name);
        }

        public static async Task ExecuteGetReposAsync()
        {
            var response = await client.GetStringAsync("/users/gospaceaiinterview/repos");

            repoList = JsonConvert.DeserializeObject<List<MyArray>>(response);
        }

        public static async Task ExecuteDeleteRepoAsync()
        {
            response = await client.DeleteAsync("/repos/gospaceaiinterview/"+repoName);
        }

        //Should have a standardized authentication for each test.
        //Octokit was used as a workaround
        public static async Task ExecuteCreateRepoAsync()
        {
            try
            {
                var repository = new NewRepository(repoName)
                {
                    AutoInit = false,
                    Description = "",
                    LicenseTemplate = "mit",
                    Private = false
                };
                newRepository =  await gitClient.Repository.Create(repository);
                Console.WriteLine($"The respository {repoName} was created.");
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"E: For some reason, the repository {repoName}  can't be created. It may already exist. {e.Message}");
            }

        }
        [Given(@"Authenticated using octokit")]
        public void GivenAuthenticatedUsingOctokit()
        {
            var basicAuth = new Credentials(PAT);
            gitClient = new GitHubClient(new Octokit.ProductHeaderValue("my-cool-app"));
            gitClient.Credentials = basicAuth;
        }

        [When(@"Send request to delete repo")]
        public void WhenSendRequestToDeleteRepo()
        {
            Task.WaitAll(ExecuteDeleteRepoAsync());
        }

        [Then(@"Repo should be deleted")]
        public void ThenRepoShouldBeDeleted()
        {
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
        [Then(@"New repo should exist")]
        public void ThenNewRepoShouldExist()
        {
            Assert.IsTrue(isContainingNewRepo());
        }
        bool isContainingNewRepo()
        {
            foreach (var repo in repoList)
            {
                if (repo.full_name.Contains(repoName))
                {
                    return true;
                }
            }
            
            return false;
           
        }
        [When(@"Send request to create repo")]
        public void WhenSendRequestToCreateRepo()
        {
            Task.WaitAll(ExecuteCreateRepoAsync());
        }

        [Then(@"Repo should be created")]
        public void ThenRepoShouldBeCreated()
        {
            Assert.IsTrue(newRepository.Name.Contains(repoName));
        }

        [AfterScenario]
        public void Dispose()
        {
            client = null;
            gitClient = null;
            newRepository = null;
        }

        public class Repository
        {
            public string name;
        }

        public class Owner
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Permissions
        {
            public bool admin { get; set; }
            public bool push { get; set; }
            public bool pull { get; set; }
        }

        public class MyArray
        {
            public int id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }
            public bool @private { get; set; }
            public Owner owner { get; set; }
            public string html_url { get; set; }
            public object description { get; set; }
            public bool fork { get; set; }
            public string url { get; set; }
            public string forks_url { get; set; }
            public string keys_url { get; set; }
            public string collaborators_url { get; set; }
            public string teams_url { get; set; }
            public string hooks_url { get; set; }
            public string issue_events_url { get; set; }
            public string events_url { get; set; }
            public string assignees_url { get; set; }
            public string branches_url { get; set; }
            public string tags_url { get; set; }
            public string blobs_url { get; set; }
            public string git_tags_url { get; set; }
            public string git_refs_url { get; set; }
            public string trees_url { get; set; }
            public string statuses_url { get; set; }
            public string languages_url { get; set; }
            public string stargazers_url { get; set; }
            public string contributors_url { get; set; }
            public string subscribers_url { get; set; }
            public string subscription_url { get; set; }
            public string commits_url { get; set; }
            public string git_commits_url { get; set; }
            public string comments_url { get; set; }
            public string issue_comment_url { get; set; }
            public string contents_url { get; set; }
            public string compare_url { get; set; }
            public string merges_url { get; set; }
            public string archive_url { get; set; }
            public string downloads_url { get; set; }
            public string issues_url { get; set; }
            public string pulls_url { get; set; }
            public string milestones_url { get; set; }
            public string notifications_url { get; set; }
            public string labels_url { get; set; }
            public string releases_url { get; set; }
            public string deployments_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime pushed_at { get; set; }
            public string git_url { get; set; }
            public string ssh_url { get; set; }
            public string clone_url { get; set; }
            public string svn_url { get; set; }
            public object homepage { get; set; }
            public int size { get; set; }
            public int stargazers_count { get; set; }
            public int watchers_count { get; set; }
            public object language { get; set; }
            public bool has_issues { get; set; }
            public bool has_projects { get; set; }
            public bool has_downloads { get; set; }
            public bool has_wiki { get; set; }
            public bool has_pages { get; set; }
            public int forks_count { get; set; }
            public object mirror_url { get; set; }
            public bool archived { get; set; }
            public bool disabled { get; set; }
            public int open_issues_count { get; set; }
            public object license { get; set; }
            public int forks { get; set; }
            public int open_issues { get; set; }
            public int watchers { get; set; }
            public string default_branch { get; set; }
            public Permissions permissions { get; set; }
        }
    }
}
