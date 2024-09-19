namespace CustomerOrderManagementApp.Models.EntityModels
{
    public class Employee
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }
        public string EmployeeId { get; set; }

        // Navigation Property to Personal Information
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
