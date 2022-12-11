using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    // These are the setters

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        // Give a menu of options after they log in
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // check if user has enough money to withdraw
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you");
            }
        }
        // 8:47
        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5128381368581872", 1234, "Sigmund", "Serranilla", 500.50));
        cardHolders.Add(new cardHolder("9489238984039809", 4564, "Spencer", "Serranilla", 20.50));
        cardHolders.Add(new cardHolder("1279879349380289", 6867, "Sentry", "Serranilla", 2356.50));
        cardHolders.Add(new cardHolder("1232187943759873", 5656, "Mitchell", "Serranilla", 234363.50));
        cardHolders.Add(new cardHolder("1234098756437829", 1122, "Raul", "Serranilla", 454.50));
        cardHolders.Add(new cardHolder("1234", 1111, "test", "test", 0.00));



        // Prompt User
        Console.WriteLine("Welcome to Chase");
        Console.WriteLine("Please insert your card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) {break;}
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our database
                if(currentUser.getPin() == userPin) {break;}
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect Pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while(option != 4);
        Console.WriteLine("Thank you!");

    }


}