using System.Xml.Linq;

class PurchaseProgram
{
    static List<PurchaseOrder> purchaseOrders = new () { };
    
    static void Main(string[] args)
    {
        string filename = @"C:\Users\verifier\Documents\vscode\WorkingWithDotNet\ConsoleApp1\purchase\purchase.xml";   
        XDocument doc = XDocument.Load(filename);

        purchaseOrders = ProcessData(doc);
        
        /* Menu
        - Display all purchase orders
        - Display details of a specific purchase order
        - Display details of orders from specific date range
        */

        while (true)
        {
            Console.WriteLine("[1]: Display all orders");
            Console.WriteLine("[2]: Search order");
            Console.WriteLine("[3]: Search orders by date");
            Console.WriteLine("[#]: Exit");
            Console.Write("Enter your choice: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "#":
                    return;
                case "1":
                    DisplayAllOrders(purchaseOrders);
                    break;
                case "2":
                    Console.Write("Enter Purchase Order Number: ");
                    var PurchaseOrderNumber = Console.ReadLine();

                    PurchaseOrder? Order = SearchOrder(PurchaseOrderNumber);
                    DisplayOrder(Order);
                    SendOrderNotification(Order);
                    break;
                case "3":
                    Console.Write("Enter start date: ");
                    var StartDate = getDate("start", "1900-01-01");

                    Console.Write("Enter end date: ");
                    var EndDate = getDate("end", "2026-01-01");

                    List <PurchaseOrder> OrdersByDate = SearchOrderByDate(StartDate, EndDate);
                    DisplayAllOrders(OrdersByDate);  
                    break;
                default:
                    Console.WriteLine("Invalid option...");
                    break;
            }
        }
    }

    private static void SendOrderNotification(PurchaseOrder? order)
    {
        if (order != null)
        {
            NotificationProcess Process = new NotificationProcess();
            NotificationService Trigger = new NotificationService();

            if (order.Email != "" && order.PhoneNo != "")
            {
                Process.NofiticationDelegate = Trigger.SendEmail;
                Process.ProcessdOrder(order.PurchaseOrderNumber, order.Email);

                Process.NofiticationDelegate = Trigger.SendSMS;
                Process.ProcessdOrder(order.PurchaseOrderNumber, order.PhoneNo);
            }else if(order.Email == "" && order.PhoneNo != "")
            {
                Process.NofiticationDelegate = Trigger.SendSMS;
                Process.ProcessdOrder(order.PurchaseOrderNumber, order.PhoneNo);
            }else if (order.Email != "" && order.PhoneNo == "")
            {
                Process.NofiticationDelegate = Trigger.SendEmail;
                Process.ProcessdOrder(order.PurchaseOrderNumber, order.Email);
            }
        }
    }

    private static DateOnly getDate(string arg, string defaultDate)
    {
        Console.Write($"Enter {arg} date: ");
        return DateOnly.Parse(Console.ReadLine()??$"{defaultDate}");
    }
    
    private static PurchaseOrder? SearchOrder(string? purchaseOrderNumber)
    {
        return purchaseOrders
        .Where(order => order.PurchaseOrderNumber == purchaseOrderNumber)
        .FirstOrDefault();
    }

    private static List<PurchaseOrder> SearchOrderByDate(DateOnly startDate, DateOnly endDate)
    {
        if (endDate > startDate)
        {
            
            Console.WriteLine($"{new string('-', 40)}\n");
            Console.WriteLine("End Date cannot be earlier than Start Date...");
            Console.WriteLine($"{new string('-', 40)}\n");
            return [];
        }

        return purchaseOrders
        .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate)
        .OrderBy(order => order.OrderDate)
        .ToList();
    }

    private static void PrintAddress(Address? address)
    {
        if (address == null) return;
        Console.Write($"\t{address.Name}");
        Console.Write($" {address.Street}");
        Console.Write($" {address.City}, {address.State} {address.Zip}");
        Console.Write($" {address.Country}\n");
    }

    private static void PrintOrderItems(List<Item> items)
    {
        items.ForEach(item =>
        {
            Console.WriteLine($"Product name: {item.ProductName}, Price: {item.USPrice}, Qty: {item.Quantity}");
        });
    }

    private static void DisplayOrder(PurchaseOrder? order)
    {
        if (order == null)
        {
            Console.WriteLine($"{new string('-', 40)}\n");
            Console.WriteLine("No order found!");
            Console.WriteLine($"{new string('-', 40)}\n");
        }
        else{
            Console.WriteLine($"{new string('-', 40)}\n");
            Console.WriteLine($"Purchase Order Number: \t{order.PurchaseOrderNumber}");
            Console.WriteLine($"Purchase Date:  \t{order.OrderDate}");
            Console.WriteLine($"PhoneNo:  \t\t{order.PhoneNo}");
            Console.WriteLine($"Email:  \t\t{order.Email}");
            Console.WriteLine($"Delivery Notes: \t{order.DeliveryNotes}");

            Console.Write("BillingAddress: ");
            PrintAddress(order.BillingAddress);

            Console.Write("ShippingAddress: ");
            PrintAddress(order.ShippingAddress);

            PrintOrderItems(order.Items);

            Console.WriteLine($"{new string('-', 40)}\n");
        }    
    }

    private static void DisplayAllOrders(List<PurchaseOrder> orders)
    {
        orders.ForEach(order => DisplayOrder(order));
    }

    private static List <PurchaseOrder> ProcessData(XDocument doc)
    {
        var orders = doc.Descendants("PurchaseOrder")
        .Select(po => new PurchaseOrder
        {
            PurchaseOrderNumber = po.Attribute("PurchaseOrderNumber")?.Value ?? "",
            PhoneNo = po.Attribute("PhoneNo")?.Value ?? "",
            Email = po.Attribute("Email")?.Value ?? "",
            DeliveryNotes = po.Element("DeliveryNotes")?.Value,
            OrderDate = DateOnly.Parse(po.Attribute("OrderDate")?.Value ?? "1900-01-01"),
            ShippingAddress = GetAddress(po, "Shipping"),
            BillingAddress = GetAddress(po, "Billing"),
            Items = GetItems(po)
        })
        .ToList();  

        return orders; 
    }

    private static Address GetAddress(XElement po, string type)
    {
        XElement? addressElement = po.Elements("Address")
            .First(a => a.Attribute("Type")?.Value == type);
            
        return new Address
            {
                Type = type,
                Name = addressElement.Element("Name")?.Value ?? "",
                Street = addressElement.Element("Street")?.Value ?? "",
                City = addressElement.Element("City")?.Value ?? "",
                State = addressElement.Element("State")?.Value ?? "",
                Zip = addressElement.Element("Zip")?.Value ?? "",
                Country = addressElement.Element("Country")?.Value ?? ""
            };
    }

    private static List <Item> GetItems(XElement po, string type = "Item")
    {
        var items = po.Descendants(type)
            .Select(item => new Item(
                item.Attribute("PartNumber")?.Value ?? "",
                item.Element("ProductName")?.Value ?? "",
                float.Parse(item.Element("USPrice")?.Value ?? "0"),
                int.Parse(item.Element("Quantity")?.Value ?? "1")
            ))
            .ToList();
        
        return items;
    }     
}





    