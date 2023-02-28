
using ef_code_first_tutorial_c39.Controller;

var custCtrl = new CustomersController();

var customer = await custCtrl.GetCustomerWithOrders(1);

//if(customer is null) return;

Console.WriteLine($"CUSTOMER: {customer.Name}");
foreach (var ord in customer.Orders) {
    Console.WriteLine($"- ORDER: Desciption {ord.Description}");
    foreach (var ol in ord.Orderlines) {
        Console.WriteLine($"-- ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
                    $" Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
    }
}



//using ef_code_first_tutorial_c39;

//using Microsoft.EntityFrameworkCore;

//var _context = new SalesDbContext();

//var customer = _context.Customers
//                            .Include(x => x.Orders)
//                            .ThenInclude(x => x.Orderlines)
//                            .ThenInclude(x => x.Item)
//                            .Single(x => x.Id == 1);

//Console.WriteLine($"CUSTOMER: {customer.Name}");
//foreach (var ord in customer.Orders) {
//    Console.WriteLine($"- ORDER: Desciption {ord.Description}");
//    foreach(var ol in ord.Orderlines) {
//        Console.WriteLine($"-- ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
//                    $" Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
//    }
//}

//var order = _context.Orders
//                        .Include(x => x.Customer)
//                        .Include(x => x.Orderlines)
//                            .ThenInclude(x => x.Item)
//                        .Single(x => x.Id == 2);

//Console.WriteLine($"ORDER: Description: {order.Description}");

//foreach(var ol in order.Orderlines) {
//    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
//                        $" Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
//}

//var orderTotal = order.Orderlines.Sum(ol => ol.Item.Price * ol.Quantity);

//Console.WriteLine($"Total: {orderTotal:C}");


//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));