using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implemementera2
{
    internal class WithdrawalTransaction : ITransaction
    {
        public void Execute()
        {
            // Logik för uttags-transaktion
            Console.WriteLine("Ange det belopp du vill ta ut:");
            string input = Console.ReadLine();
            double amount;
            if (double.TryParse(input, out amount))
            {
                // Utför uttagstransaktionen med det angivna beloppet
                if (ATM.Instance.Account.Balance >= amount)
                {
                    ATM.Instance.Account.Balance -= amount;
                    Console.WriteLine($"Uttag av {amount} genomfört.");
                }
                else
                {
                    Console.WriteLine("Otillräckligt saldo på kontot.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp. Försök igen.");
            }
        }
    }
}
