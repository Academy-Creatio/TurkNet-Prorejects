using System.Threading.Tasks;
using TurkNet.Api.Dto;

namespace TurkNet.Api
{
	public interface IRemoteClient
	{
		//Task<string> GetBootParams();
		Task<string> GetCustomerTicketsByOperationGroups(string operationGroups);
	}
}
