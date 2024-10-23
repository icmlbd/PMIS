namespace CustomerOrderManagementApp.Models.EntityModels
{
    public class CustomerCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Customer> Customers { get; set; }

    }
}
