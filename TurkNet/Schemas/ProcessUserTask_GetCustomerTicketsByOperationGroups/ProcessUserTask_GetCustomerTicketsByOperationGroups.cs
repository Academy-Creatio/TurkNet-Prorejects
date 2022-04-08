namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;
	using TurkNet.Api;

	#region Class: ProcessUserTask_GetCustomerTicketsByOperationGroups

	/// <exclude/>
	public partial class ProcessUserTask_GetCustomerTicketsByOperationGroups
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {

			ITurkNetCient turkNetCient = Factories.ClassFactory.Get<ITurkNetCient>();
			Json = turkNetCient.GetCustomerTicketsByOperationGroups(operationGroups);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

