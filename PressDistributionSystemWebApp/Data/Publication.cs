namespace PressDistributionSystemWebApp.Data
{
    public class Publication
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateOnly ShipmentDate { get; set; }
        public virtual DateOnly ReturnDate { get; set; }
        public virtual string Issue { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<PublicationDistributor>? PublicationDistributors { get; set; }
    }
}
