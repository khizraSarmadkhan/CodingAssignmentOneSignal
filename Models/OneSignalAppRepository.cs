using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace coding_assignment_onesignal.Models
{
    public class OneSignalAppRepository : IOneSignalAppRepository
    {
        public async Task CreateApp(string newAppName)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://onesignal.com/api/v1/apps"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic NWVjZTJhMmItMjBkMy00MjJjLThkNGEtNmM4OGM3Yzk5YzAy");

                    request.Content = new StringContent("{\"name\" : \"" + newAppName + "\",\n\"apns_env\": \"production\",\n\"apns_p12\": \"asdsadcvawe223cwef...\",\n\"apns_p12_password\": \"FooBar\",\n\"organization_id\": \"your_organization_id\",\n\"gcm_key\": \"a gcm push key\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        public void DeleteApp(string appId)
        {
            OneSignalAppsViewModel app = GetAppById(appId);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://onesignal.com/api/v1/apps/" + appId);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            // App Rest Api Key
            request.Headers.Add("Authorization", "Basic "+app.basic_auth_key);
            try
            {
                var response = request.GetResponse();
            }
            catch (Exception e)
            {

            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OneSignalAppsViewModel> GetAllApps()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://onesignal.com/api/v1/apps");
            request.Method = "GET";
            // Account Auth Key
            request.Headers.Add("Authorization", "Basic NWVjZTJhMmItMjBkMy00MjJjLThkNGEtNmM4OGM3Yzk5YzAy");

            var response = request.GetResponse();
            string applist;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                applist = sr.ReadToEnd();
                List<OneSignalAppsViewModel> jsonlist = JsonConvert.DeserializeObject<List<OneSignalAppsViewModel>>(applist);
                return jsonlist;
            }
        }

        public OneSignalAppsViewModel GetAppById(string appId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://onesignal.com/api/v1/apps/"+appId);
            request.Method = "GET";
            request.Headers.Add("Authorization", "Basic NWVjZTJhMmItMjBkMy00MjJjLThkNGEtNmM4OGM3Yzk5YzAy");

            var response = request.GetResponse();
            string applist;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                applist = sr.ReadToEnd();
                OneSignalAppsViewModel app = JsonConvert.DeserializeObject<OneSignalAppsViewModel>(applist);
                return app;
            }
        }

        public async Task UpdateApp(OneSignalAppsViewModel app)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PUT"), "https://onesignal.com/api/v1/apps/"+app.Id))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic NWVjZTJhMmItMjBkMy00MjJjLThkNGEtNmM4OGM3Yzk5YzAy");

                    request.Content = new StringContent("{\"name\" : \"" + app.Name + "\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}
