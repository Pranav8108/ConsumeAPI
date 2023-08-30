namespace ThirdPartyAPI.Models
{
	public interface IHolidayAPIService
	{
		Task<List<HolidayModel>> GetHolidays(string CountryCode , int year);
	}
}
