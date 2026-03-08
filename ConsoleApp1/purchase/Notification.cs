using System.Runtime.CompilerServices;

public delegate void SendNotification(string? contact, string message);

class NotificationService
{
    public void SendEmail(string? contact, string msg) => Console.WriteLine($"Email: {msg} to {contact}");
    public void SendSMS(string? contact, string msg) => Console.WriteLine($"SMS: {msg} to {contact}");
   
}

class NotificationProcess
{
    public SendNotification? NofiticationDelegate;

    public void ProcessdOrder(string id, string? contact)
    {
        Console.WriteLine($"Processing order {id}");
        NofiticationDelegate?.Invoke(contact, $"Order {id} processed succsfully");
        Console.WriteLine($"{new string('-', 40)}\n");
    }
}