//using System;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Terrasoft.Core.Factories;
//using TurkNet.Api;

//namespace TurkNet
//{
//	[DefaultBinding(typeof(ITurkNetClient))]

//	public class TurkNetClient //: ITurkNetClient
//	{
//		private HttpClient _httpClient;
//		private readonly HttpMessageHandler _httpClientHandler;
//		private readonly CookieContainer _cookieContainer = new CookieContainer();
//		private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im9pbSIsIlVzZXJJbmZvIjoie1wiQWN0aXZhdGlvbkRhdGVcIjpcIjIwMjItMDEtMDZUMDA6MDA6MDBcIixcIkN1c3RvbWVySWRcIjoxOTA3LFwiRmliZXJTdGF0dXNcIjp7XCJGaWJlclR5cGVcIjozLFwiRmliZXJUeXBlTmFtZVwiOlwiVFRGaWJlckZUVEhcIixcIklzRmliZXJcIjp0cnVlfSxcIklzRmliZXJcIjozLFwiSXNGaXJzdExvZ2luXCI6ZmFsc2UsXCJNYWluU2VydmljZUlkXCI6bnVsbCxcIlBsU2VnbWVudElkXCI6NCxcIlNlcnZpY2VHcm91cElkXCI6MzcsXCJTZXJ2aWNlU3RhdGVcIjo2LFwiU2hvd0FjdGl2YXRpb25QYWdlXCI6ZmFsc2UsXCJTdWJzY3JpYmVySWRcIjpcIjIxMjY3NDc5NDhcIixcIlRva2VuSWRcIjpcIjBcIixcIlVzZXJOYW1lXCI6XCJBbGV4RGVTb3V6YVwiLFwiVXNlclNlcnZpY2VcIjo0OTM5MjU1LFwiVm9pY2VQcm9kdWN0SWRcIjowLFwiVHJhdmVsZXJQcm9kdWN0c1wiOltdLFwiVHJhdmVsZXJNYWluQ3VzdG9tZXJOdW1iZXJcIjowfSIsIm5iZiI6MTY0OTI0MDg2MSwiZXhwIjoxNjQ5MjU1MjYxLCJpYXQiOjE2NDkyNDA4NjEsImlzcyI6Imlzc3VlciIsImF1ZCI6ImF1ZGllbmNlIn0.0rgpOh51SSmjzKC_u7N1fErooCS7OA0Q-PhbsQygYuc";
//		private const string _getBootParamsUrl = "ServiceOim/GetBootParams";
//		private const string _getSubscribersUrl = "ServiceOim/GetSubscribers";
//		private const string _getCustomerTicketsByOperationGroupsUrl = "ServiceOim/GetCustomerTicketsByOperationGroups";

//		public TurkNetClient()
//		{

//			_httpClientHandler = new HttpClientHandler()
//			{
//				UseCookies = true,
//				CookieContainer = _cookieContainer
//			};

//			_httpClient = new HttpClient(_httpClientHandler)
//			{
//				BaseAddress = new Uri("https://appservice.turk.net")
//			};

//			_httpClient.DefaultRequestHeaders.Add("auth-user", _token);
//		}

//		public string GetBootParams()
//		{
//			var json = string.Empty;
//			Task.Run(async () =>
//			{
//				HttpResponseMessage httpResponseMessage =
//					await _httpClient.PostAsync(_getBootParamsUrl, null).ConfigureAwait(false);
//				json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

//			}).Wait();

//			return json;
//			//try
//			//{
//			//	//return "Ok";
//			//	return JsonSerializer.Deserialize<BootParamsDto>(json);
//			//}
//			//catch (Exception ex)
//			//{
//			//	Console.WriteLine(ex.Message);
//			//	throw;
//			//}
//		}

//		public string GetCustomerTicketsByOperationGroups(string operationGroups)
//		{
//			return "OK";
//			//OperationGroupsDto model = new OperationGroupsDto()
//			//{
//			//	OperationGroups = operationGroups
//			//};

//			//var content = new StringContent(JsonSerializer.Serialize(model));
//			//content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

//			//HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(
//			//	_getCustomerTicketsByOperationGroupsUrl, content).ConfigureAwait(false);

//			//var json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
//			//return json;
//		}
//	}
//}
