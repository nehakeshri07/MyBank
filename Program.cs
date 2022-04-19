using System;

namespace MyBank;

class Program
{
    static void Main(String[] args)
    {
        var account1 = new BankAccount("Neha", 10000);
        Console.WriteLine($"New Bank account created for {account1.Owner} having account number {account1.Number} with initial balance {account1.Balance}.");
        Console.WriteLine("Do you want to add mobile number?");
        Console.WriteLine("1.Yes");
        Console.WriteLine("2.No");
        bool choice;
        int n;
        choice = int.TryParse(Console.ReadLine().Trim(), out n);
        if (n == 1 && choice==true)
        {
            Console.WriteLine("Please enter your mobile number:");
            string mob = Console.ReadLine();
            account1.SetMobileNo(mob);
            string number = account1.GetMobileNo();
            Console.WriteLine("Details after updation of mobile number: ");
            Console.WriteLine($"New Bank account created for {account1.Owner} having account number {account1.Number} with initial balance {account1.Balance} and mobile number {number}.");
        }
        else if (n == 2 && choice == true)
        {
            Console.WriteLine("Okay! Carry on the next process!");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        account1.MakeWithdrawal(900, DateTime.Now, "Amount for rent payment.");
        Console.WriteLine("Balance after withdrawal : "+account1.Balance);
        account1.MakeDeposit(200, DateTime.Now, "Friend paid me back.");
        Console.WriteLine("Balance after deposit : "+account1.Balance);
        Console.WriteLine("Do you want to take loan?");
        Console.WriteLine("1.Yes");
        Console.WriteLine("2.No");
        int val;
        bool isLoan = int.TryParse(Console.ReadLine().Trim(), out val);
        LoanUtility loan = new LoanUtility();
        if (isLoan == true && val == 1)
        {
            Console.WriteLine("Enter the amount for which you want to take loan:");
            decimal amount = Convert.ToDecimal(Console.ReadLine().Trim());
            Console.WriteLine("Enter the time period in years for which you want to take loan:");
            decimal time = Convert.ToDecimal(Console.ReadLine().Trim());
            decimal totalAmount = loan.LoanCalculation(amount, time);
            Console.WriteLine($"The total amount to be paid including simple interest is: {totalAmount}.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        BankAccount invalid;
        try
        {
            invalid = new BankAccount("Invalid", -100);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught while creating negative balance!");
            Console.Write(e.ToString());
            //return;
        }
        try
        {
            account1.MakeWithdrawal(750, DateTime.Now, "Attempt to Overdraw!!");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to Overdraw!");
            Console.WriteLine(e.ToString());
            //return;
        }
        Console.WriteLine(account1.GetAccountHistory());
        var giftCard = new GiftCardAccount("gift card", 100, 50);
        giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
        giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
        giftCard.PerformMonthEndTransactions();
        // can make additional deposits:
        giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
        Console.WriteLine(giftCard.GetAccountHistory());

        var savings = new InterestEarningAccount("savings account", 10000);
        savings.MakeDeposit(750, DateTime.Now, "save some money");
        savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
        savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
        savings.PerformMonthEndTransactions();
        Console.WriteLine(savings.GetAccountHistory());

     

        var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
        // How much is too much to borrow?
        lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
        lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
        lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
        lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
        lineOfCredit.PerformMonthEndTransactions();
        Console.WriteLine(lineOfCredit.GetAccountHistory());

        //DoFunc(account1.);
    }

    public static void DoFunc( ILoan loan)
    {
        loan.LoanCalculation(100, 99);
    }
}