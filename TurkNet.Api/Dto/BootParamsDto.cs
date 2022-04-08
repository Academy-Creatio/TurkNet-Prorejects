using System.Text.Json.Serialization;

namespace TurkNet.Api
{
	public class BootParamsDto : IBootParamsDto
	{
		[JsonPropertyName("status")]
		public bool Status { get; set; }

		[JsonPropertyName("resultCode")]
		public string ResultCode { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; }

		[JsonPropertyName("redirectUri")]
		public string RedirectUri { get; set; }

		[JsonPropertyName("result")]
		public BootParamsResultDto Result { get; set; }
	}
}
