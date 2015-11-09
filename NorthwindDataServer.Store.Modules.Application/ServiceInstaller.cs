using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC0KG.WindowsService;

namespace NorthwindDataServer.Store.Modules.Application
{
    [RunInstaller(true)]
    [ServiceName("NorthwindDataService", DisplayName = "Northwind Data Service", Description = "Northwind Data Service API Windows Service")]
    public class ServiceInstaller
    {
    }
}
