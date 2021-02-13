using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using SetTradeBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SetTradeBot.Services
{
    public class GoogleAPI
    {
        public static async Task<Ohlc[]> GetSET50()
        {
            var HttpGet = new HttpClient();

            var url = $"https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/Sheet2&limit=50";

            var jsdata = await HttpGet.GetStringAsync(url);

            var obj = JsonConvert.DeserializeObject<MySet>(jsdata);

            return obj.items;
        }
        public static async Task<Ohlc[]> GetAllSET()
        {
            var HttpGet = new HttpClient();

            var url = $"https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/Sheet1&limit=1000";

           var jsdata = await HttpGet.GetStringAsync(url);

            var obj = JsonConvert.DeserializeObject<MySet>(jsdata);

            return obj.items;
        }
        public static async Task<Favorite[]> GetAllFavorite(string lineid)
        {
            var query = System.Net.WebUtility.UrlEncode("{\"lineid\":\"" + lineid + "\"}");

            var url = $"https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/favorite&query={query}";

            var HttpGet = new HttpClient();

            var jsdata = await HttpGet.GetStringAsync(url);

            var obj = JsonConvert.DeserializeObject<MyFavorite>(jsdata);

            return obj.items;
        }
        public static async Task<string> GetFavoriteJSON(string lineid, string symbol)
        {
            var HttpGet = new HttpClient();
            var query = System.Net.WebUtility.UrlEncode("{\"lineid\":\"" + lineid + "\",\"symbol\":\"" + symbol + "\"}");
            var url = $"https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/favorite&query={query}";
            var jsdata = await HttpGet.GetStringAsync(url);

            return jsdata;
        }
        public static async Task UpdateFavoriteActive(Model.Favorite Favorite)
        {
            var jsdata = await SetTradeBot.Services.GoogleAPI.GetFavoriteJSON(Favorite.lineid, Favorite.symbol);

            if (jsdata.IndexOf("\"" + Favorite.symbol + "\"") > -1)
            {
                int start = jsdata.IndexOf("#");
                int end = jsdata.IndexOf("lineid");
                var id = jsdata.Substring(start, end - start).Replace("\"", "").Replace(",", "").Replace(":", "").Replace("#", "");//'#":"86bb6f6a30a9","'

                var url = "https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/favorite&method=PUT";
                var json = "{\"#\" : \"" + id + "\",\"active\" : \"" + Convert.ToInt16(Favorite.active).ToString() + "\",\"lineid\":\"1\",\"symbol\":\"" + Favorite.symbol + "\",\"createdate\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"}";

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.SetBrowserRequestMode(BrowserRequestMode.NoCors);
                    //var json = JsonConvert.SerializeObject(content);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        request.Content = stringContent;
                        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        request.Content.Headers.ContentType = null;
                        using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                            if (!response.IsSuccessStatusCode)
                            {
                                var errorMessage = response.ReasonPhrase;
                                Console.WriteLine($"Error! {errorMessage}");
                                //return errorMessage;
                            }
                        }
                    }
                }

            }

        }
        public static async Task AddFavorite(string lineid, string symbol)
        {
            var jsdata = await SetTradeBot.Services.GoogleAPI.GetFavoriteJSON(lineid, symbol);

            if (jsdata.IndexOf("\"" + symbol +"\"") == -1)
            {
                
                var url = "https://script.google.com/macros/s/AKfycbxe6QG2n8IRTWyv4nFMl3UMeUKp-6_i0wQlDbIVkN2xOC59f5jB-gYz1Q/exec?path=/favorite&method=POST";
                var postBody = new { lineid = lineid, symbol = symbol, active = 1, createdate = DateTime.Now };

                var json = JsonConvert.SerializeObject(postBody);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.SetBrowserRequestMode(BrowserRequestMode.NoCors);
                    //var json = JsonConvert.SerializeObject(content);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        request.Content = stringContent;
                        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        request.Content.Headers.ContentType = null;
                        using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                        {
                            //response.EnsureSuccessStatusCode();
                            //if (!response.IsSuccessStatusCode)
                            //{
                            //    var errorMessage = response.ReasonPhrase;
                            //    Console.WriteLine($"Error! {errorMessage}");
                            //    //return errorMessage;
                            //}
                        }
                    }
                }

            }

        }

    }
}
