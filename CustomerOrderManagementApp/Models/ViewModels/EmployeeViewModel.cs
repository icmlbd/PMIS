namespace CustomerOrderManagementApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        internal string EmployeeId;

        public int Id { get; set; }

        public string Name { get; set; }

        public string EmployeeIDNo { get; set; }

        // Other necessary employee fields
        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string FathersName { get; set; }

        public string MothersName { get; set; }

        public string? SpousesName { get; set; }

        public string? MobileNo { get; set; }

        public string? TelephoneNo { get; set; }

        public string? Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? NIDNo { get; set; }

        public string? BloodGroup { get; set; }

        public string? BankAccountInfo { get; set; }
    }
}
