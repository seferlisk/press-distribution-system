namespace PressDistributionSystemWebApp.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ShipmentDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public string Issue { get; set; }

        public ICollection<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
