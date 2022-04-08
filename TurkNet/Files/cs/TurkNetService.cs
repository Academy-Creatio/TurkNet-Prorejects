using Common.Logging;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Terrasoft.Core;
using Terrasoft.Web.Common;
using TurkNet.Api;

namespace TurkNet
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TurkNetService : BaseService
	{
		#region Properties
		private ILog _loger => LogManager.GetLogger("TurkNetLogger");
		private SystemUserConnection _systemUserConnection;
		private SystemUserConnection SystemUserConnection
		{
			get
			{
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}
		#endregion

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		public BootParamsDto GetMethodname()
		{
			//http://localhost:5000/rest/TurkNetService/GetMethodname
			//UserConnection userConnection = UserConnection ?? SystemUserConnection;

			ITurkNetCient turkNetClient = Terrasoft.Core.Factories.ClassFactory.Get<ITurkNetCient>();
			return turkNetClient.GetBootParams();
		}

		//http://localhost:5000/rest/TurkNetService/GetCustomerTicketsByOperationGroups?groups=47,40,51,139,204,124,160

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		public string GetCustomerTicketsByOperationGroups(string groups)
		{
			//http://localhost:5000/rest/TurkNetService/GetMethodname
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			TurkNetCLient  turkNetClient = new TurkNetCLient ();

			return turkNetClient.GetCustomerTicketsByOperationGroups(groups);			
		}
	}
}



