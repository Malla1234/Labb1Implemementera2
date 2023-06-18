namespace Labb1Implemementera2
{
    internal class Program
    {
        /// Jag har använd mig utav Factory, Singelton och Observer som designmönster.
        ///Sammanfattningsvis, Factory Method används för att skapa rätt typ av transaktion,
        /// Singleton används för att begränsa instansieringen av ATM till en enda instans och Observer används för att informera observatörer om ändringar i kontots saldo.

        static void Main(string[] args)
        {
            ATM atm = ATM.Instance;

            // Skapa användargränssnitt
            UserInterface userInterface = new UserInterface();
            // Lägg till användargränssnittet som en observatör
            atm.Account.AddObserver(userInterface);

            bool running = true;

            while (running)
            {
                ITransactionFactory transactionFactory = atm.TransactionFactory;

                ITransaction transaction = transactionFactory.CreateTransaction();
                transaction.Execute();

                Console.WriteLine();
            }

        }
    }
}