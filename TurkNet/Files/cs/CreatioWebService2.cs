using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Terrasoft.Core;
using Terrasoft.Web.Common;

namespace FINANCE
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CreatioWsTemplate : BaseService
	{
		
		private SystemUserConnection _systemUserConnection;
		private SystemUserConnection SystemUserConnection
		{
			get
			{
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string PostMethodName(Guid bankLineId)
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;
			return "Ok";
		}

		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetMethodname(string email)
		{
			UserConnection userConnection = UserConnection ?? SystemUserConnection;


			var schema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var contact = schema.CreateEntity(UserConnection);
			contact.FetchFromDB("Email", email);

			

			return contact.GetTypedColumnValue<string>("Name");


			return "Ok";
		}
	}
}
