using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ThirdPartyAPI.Models
{
	public class HolidayAPIService: IHolidayAPIService
	{
		private static readonly HttpClient client;

        static HolidayAPIService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at")
            };
        }

        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            try
            {
                var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
                var result = new List<HolidayModel>();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();

                    result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                }
                else
                {

                    throw new HttpRequestException(response.ReasonPhrase);
                }

                return result;
            }
            catch (HttpRequestException)
            {

                return new List<HolidayModel>(); // Return an empty list as a default
            }
        }
        //--------------------------------------------------------------------------------
        //////------------esari garey ni huncha--------------------------------------------
        //public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        //{

        //    HttpClient client = new HttpClient();


        //    try
        //    {
        //        var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
        //        var response = await client.GetAsync(url);
        //        var result = new List<HolidayModel>();
        //        string responseBody = await client.GetStringAsync(url);
        //        result = JsonSerializer.Deserialize<List<HolidayModel>>(responseBody,
        //                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        //        return result;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine("\nException Caught!");
        //        Console.WriteLine("Message :{0} ", e.Message);
        //    }



        //}
        //------------------------------------------------------------------------------------------------------
    }


}
