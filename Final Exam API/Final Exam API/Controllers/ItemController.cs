using Final_Exam_API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


namespace FinalExamInventory.Controllers {
    public class ItemController : Controller {

        List<Item> items = null;

        public ItemController() {
            IDBManager DBM = new DBManager();   
            items = DBM.getItems();
        }

        public IActionResult Index() {
            return View();
        }
        [HttpGet("Item")]
        public IActionResult Items() {

            var ret = JsonConvert.SerializeObject(items);
            return Ok(ret);
        }
        [HttpGet("Item/{id:int}")]
        public IActionResult Items(int id) {

            Item resItem = getThisItem(id);

            if (resItem.id == -99) {
                resItem.errorMsg = "Item Id Not Found";
                resItem.errorCode = -99;
            } else {
                resItem.errorMsg = "Item Found";
                resItem.errorCode = 0;
            }
            var ret = JsonConvert.SerializeObject(resItem);
            return Ok(ret);
        }

        [HttpGet("ItemByCost")]
        public IActionResult ItemsByCost([FromQuery] decimal lowCost, [FromQuery] decimal hiCost ) {

            List<Item> resItem = getItemTotalCostByCost(lowCost, hiCost);

            var ret = JsonConvert.SerializeObject(resItem);
            return Ok(ret);
        }
        [HttpGet("SuggestedSalesItems/{threshHold:decimal}")]
        public IActionResult SuggestedSalesItems([FromQuery] decimal threshHold) {

            List<Item> resItem = getSuggestedSalesItems(threshHold);

            var ret = JsonConvert.SerializeObject(resItem);
            return Ok(ret);
        }


        //[HttpGet("ItemTotalCostByCost/{cost:decimal}")]
        //public IActionResult ItemsByCostTotalCost(decimal cost) {
        //    decimal hiCost = 10000.00m;
        //    List<Item> resItem = getItemTotalCostByCost(cost, hiCost );

        //    var ret = JsonConvert.SerializeObject(resItem);
        //    return Ok(ret);
        //}

        [HttpGet("ShowAverage/{maxCost:decimal}")]
        public IActionResult ShowAverage(decimal maxCost) {

            AverageRecord a = getAverageGTthreshHold(maxCost);

            var ret = JsonConvert.SerializeObject(a);
            return Ok(ret);
        }
        [HttpPost("Order")]
        public IActionResult Order([FromBody] Order order) {
            Item resItem = getThisItem(order.Id);
            if (resItem.id == -99) {
                order.OrderResponseMessage = "Item Not Found";
                order.ErrorCode = -99;
            } else if (!order.Name.Equals(resItem.name)) {
                order.OrderResponseMessage = "Error Found ID with different name";
                order.ErrorCode = -101;
            } else if (order.Quantity > resItem.numberAvail) {
                order.OrderResponseMessage = "Insufficent Quantity";
                order.ErrorCode = -100;
            } else if (order.CustomerId % 2 != 0 && order.CustomerId <100 ) {
                order.OrderResponseMessage = "Customer Id Must be an even number from 0-100 (inclusive)";
                order.ErrorCode = -101;
            } else {
                order.OrderResponseMessage = "Order Complete";
                order.ErrorCode = 0;
            }
            var ret = JsonConvert.SerializeObject(order);
            return Ok(ret);
        }

        private Item getThisItem(int id) {
            foreach (Item itm in this.items) {
                if (itm.id == id) {
                    return itm;
                }
            }
            Item item = new Item(-99, "Not Found", 0, 0);
            return item;
        }

        private List<Item> getItemTotalCostByCost(decimal lowCost, decimal hiCost) {
            List<Item> costItems = new List<Item>();
            foreach (Item itm in this.items) {
                if (itm.cost > lowCost && itm.cost < hiCost ) {
                    costItems.Add(itm);
                } else {
                    System.Diagnostics.Debug.WriteLine("---------- NOT THIS ONE Item:{0} locosts:{1} hicost:{2}", itm.name, lowCost, hiCost);

                }
            }
            return costItems;
        }
        private List<Item> getTotalInventoryCost(decimal cost) {
            List<Item> costItems = new List<Item>();
            foreach (Item itm in this.items) {
                if (itm.cost > cost) {
                    costItems.Add(itm);
                }
            }
            return costItems;
        }

        private List<Item> getSuggestedSalesItems( decimal threshHold) {
            List<Item> retItems = new List<Item>();
            foreach (Item itm in this.items) {
                int avail = itm.numberAvail;
                decimal cost = itm.cost;
                if ( (avail*cost) > threshHold) {
                    System.Diagnostics.Debug.WriteLine("---------- Yes Item:{0} costs:{1} more than thre:{2}", itm.name, avail * cost, threshHold);
                    retItems.Add(itm);
                }
            }
            return retItems;
        }
        private AverageRecord getAverageGTthreshHold(decimal threshHold) {
            List<Item> retItems = new List<Item>();
            decimal aver = 0.0m;
            decimal sum = 0.0m;
            int ct  = 0;
            AverageRecord a = new AverageRecord();
            foreach (Item itm in this.items) {
                decimal cost = itm.cost;
                ct += 1;
                if ((cost) >= threshHold) {
                    sum += cost;
                }
                aver = Math.Round( (sum / ct),2);
                a.Count = ct;
                a.Average = aver;
                a.maxCost = threshHold;
                a.Sum = sum;
            }
            return a;
        }
    }
}
