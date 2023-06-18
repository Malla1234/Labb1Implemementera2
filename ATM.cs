using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implemementera2
{
    // En kort förklaring kring hur jag tänkt och använt Singelton.
    // I koden används Singleton-mönstret för att skapa och ge åtkomst till en enda instans av ATM-klassen.
    // Detta görs genom att jag har gjort konstruktor privat och en statisk egenskap Instance som returnerar den enda instansen av ATM
    public class UserInterface : IObserver
    {
        public void Update(double balance)
        {
            // Uppdatera användargränssnittet med det nya saldot
            Console.WriteLine($"Nytt saldo: {balance}");
        }
    }

    public class ATM
    {
        private Account account = new Account();
        private UserInterface userInterface= new UserInterface();
        private ITransactionFactory transactionFactory = new TransactionFactory(); // Tilldela en instans av TransactionFactory

        private static ATM instance;

        // Privat konstruktor för att förhindra direkt instansiering
        private ATM()
        {
        }

        // Singleton-instans. Metod för att få referensen till den enda instansen av ATM
        public static ATM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ATM();
                }
                return instance;
            }
        }
        public Account Account
        {
            get { return account; }
        }
        public ITransactionFactory TransactionFactory
        {
            get { return transactionFactory; }
        }

        public void Run()
        {
            // Logik för att köra bankomaten
            ITransaction transaction = transactionFactory.CreateTransaction();
            transaction.Execute();

            account.AddObserver(userInterface);
            double amount = 100.0; // uttagsbelopp eller insättningsbelopp
            account.Balance += amount; // Uppdatera kontosaldo
        }
    }
}

