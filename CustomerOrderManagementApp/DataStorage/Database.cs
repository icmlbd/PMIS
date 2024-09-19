using CustomerOrderManagementApp.Models.EntityModels;

namespace CustomerOrderManagementApp.DataStorage
{
    public class Database
    {

        public static int IdGenerator { get; set; } = 0;
        public Database()
        {
            //Customers = new List<Customer>();
        }
        public static List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
