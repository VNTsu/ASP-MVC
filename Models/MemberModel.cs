namespace ASP_MVC_Core_1.Models
{

public partial class Member
    {
        public String FirtName { get; set; }
        public String LastName { get; set; }
        public TypeGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String PhoneNumber { get; set; }
        public String BirthPlace { get; set; }
        public bool Graduated { get; set; }
         public Member (String inputFirtName, String inputLastName, TypeGender InputGender, DateTime inputDate, String inputPhoneNumber, String inputBirdPlace, bool inputGraduated)
        {
            this.FirtName = inputFirtName;
            this.LastName = inputLastName;
            this.Gender = InputGender;
            this.DateOfBirth = inputDate;
            this.PhoneNumber = inputPhoneNumber;
            this.BirthPlace = inputBirdPlace;
            this.Graduated = inputGraduated;
        }
        public string FullName
        {
            get
            {
                return String.Format("Tên là: {0} {1} ", FirtName, LastName);
            }
        }
     
    }

public enum TypeGender
    {
        Male =1,
        Female =2,
    }
}
    
   