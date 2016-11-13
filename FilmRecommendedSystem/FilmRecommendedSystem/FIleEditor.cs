using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FilmRecommendedSystem
{
    public class FIleEditor
    {
        public static List<User> LoadData()
        {
            List<User> users = new List<User>();
            
            string url = "http://localhost/users";
            try
            {
                using (var webClient = new WebClient())
                {
                    users = JsonConvert.DeserializeObject<List<User>>(webClient.DownloadString(url));
                    return users;
                }
            }
            catch
            {
                return new List<User>();
            }
        }

        public static void SaveData(List<User> users)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/users");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(users);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
