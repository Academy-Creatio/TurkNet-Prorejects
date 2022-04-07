namespace TurkNet.Api
{
	public interface ITurkNetClient
	{
		string GetBootParams();
		string GetCustomerTicketsByOperationGroups(string operationGroups);
	}
}
