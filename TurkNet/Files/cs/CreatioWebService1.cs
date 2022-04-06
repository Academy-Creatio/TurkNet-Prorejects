using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Terrasoft.Core;
using Terrasoft.Web.Common;
using TurkNet;

namespace FINANCE
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CreatioWsTemplate : BaseService
	{
		#region Properties
		private SystemUserConnection _systemUserConnection;
		private SystemUserConnection SystemUserConnection
		{
			get
			{
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}
		#endregion

		//[OperationContract]
		//[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, 
		//	BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		//public BootParamsDto GetMethodname()
		//{
		//	//http://localhost:5000/rest/CreatioWsTemplate/GetMethodname
		//	UserConnection userConnection = UserConnection ?? SystemUserConnection;
		//	RemoteClient remoteClient = new RemoteClient();

		//	BootParamsDto result = default;
		//	Task.Run(async() => { 
		//		result = await remoteClient.GetBootParams().ConfigureAwait(false);
		//	}).Wait();


		//	return result;
		//}

		//http://localhost:5000/rest/CreatioWsTemplate/GetCustomerTicketsByOperationGroups?groups=47,40,51,139,204,124,160

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, 
			BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
		public string GetCustomerTicketsByOperationGroups(string groups)
		{
			//http://localhost:5000/rest/CreatioWsTemplate/GetMethodname
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			RemoteClient remoteClient = new RemoteClient();

			var result = string.Empty;
			Task.Run(async() => { 
				result = await remoteClient.GetCustomerTicketsByOperationGroups(groups).ConfigureAwait(false);
			}).Wait();
			return result;
		}
	}
}



