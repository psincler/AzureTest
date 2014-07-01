using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Domain;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole.Controllers
{
    public class OrderController : ApiController
    {
        private static OrderRepository GetRepo()
        {
            return new OrderRepository(RoleEnvironment.GetConfigurationSettingValue("Storage"));
        }
        // GET api/<controller>
        public IEnumerable<Order> Get()
        {
            return GetRepo().Get();
        }

        // GET api/<controller>/5
        public Order Get(int id)
        {
            return GetRepo().Get().FirstOrDefault(i => i.Ids == id);
        }

        // POST api/<controller>
        public void Post(Order order)
        {
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            
        }
    }
}