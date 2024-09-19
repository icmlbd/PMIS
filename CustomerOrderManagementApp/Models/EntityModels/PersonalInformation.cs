namespace CustomerOrderManagementApp.Models.EntityModels
{
    public class PersonalInformation
    {
        public int Id { get; set; } // Primary Key

        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public string FathersName { get; set; }
        public string MothersName { get; set; }

        public string? SpousesName { get; set; }
        public string? SpousesOccupation { get; set; }

        public string? IdentificationMark { get; set; }

        public string MobileNo { get; set; }
        public string? TelephoneNo { get; set; }
        public string Email { get; set; }

        public string? Religion { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? MaritalStatus { get; set; }
        public int? NoOfChildren { get; set; }

        public string? HomeDistrict { get; set; }
        public string BloodGroup { get; set; }

        public string? PassportNo { get; set; }
        public string NIDNo { get; set; }

        public string BankAccountInfo { get; set; }

        // Foreign Key to Employee
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } // Navigation Property
    }
}
