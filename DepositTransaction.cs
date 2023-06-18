using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implemementera2
{
    internal class DepositTransaction : ITransaction
    {
        public void Execute()
        {
            // Logik för insättnings-transaktion
            Console.WriteLine("Ange belopp att sätta in:");
            string input = Console.ReadLine();
            double amount;
            if (double.TryParse(input, out amount))
            {
                // Utför insättningstransaktionen med det angivna beloppet
                ATM.Instance.Account.Balance += amount;
                Console.WriteLine($"Insättning av {amount} genomförd.");
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp. Försök igen.");
            }
        }
    }
}
