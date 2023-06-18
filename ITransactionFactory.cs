using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implemementera2
{
    // En kort förklaring kring hur jag tänkt och använt Factory. 
    //I koden används Factory Method-mönstret för att skapa rätt typ av transaktion baserat på användarens val.
    //I TransactionFactory-klassen används CreateTransaction-metoden för att skapa antingen en WithdrawalTransaction eller en DepositTransaction beroende på användarens val.

    public interface ITransactionFactory
    {
        ITransaction CreateTransaction();
    }
    public class TransactionFactory : ITransactionFactory
    {
        public ITransaction CreateTransaction()
        {
            // Läser användarens val och returnera rätt typ av transaktion
            Console.WriteLine("Välj transaktionstyp:");
            Console.WriteLine("1. Uttag");
            Console.WriteLine("2. Insättning");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return new WithdrawalTransaction();
                case "2":
                    return new DepositTransaction();
                default:
                    Console.WriteLine("Ogiltigt val! Återgår till uttags-transaktion.");
                    return new WithdrawalTransaction();
            }
        }
    }


}
