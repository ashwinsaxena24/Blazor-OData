using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlexGridOData.Data
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }

    public class OrdersContext
    {
        private string URL => "https://services.odata.org/Northwind/Northwind.svc/";
        private ODataService<Order> Service { get; set; }

        public OrdersContext()
        {
            this.Service = new ODataService<Order>(this.URL, "Orders");
        }

        public async Task<List<Order>> GetOrders()
        {
            var ordersList = await this.Service.GetAsync();
            return ordersList;
        }
    }
}
