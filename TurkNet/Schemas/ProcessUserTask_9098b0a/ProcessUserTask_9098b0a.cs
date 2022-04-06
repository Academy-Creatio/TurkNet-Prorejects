namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Threading.Tasks;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;
	using TurkNet.Api;

	#region Class: ProcessUserTask_9098b0a

	/// <exclude/>
	public partial class ProcessUserTask_9098b0a
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {


			//IRemoteClient remoteClient = Factories.ClassFactory.Get<IRemoteClient>();

			bool isFiber = false;
			Task.Run(async () =>
			{
				//TurkNet.Dto.IBootParamsDto result =  await remoteClient.GetBootParams();
				//result.Result.

			}).Wait();



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

