using System;
namespace GangOfFour.Facade.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Facade Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main ()
        {
            // Facade
            Mortgage mortgage = new Mortgage ();
            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer ("Ann McKinsey");
            bool eligible = mortgage.IsEligible (customer, 125000);
            Console.WriteLine ("\n" + customer.Name +
                " е " + (eligible ? "Одобрена" : "Неодобрена"));
            // Wait for user
            Console.ReadKey ();
        }
    }
    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings (Customer c, int amount)
        {
            Console.WriteLine ("Провери банката за " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit (Customer c)
        {
            Console.WriteLine ("Провери кредита на " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans (Customer c)
        {
            Console.WriteLine ("Провери дълговете на " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// Customer class
    /// </summary>
    class Customer
    {
        private string _name;
        // Constructor
        public Customer (string name)
        {
            this._name = name;
        }
        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Mortgage
    {
        private Bank _bank = new Bank ();
        private Loan _loan = new Loan ();
        private Credit _credit = new Credit ();
        public bool IsEligible (Customer cust, int amount)
        {
            Console.WriteLine ("{0} кандидатства за {1:C} заем\n",
                cust.Name, amount);
            bool eligible = true;
            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings (cust, amount))
            {
                eligible = false;
            } else if (!_loan.HasNoBadLoans (cust))
            {
                eligible = false;
            } else if (!_credit.HasGoodCredit (cust)) {
                eligible = false;
            }

            return eligible;
        }
    }
}

/*
Output:

Ann McKinsey кандидатства за $125,000.00 заем

Провери банката за Ann McKinsey
Провери дълговете на Ann McKinsey
Провери кредита на Ann McKinsey

Ann McKinsey е Одобрена
*/