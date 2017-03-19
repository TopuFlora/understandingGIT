using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Azure
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
        public int LL { get; set; }
        public int Abar { get; set; }
        public string amiocalak { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }
        static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"Student ID", "Gender", "Faculty", "H.S.C", "S.S.C (GPA)", "H.S.C (GPA)", "Did you ever attend a Coaching center?", "1st Year Semester 1", "1st Year Semester 2", "1st Year Semester 3", "2nd Year Semester 1", "2nd Year Semester 2", "2nd Year Semester 3", "3rd Year Semester 1", "3rd Year Semester 2", "3rd Year Semester 3"},
                                Values = new string[,] {  { "0", "value", "value", "value", "0", "0", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  { "0", "value", "value", "value", "0", "0", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "+IQ0nCN13nNxgszIYN+cuyC1HaD1C8+5P90lPRMRzxJttOCLP3MR9Y6ztCq+rFkkhZPMmfdED3iHrDRccMQCWg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/891285f9f40b45f793345ab13678b7b2/services/7171b002c92b47b4a6f618e391ac0dff/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }
    }
}
