using global:: Common.Logging;
using Terrasoft.Core;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;
using TurkNet.Api;

namespace TurkNetConf
{
	/// <summary>
	/// Listener for 'EntityName' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contact")]
	internal class ContactEventListener : BaseEntityEventListener
	{


		#region Methods : Public : OnSave
		public override void OnSaving(object sender, EntityBeforeEventArgs e)
		{
			base.OnSaving(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;

			var logger = LogManager.GetLogger("TurkNetLogger");
			logger.Info("Logging OnSaving inside CONFIGURATION");

			Terrasoft.Core.Factories.ClassFactory.Get<ICalculator>("V1");


			//entity.SetColumnValue("Name", "KIRILL TEST");
		}
		public override void OnSaved(object sender, EntityAfterEventArgs e)
		{
			base.OnSaved(sender, e);
			Entity entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
		}
		#endregion
	}
}
