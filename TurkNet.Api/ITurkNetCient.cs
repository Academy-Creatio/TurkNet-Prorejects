using System.Threading.Tasks;

namespace TurkNet.Api
{
	public interface ITurkNetCient
	{
		BootParamsDto GetBootParams();
		Task<BootParamsDto> GetBootParamsAsync();

		string GetCustomerTicketsByOperationGroups(string operationGroups);
		Task<string> GetCustomerTicketsByOperationGroupsAsync(string operationGroups);
	}
}
