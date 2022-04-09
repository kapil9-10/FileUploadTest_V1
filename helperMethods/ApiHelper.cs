using helperMethods.Models;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace helperMethods
{
    public class ApiHelper
    {
        public static string BASE_API = "";
        public static string API_Key = "";
        public async static Task<FileUploadResult> PostFile(string path, string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_API);
                    using (var form = new MultipartFormDataContent())
                    {
                        using (var fs = File.OpenRead(path))
                        {
                            using (var streamContent = new StreamContent(fs))
                            {
                                using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                                {
                                    form.Add(fileContent, "file");
                                    form.Add(new StringContent(API_Key), "apikey");
                                    HttpResponseMessage response = await client.PostAsync(url, form);
                                    if (response.IsSuccessStatusCode)
                                    {
                                        var responseO = Newtonsoft.Json.JsonConvert.DeserializeObject<FileUploadResult>(await response.Content.ReadAsStringAsync());
                                        return responseO;
                                    }
                                    else if (response.StatusCode == HttpStatusCode.Forbidden)
                                    {
                                        throw new Exception("Forbidden");
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys from value in nvc.GetValues(key) select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))).ToArray();
            return "?" + string.Join("&", array);
        }
        public async static Task<T> getClientWithQuery<T>(string url, NameValueCollection queries)
        {
            try
            {
                var queryString = ToQueryString(queries);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_API);
                    var response = await client.GetAsync(String.Format("{0}{1}", url, queryString));
                    if (response.IsSuccessStatusCode)
                    {
                        var objModel = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                        return objModel;
                    }
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new Exception("Forbidden");
                    }
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
