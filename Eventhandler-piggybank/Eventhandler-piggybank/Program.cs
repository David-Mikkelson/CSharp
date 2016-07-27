using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventhandler_piggybank
{
    // This is the delegate that is the pattern for the methods that it will call
    public delegate void BalanceEventHandler(decimal theValue);

    class holdBalance
    {
        private decimal total;
        // Set up eventhandler statement 
        // BalanceEventHandler is the way to Identify the delegate
        // DUDE is the new name of the event
        public event BalanceEventHandler DUDE;
        public decimal Total
        {
            set
            {
                this.total += value;
                // Put handler here is calling the methods that are attached to the 
                // delegate BalanceEventHandler
                this.DUDE(this.total);
            }
            get {
                return total;
            }
        }
    }

    class bankchecker
    {
        // This is a method that fits the delegate pattern{ void and needs one decimal} 
        public void check_total(decimal value)
        {
            if(value > 500m)
            {
                Console.WriteLine("Congradulations You've passed your goal of $500.");
            }
        }
        // Testing a second method inside the same class to add to the delegate
        public void JustAnotherMethod(decimal value)
        {
            Console.WriteLine("Just checking again {0}", value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            // create instances of the eventshandlers
            holdBalance t = new holdBalance();
            bankchecker w = new bankchecker();

            /// connect the method with the handler
            /// This will use methods to create the event handlers 
            /// the Lambda's are currently doing
            //t.DUDE += w.check_total;
            //t.DUDE += w.JustAnotherMethod;

            /// This is creating a Lambda function instead of 
            /// making a new method to fit the delegate
            t.DUDE += (x) =>
            {
                Console.WriteLine("Your new total is {0}", x);
            };

            /// Creating an event to handle the method of checking the total
            /// for more than $500. 
            t.DUDE += (x) =>
            {
                if (x > 500m)
                {
                    Console.WriteLine("Congradulations, you've reach your goal of saving $500");
                }
            };

            string inputs;

            do
            {
                Console.Write("How much would you like to deposit? ");
                inputs = Console.ReadLine();
                if (!(inputs == "exit"))
                {
                    try
                    {
                        decimal getmoney = decimal.Parse(inputs);
                        t.Total = getmoney;
                        //Console.WriteLine("your total balance so far is {0}", t.Total);
                    }catch
                    {
                        Console.WriteLine("That was not a number, Please enter a number or exit to quit!");
                    } 
                }
            } while (!(inputs == "exit"));
            Console.WriteLine("Thanks, your total balance is {0}", t.Total);


        }
    }
}
