using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersFriend.Utilities.ConsumeWebApi.Helpers
{
  public  class ConsumeWebApiHelper<T>
    {
        public async Task<T> ConsumeWebApi(string apiurl, HttpMethod httpVerb, StringContent requestBody = null)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage Response = null;
                if (httpVerb == HttpMethod.Get)
                {
                    Response = await client.GetAsync(apiurl);

                }
                else if (httpVerb == HttpMethod.Delete)
                {
                    Response = await client.DeleteAsync(apiurl);

                }
                else if (httpVerb == HttpMethod.Post)
                {
                    Response = await client.PostAsync(apiurl, requestBody);

                }
                else if (httpVerb == HttpMethod.Put)
                {
                    Response = await client.PutAsync(apiurl, requestBody);

                }
                var result = await Response.Content.ReadAsAsync<T>();
                return result;
            }
        }
    }
}
