using JourneyPlanner.Shared.Models;
namespace JourneyPlanner.Server.Interfaces
{
    public interface IDelivery
    {
        public List<Delivery> GetDeliveryDetails();
        public void AddDelivery(Delivery delivery);
        public void UpdateDelivery(Delivery delivery);
        public Delivery GetDeliveryData(int Id);
        public void DeleteDeliveryData(int Id);
    }
}
