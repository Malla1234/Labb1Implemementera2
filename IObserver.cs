using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Implemementera2
{   //// En kort förklaring kring hur jag tänkt och använt Observer.
    // I koden används Observer-mönstret för att informera användargränssnittet (UserInterface) om förändringar i kontots saldo.
    // Account-klassen fungerar som subjektet och observatörer (t.ex. UserInterface) läggs till i och tas bort från subjektet.
    // När kontots saldo ändras meddelas observatörerna via Update-metoden.
    // Jag har lagt in kommentar i programmet så man ser att det funkar "Notifierar observatörer". 
    public interface IObserver
    {
        void Update(double balance);
    }

    public class Account
    {
        private List<IObserver> observers = new List<IObserver>();
        private double balance;
        public double Balance
        {
            get { return balance; }
            set { balance = value; NotifyObservers(); }
        }

        public void AddObserver(IObserver observer) 
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) 
        {
            observers.Remove(observer);
        }
        private void NotifyObservers() 
        {
            Console.WriteLine("Notifierar observatörer");
            foreach (var observer in observers)
            {
                observer.Update(balance);
            }
        }

    }
}
