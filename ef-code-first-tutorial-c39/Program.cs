
using ef_code_first_tutorial_c39;

using Microsoft.EntityFrameworkCore;

var _context = new SalesDbContext();

var order = _context.Orders
                        .Include(x => x.Orderlines)
                            .ThenInclude(x => x.Item)
                        .Include(x => x.Customer)
                        .Single(x => x.Id == 2);

Console.WriteLine($"ORDER: Description: {order.Description}");

foreach(var ol in order.Orderlines) {
    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
                        $" Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
}

var orderTotal = order.Orderlines.Sum(ol => ol.Item.Price * ol.Quantity);

Console.WriteLine($"Total: {orderTotal:C}");


//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));