public class Member(string membershipID, string name, bool isActive)
{
    public string Name { get; set; } = name;
    public string MembershipID { get; } = membershipID;
    public bool IsActive { get; set; } = isActive;

    public void DisplayInfo()
    {
        Console.WriteLine($"Member: {Name}, ID: {MembershipID}, Active: {IsActive}");
    }
}