// public delegate void SendNotification(string message);

// class NotificationService
// {
//     public void SendEmail(string msg) => Console.WriteLine($"Email: {msg}");
//     public void SendSMS(string msg) => Console.WriteLine($"SMS: {msg}");
   
// }


// class OrderProcess
// {
//     public SendNotification? NofiticationDelegate;

//     public void ProcessdOrder(string id)
//     {
//         Console.WriteLine($"Processing order {id}");
//         NofiticationDelegate?.Invoke($"Order {id} processed succsfully");
//     }
// }

// class NotificationProgram
// {
//     // static void Main(string[] args)
//     // {
//     //     OrderProcess order = new OrderProcess();
//     //     NotificationService trigger = new NotificationService();

//     //     Console.WriteLine("");
//     //     order.NofiticationDelegate = trigger.

        
//     // }
// }