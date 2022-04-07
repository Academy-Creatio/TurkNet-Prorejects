using Common.Logging;
using System;
using System.Threading;
using Terrasoft.Core;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.AsyncOperations;
using Terrasoft.Core.Entities.AsyncOperations.Interfaces;
using Terrasoft.Core.Entities.Events;
using Terrasoft.Core.Factories;

namespace TurkNet.Files.cs.EventLIstener
{
	/// <summary>
	/// Listener for Contact entity events.
	/// <seealso href="https://academy.creatio.com/docs/developer/back_end_development/objects_business_logic/overview">Academy Documentation</seealso>
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contact")]
	internal class ContactEventListener : BaseEntityEventListener
	{
		
		#region Methods : Public

		#region Methods : Public : OnSave
		public override void OnSaving(object sender, EntityBeforeEventArgs e)
		{
			base.OnSaving(sender, e);
			Entity contactEntity = (Entity)sender;
			contactEntity.Validating += ContactEntity_Validating;

			contactEntity.SetColumnValue("Notes", $"{DateTime.Now:dd-MM-yyyy HH:mm} edited");
			
		}

		private void ContactEntity_Validating(object sender, EntityValidationEventArgs e)
		{
			Entity contactEntity = (Entity)sender;
			string newName = contactEntity.GetTypedColumnValue<string>("Name");
			string oldName = contactEntity.GetTypedOldColumnValue<string>("Name");
			string notes = contactEntity.GetTypedColumnValue<string>("Notes");

			if (newName.Contains("Kirill"))
			{
				var evm = new EntityValidationMessage
				{
					Text = "Name cannot contain Kirill",
					Column = contactEntity.Schema.Columns.GetByName("Name"),
					MassageType = Terrasoft.Common.MessageType.Error
				};
				contactEntity.ValidationMessages.Add(evm);

				var logger = LogManager.GetLogger("TurkNetLogger");
				logger.Info($"Could not validate Kirill");
			}


			if (newName.Contains("Supervisor"))
			{
				var evm = new EntityValidationMessage
				{
					Text = "Name cannot contain Supervisor",
					Column = contactEntity.Schema.Columns.GetByName("Name"),
					MassageType = Terrasoft.Common.MessageType.Error
				};
				contactEntity.ValidationMessages.Add(evm);

				var logger = LogManager.GetLogger("TurkNetLogger");
				logger.Info($"Could not validate Supervisor");
			}


		}

		public override void OnSaved(object sender, EntityAfterEventArgs e)
		{
			base.OnSaved(sender, e);
			Entity contactEntity = (Entity)sender;
			UserConnection userConnection = contactEntity.UserConnection;


			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>();
			// Parameters for asynchronous execution. 
			var operationArgs = new EntityEventAsyncOperationArgs((Entity)sender, e);
			// Execution in asynchronous mode.
			asyncExecutor.ExecuteAsync<DoSomethingActivityAsyncOperation>(operationArgs);


		}
		#endregion

		#region Methods : Public : OnInsert
		public override void OnInserting(object sender, EntityBeforeEventArgs e)
		{
			base.OnInserting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnInserted(object sender, EntityAfterEventArgs e)
		{
			base.OnInserted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnUpdate
		public override void OnUpdating(object sender, EntityBeforeEventArgs e)
		{
			base.OnUpdating(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnUpdated(object sender, EntityAfterEventArgs e)
		{
			base.OnUpdated(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#region Methods : Public : OnDelete
		public override void OnDeleting(object sender, EntityBeforeEventArgs e)
		{
			base.OnDeleting(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		public override void OnDeleted(object sender, EntityAfterEventArgs e)
		{
			base.OnDeleted(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion

		#endregion


	}
}
