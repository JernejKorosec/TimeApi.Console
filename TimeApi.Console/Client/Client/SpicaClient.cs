using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TimeApi.Console.Client.DTO;
using TimeApi.Console.Client.Enum;

namespace TimeApi.Console.Client.Client
{
    public class SpicaClient
    {
        public static HttpClient httpClient = new HttpClient();
        private static RequestCredential requestCredential = new RequestCredential();
        private static int TokenTimeout = (60 * 20 - 30);
        static SpicaClient()
        {

        }
        public static AuthenticationHeaderValue GenerateClientAuthorizationHeader(string apiKey)
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
                if (httpClient.DefaultRequestHeaders.Authorization.Scheme == TokenAuthentication.Scheme && httpClient.DefaultRequestHeaders.Authorization.Parameter != null)
                    if (requestCredential != null)
                    {
                        // vrne samo property authorization v headerju ki ima vrednost [Authorization], [API GUID:Token from GetSession]
                        return new AuthenticationHeaderValue(TokenAuthentication.Scheme, string.Format("{0}:{1}", apiKey, requestCredential.Token));
                    }
            return new AuthenticationHeaderValue(TokenAuthentication.Scheme, apiKey);
        }

        public static void ReLogin()
        {
            System.Console.WriteLine("ReLogin()");
            httpClient.DefaultRequestHeaders.Authorization = GenerateClientAuthorizationHeader(Api.key);
            LoginWithUsername(Endpoints.ApiHttpBasicUrl.GetPath, Endpoints.GetSession.GetPath);
            httpClient.DefaultRequestHeaders.Authorization = GenerateClientAuthorizationHeader(Api.key);
        }
        public static void LoginWithUsername(String url, string endpoint)
        {
            var requestBody = new
            {
                Username = requestCredential.Username,
                Password = requestCredential.Password,
                Sid = ""
            };
            var requestBodyStr = JsonConvert.SerializeObject(requestBody);
            var requestBodyContent = new StringContent(requestBodyStr, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url + endpoint);
            request.Content = requestBodyContent;
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string str = response.Content.ReadAsStringAsync().Result;
                //return JsonConvert.DeserializeObject<RequestCredential>(str);
                requestCredential = JsonConvert.DeserializeObject<RequestCredential>(str);
            }
            else
            {
            }
        }
        public static bool isTokenValid(double validityTreshold)
        {
            double diffInSeconds = 0;
            if (requestCredential != null)
                if (requestCredential.Token != null)
                    if (requestCredential.TokenTimeStamp != null)
                    {
                        DateTime now = DateTime.Now;
                        DateTime tokenTimeStamp = (DateTime)requestCredential.TokenTimeStamp;
                        diffInSeconds = (now - tokenTimeStamp).TotalSeconds;
                    }
                    else return false;
                else return false;
            else return false;

            if (diffInSeconds > validityTreshold) return false;
            else return true;
        }
        public bool setSession()
        {
            ReLogin();
            return isTokenValid(TokenTimeout);
            //SpicaClient.httpClient.DefaultRequestHeaders.Authorization = GenerateClientAuthorizationHeader(Api.key);
        }

        public List<Employee> getAllEmployees()
        {
            string str = "empty";
            if (!isTokenValid(TokenTimeout))
            {
                ReLogin();
            }
            //http://rdweb.spica.com:5213/timeapi/employee

            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.ApiHttpBasicUrl.GetPath + Endpoints.Employee.GetPath);
            /*
            HttpRequestOptions requestOptions = new HttpRequestOptions();
            requestOptions.TryAdd()
            */

            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                str = response.Content.ReadAsStringAsync().Result;
                /*
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                */
                //List<Dictionary<string, string>> customerDictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(str); // dela
                //List < Employee >
                /*
                foreach (Dictionary<string, string> customerDictionary in customerDictionaryList)
                {
                    foreach (var customer in customerDictionary)
                    {
                        System.Console.WriteLine(customer.Key);

                    }
                    System.Console.WriteLine("========================================");
                    System.Console.WriteLine("========================================");
                }
                */
                return JsonConvert.DeserializeObject<List<Employee>>(str); // dela
            }
            return null;
        }



        public List<Employee> getAllEmployeesByProperties(Employee employee)
        {
            string str = "empty";
            if (!isTokenValid(TokenTimeout))
            {
                ReLogin();
            }

            String parameters = $"?firstname={employee.FirstName}&lastname={employee.LastName}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Endpoints.ApiHttpBasicUrl.GetPath + Endpoints.Employee.GetPath + parameters);
            /*
            request.Headers.Add("Accept", "application/x-www-form-urlencoded");
            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            */
            /*
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "firstname", employee.FirstName },
                { "lastname", employee.LastName },
            });
            */

            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                str = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Employee>>(str); // dela
            }
            return null;
        }
        public bool AddNewEmployee(Employee employee)
        {
            // Primerjaj če je objekt dodan tako da primerjas rezultat z zahtevo vnesenega zaposlenega
            var employee2Add = JsonConvert.SerializeObject(employee);

            var requestBodyContent = new StringContent(employee2Add, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, Endpoints.ApiHttpBasicUrl.GetPath + Endpoints.Employee.GetPath);
            request.Content = requestBodyContent;
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string str = response.Content.ReadAsStringAsync().Result;
                Employee addedEmployee = JsonConvert.DeserializeObject<Employee>(str);
                //Compare both employees, the one added and the result returned
                return PublicInstancePropertiesEqual<Employee>(addedEmployee, employee);
            }
            return false;
        }
        public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        if (!pi.Name.Equals("Id") && !pi.Name.Equals("Active"))
                        {
                            object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                            object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                            if(selfValue!=null)
                            if (!(selfValue.Equals("") && toValue == null))
                            if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return self == to;
        }

        public List<Employee> getAllEmployeesByPresence(int orgUnit, bool showInactiveEmployees, DateTime dateTime)
        {
            if (!isTokenValid(TokenTimeout))
            {
                ReLogin();
            }
            // 29.1.2022 18:43:00
            string timeStampString = dateTime.ToString("d.M.yyyy hh:HH:ss"); //!!
            String parameters = $"?TimeStamp={timeStampString}&OrgUnitID={orgUnit}&showInactiveEmployees={showInactiveEmployees}";
            String fullQueryString = Endpoints.ApiHttpBasicUrl.GetPath + Endpoints.Presence.GetPath + parameters;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Endpoints.ApiHttpBasicUrl.GetPath + Endpoints.Presence.GetPath + parameters);
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                String str = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Employee>>(str); // dela
            }
            return null;
        }
    }
}