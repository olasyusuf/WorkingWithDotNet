public class PurchaseOrder
{
    public required string PurchaseOrderNumber { get; set; }
    public string ? DeliveryNotes { get; set; }
    public DateOnly OrderDate { get; set; }
    public Address ? ShippingAddress { get; set; }
    public Address ? BillingAddress { get; set; }
    public List<Item> Items { get; set; } = [];

}


















