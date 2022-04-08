using Common.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Terrasoft.Core.Factories;
using TurkNet.Api;
using TurkNet.Dto;

namespace TurkNet
{

	[DefaultBinding(typeof(ITurkNetCient))]
	public class TurkNetCLient : ITurkNetCient
	{
		private HttpClient _httpClient;
		private ILog _loger => LogManager.GetLogger("TurkNetLogger");
		private readonly HttpMessageHandler _httpClientHandler;
		private readonly CookieContainer _cookieContainer = new CookieContainer();
		private readonly Uri baseUri = new Uri("https://appservice.turk.net");
		private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im9pbSIsIlVzZXJJbmZvIjoie1wiQWN0aXZhdGlvbkRhdGVcIjpcIjIwMjItMDEtMDZUMDA6MDA6MDBcIixcIkN1c3RvbWVySWRcIjoxOTA3LFwiRmliZXJTdGF0dXNcIjp7XCJGaWJlclR5cGVcIjozLFwiRmliZXJUeXBlTmFtZVwiOlwiVFRGaWJlckZUVEhcIixcIklzRmliZXJcIjp0cnVlfSxcIklzRmliZXJcIjozLFwiSXNGaXJzdExvZ2luXCI6ZmFsc2UsXCJNYWluU2VydmljZUlkXCI6bnVsbCxcIlBsU2VnbWVudElkXCI6NCxcIlNlcnZpY2VHcm91cElkXCI6MzcsXCJTZXJ2aWNlU3RhdGVcIjo2LFwiU2hvd0FjdGl2YXRpb25QYWdlXCI6ZmFsc2UsXCJTdWJzY3JpYmVySWRcIjpcIjIxMjY3NDc5NDhcIixcIlRva2VuSWRcIjpcIjBcIixcIlVzZXJOYW1lXCI6XCJBbGV4RGVTb3V6YVwiLFwiVXNlclNlcnZpY2VcIjo0OTM5MjU1LFwiVm9pY2VQcm9kdWN0SWRcIjowLFwiVHJhdmVsZXJQcm9kdWN0c1wiOltdLFwiVHJhdmVsZXJNYWluQ3VzdG9tZXJOdW1iZXJcIjowfSIsIm5iZiI6MTY0OTQyMTQ2MywiZXhwIjoxNjQ5NDM1ODYzLCJpYXQiOjE2NDk0MjE0NjMsImlzcyI6Imlzc3VlciIsImF1ZCI6ImF1ZGllbmNlIn0.6FhMtT3XhgkFC8a3yw2qqYrh3RLyiGYTh8wr8cvW_Lw";
		private const string _getBootParamsUrl = "ServiceOim/GetBootParams";
		private const string _getSubscribersUrl = "ServiceOim/GetSubscribers";
		private const string _getCustomerTicketsByOperationGroupsUrl = "ServiceOim/GetCustomerTicketsByOperationGroups";

		public TurkNetCLient ()
		{
			_httpClientHandler = new HttpClientHandler()
			{
				UseCookies = true,
				CookieContainer = _cookieContainer
			};

			_httpClient = new HttpClient(_httpClientHandler)
			{
				BaseAddress = baseUri
			};

			_httpClient.DefaultRequestHeaders.Add("auth-user", _token);
		}

		public BootParamsDto GetBootParams() 
		{

			BootParamsDto result = default;
			Task.Run(async () =>
			{
				result = await GetBootParamsAsync();
			}).Wait();
			return result;
		}

		public string GetCustomerTicketsByOperationGroups(string operationGroups)
		{
			string result = default;
			Task.Run(async () =>
			{
				result = await GetCustomerTicketsByOperationGroupsAsync(operationGroups);
			}).Wait();
			return result;
		}

		public async Task<BootParamsDto> GetBootParamsAsync()
		{
			HttpResponseMessage httpResponseMessage =
				await _httpClient.PostAsync(_getBootParamsUrl, null).ConfigureAwait(false);
			string json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			try
			{
				return JsonSerializer.Deserialize<BootParamsDto>(json);
			}
			catch (Exception ex)
			{
				_loger.Error(ex.Message);
				throw;
			}
		}

		public async Task<string> GetCustomerTicketsByOperationGroupsAsync(string operationGroups)
		{
			OperationGroupsDto model = new OperationGroupsDto()
			{
				OperationGroups = operationGroups
			};

			var content = new StringContent(JsonSerializer.Serialize(model));
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(
				_getCustomerTicketsByOperationGroupsUrl, content).ConfigureAwait(false);

			var json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			return json;
		}
	}
}
