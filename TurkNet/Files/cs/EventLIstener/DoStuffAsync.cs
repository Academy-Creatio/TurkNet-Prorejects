using Common.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Terrasoft.Core;
using Terrasoft.Core.AsyncOperations.Interfaces;
using Terrasoft.Core.Entities.AsyncOperations;
using Terrasoft.Core.Entities.AsyncOperations.Interfaces;

namespace TurkNet.Files.cs.EventLIstener
{

    public class DoSomethingActivityAsyncOperation : IEntityEventAsyncOperation
    {
        // Start method of the class.
        public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments)
        {

            throw new NotImplementedException("THIS IS MY MESSAGE");
            Thread.Sleep(5 * 1000);

            var logger = LogManager.GetLogger("TurkNetLogger");
            logger.Info("Async Operation");
            
            var values = arguments.EntityColumnValues;
            foreach(var value in values)
			{
                logger.Info($"Key:{value.Key} Value:{value.Value}");
			}
        }
    }

}
