// public class KuBank
// {
//     static void Main(string[] args)
//     {
//         double balance = 1000.0;
//         bool running = true;

//         while (running)
//         {
//             Console.WriteLine("Welcome to KuBank!");
//             Console.WriteLine("1. Check Balance");
//             Console.WriteLine("2. Deposit");
//             Console.WriteLine("3. Withdraw");
//             Console.WriteLine("4. Exit");
//             Console.Write("Choose an option: ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     Console.WriteLine($"Your balance is: ${balance}");
//                     break;
//                 case "2":
//                     Console.Write("Enter deposit amount: ");
//                     double deposit = Convert.ToDouble(Console.ReadLine());
//                     if (deposit > 0)
//                     {
//                         balance += deposit;
//                         Console.WriteLine($"Deposited: ${deposit}");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Invalid deposit amount.");
//                     }
//                     break;
//                 case "3":
//                     Console.Write("Enter withdrawal amount: ");
//                     double withdrawal = Convert.ToDouble(Console.ReadLine());
//                     if (withdrawal <= balance)
//                     {
//                         balance -= withdrawal;
//                         Console.WriteLine($"Withdrew: ${withdrawal}");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Insufficient funds.");
//                     }
//                     break;
//                 case "4":
//                     running = false;
//                     Console.WriteLine("Thank you for using KuBank!");
//                     break;
//                 default:
//                     Console.WriteLine("Invalid option. Please try again.");
//                     break;
//             }

//             Console.WriteLine();
//         }
//     }
// }