using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace GoSpaceAIGitHubTest.APITesting.LoadTesting
{
    public class LoadTesting
    {
        [Test]
        public void LoadTest()
        {
            Task.WaitAll(ExecuteLoadTestAsync());
        }
        public static async Task ExecuteLoadTestAsync()
        {
            //Should take 1 minute.
            int MAX_ITERATIONS = 10;
            int MAX_PARALLEL_REQUESTS = 200;
            int DELAY = 100;

            int totalPasses = 0;
            int totalFails = 0;


            using (var httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", "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");
                for (var step = 1; step < MAX_ITERATIONS; step++)
                {
                    int iterationPass = 0;
                    int iterationFails = 0;
                    Console.WriteLine($"Started iteration: {step}");
                    var tasks = new List<Task<System.Net.Http.HttpResponseMessage>>();
                    for (int i = 0; i < MAX_PARALLEL_REQUESTS; i++)
                    {
                        tasks.Add(httpClient.GetAsync("https://api.github.com/users/gospaceaiinterview/repos"));
                    }
                    // Run all tasks in parallel
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    var result = await Task.WhenAll(tasks);
                    Console.WriteLine($"Completed Iteration: {step}");

                    timer.Stop();
                    TimeSpan timeTaken = timer.Elapsed;
                    Console.WriteLine("Time taken:" + timeTaken.TotalSeconds);

                    await Task.Delay(DELAY);
                    foreach (var res in tasks)
                    {
                        if (res.Result.IsSuccessStatusCode)
                        {
                            iterationPass++;
                        }
                        else
                        {
                            iterationFails++;
                        }
                    }
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Passes:" + iterationPass);
                    Console.WriteLine("Fails:" + iterationFails);
                    totalPasses += iterationPass;
                    totalFails += iterationFails;
                }
            }
            Console.WriteLine("========================================");
            Console.WriteLine("Total Run Passes:" + totalPasses);
            Console.WriteLine("Total Run Fails:" + totalFails);
            Console.WriteLine("========================================");
        }
    }
}
