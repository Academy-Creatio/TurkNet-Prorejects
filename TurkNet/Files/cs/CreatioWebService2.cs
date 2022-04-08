using System;
using System.Runtime.Serialization;
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


			
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public PersonModel Test2(PersonModel person)
		{
			return person;
		}
	}

	[DataContract]
	public class PersonModel
	{
		[DataMember(Name = "name", IsRequired = true, Order = 1)]
		public string Name { get; set; }

		[DataMember(Name = "age", IsRequired = true, Order = 2)]
		public string Age { get; set; }

		[DataMember(Name = "email", IsRequired = true, Order = 3)]
		public string Email { get; set; }
	}

}
