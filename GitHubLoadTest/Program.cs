using System;
using System.Collections.Generic;

namespace GitHubLoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                Console.WriteLine("Start Generating Load");
                //await RunTest();
                Console.WriteLine("Completed.");
            });
        }
        public async System.Threading.Tasks.Task RunTest()
        {
            int MAX_ITERATIONS = 500;
            int MAX_PARALLEL_REQUESTS = 500;
            int DELAY = 100;

            // Collection of Url's to test. Change to your valid Url's.
            string[] urls = new string[] { "https://hostname.azurewebsites.net/api/datatest", "https://hostname.azurewebsites.net/api/datatest/add" };

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                // To add any headers like Bearer Token, Media Type etc.
                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.xxxxxx");

                for (var step = 1; step < MAX_ITERATIONS; step++)
                {
                    Console.WriteLine($"Started iteration: {step}");
                    var tasks = new List<System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>();
                    for (int i = 0; i < MAX_PARALLEL_REQUESTS; i++)
                    {
                        tasks.Add(httpClient.PostAsync(urls[i % 2], null));
                    }
                    // Run all 300 tasks in parallel
                    var result = await System.Threading.Tasks.Task.WhenAll(tasks);
                    Console.WriteLine($"Completed Iteration: {step}");

                    // Some delay before new iteration
                    await System.Threading.Tasks.Task.Delay(DELAY);
                }
            }
        }
    }
}
