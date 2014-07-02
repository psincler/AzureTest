using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Domain;

namespace WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("WorkerRole entry point called");

            while (true)
            {
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            var repo = new OrderRepository(RoleEnvironment.GetConfigurationSettingValue("Storage"));

            repo.Initialize();

            repo.Get().ToList().ForEach(o => repo.Delete(o));

            if (repo.Get().Count() == 0)
                repo.Add(new Order
                {
                    Ids = 1,
                    Customer = RoleEnvironment.GetConfigurationSettingValue("Env"),
                    Product = "A gun to shoot NuGet!",
                    PartitionKey = "blah",
                    RowKey = Guid.NewGuid().ToString(),
                });

            return base.OnStart();
        }
    }
}
