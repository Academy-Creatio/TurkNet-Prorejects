using System.Collections.Generic;

namespace TurkNet.Api
{
	public interface IBootParamsResultDto
	{
		string ActivationDate { get; set; }
		int CustomerId { get; set; }
		bool IsFiber { get; set; }
		string SubscriberId { get; set; }
		List<string> SystemOperators { get; set; }
		string TicketHelpPageUrl { get; set; }
		string TravelerInternetFunnelUrl { get; set; }
		int TravelerMainCustomerNumber { get; set; }
		List<string> TravelerProducts { get; set; }
		int VoiceProductId { get; set; }
	}
}