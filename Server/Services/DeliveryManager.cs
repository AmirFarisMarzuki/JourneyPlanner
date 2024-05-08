using JourneyPlanner.Shared.Models;
using JourneyPlanner.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace JourneyPlanner.Server.Services
{
    public class DeliveryManager : IDelivery
    {
        private readonly PlanYourJourneyContext _context;

        public DeliveryManager(PlanYourJourneyContext context)
        {
            _context = context;
        }

        //Get all user details
        public List<Delivery> GetDeliveryDetails()
        {
            try
            {
                return _context.Deliveries.ToList();
            }
            catch
            {
                throw;
            }
        }

        //Add new delivery
        public void AddDelivery(Delivery delivery)
        {
            try
            {
                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
            }
            catch {
                throw;
            }
        }

        //Update delivery
        public void UpdateDelivery(Delivery delivery)
        {
            try {
                _context.Entry(delivery).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch { throw; }
        }

        //Get single delivery data
        public Delivery GetDeliveryData(int Id)
        {
            try {
                Delivery? delivery = _context.Deliveries.Find(Id);
                if (delivery != null)
                {
                    return delivery;
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch { throw; }
        }

        //Delete delivery
        public void DeleteDeliveryData(int Id)
        {
            try {
                Delivery? delivery = _context.Deliveries.Find(Id);
                if (delivery != null)
                {
                    _context.Deliveries.Remove(delivery);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch { throw; }
        }


    }
}
