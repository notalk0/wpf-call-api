using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInfo()
        {
            string uri = "https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75536852&date=today";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
