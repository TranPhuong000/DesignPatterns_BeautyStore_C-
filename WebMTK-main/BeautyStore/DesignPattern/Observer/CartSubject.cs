using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern.Observer
{
    public class CartSubject
    {
        private List<ICartObserver> observers = new List<ICartObserver>();

        public void Attach(ICartObserver observer)
        {
            observers.Add(observer);
        }
        public void Detach(ICartObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.UpdateCart();
            }
        }
    }
}