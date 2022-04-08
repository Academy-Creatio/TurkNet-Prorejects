using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TurkNet.Api
{
	public class BootParamsResultDto : IBootParamsResultDto
	{
		[JsonPropertyName("activationDate")]
		public string ActivationDate { get; set; }

		[JsonPropertyName("customerId")]
		public int CustomerId { get; set; }

		[JsonPropertyName("subscriberId")]
		public string SubscriberId { get; set; }

		[JsonPropertyName("systemOperators")]
		public List<string> SystemOperators { get; set; }

		[JsonPropertyName("ticketHelpPageUrl")]
		public string TicketHelpPageUrl { get; set; }

		[JsonPropertyName("travelerInternetFunnelUrl")]
		public string TravelerInternetFunnelUrl { get; set; }

		[JsonPropertyName("travelerMainCustomerNumber")]
		public int TravelerMainCustomerNumber { get; set; }

		[JsonPropertyName("travelerProducts")]
		public List<string> TravelerProducts { get; set; }

		[JsonPropertyName("voiceProductId")]
		public int VoiceProductId { get; set; }

		[JsonPropertyName("isFiber")]
		public bool IsFiber { get; set; }
	}
}
