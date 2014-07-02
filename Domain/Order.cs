using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Order : TableEntity
    {
        public int Ids { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
    }
}