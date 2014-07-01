using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderRepository
    {
        private CloudStorageAccount _storage;
        private CloudTable _table;
        private CloudTableClient _client;

        public OrderRepository(string conn)
        {
            _storage = CloudStorageAccount.Parse(conn);

            _client = _storage.CreateCloudTableClient();
            _table = _client.GetTableReference("orders");
        }

        public void Initialize()
        {
            _table.CreateIfNotExists();
        }

        public void Add(Order order)
        {
            var result = _table.Execute(TableOperation.Insert(order));
        }

        public IEnumerable<Order> Get()
        {
            var qry = new TableQuery<Order>();
            return _table.ExecuteQuery(qry).ToArray();
        }

        public void Delete(int id)
        {

        }
    }
}
