using System.Data;
using  ASP_MVC_Core_1.Models;

namespace ASP_MVC_Core_1.Models;
 
 public class Active : MemberReturn
 {

     public List<string> FullNames()
     {
          return MemberData.NewMembers.Select(mem => mem.FullName).ToList();
     }
     public Member OldestMember()
        {
            return MemberData.NewMembers.MinBy(m => m.DateOfBirth.Year);
        }
     public Tuple<List<Member>, List<Member>, List<Member>> MemberYear(int year)
        {
            var in2k = MemberData.NewMembers.Where(x => x.DateOfBirth.Year == year).ToList();
            var more2k = MemberData.NewMembers.Where(x => x.DateOfBirth.Year < year).ToList();
            var under2k = MemberData.NewMembers.Where(x => x.DateOfBirth.Year > year).ToList();
            return Tuple.Create(in2k, more2k, under2k);
        }
     public List<Member> MaleMember()
        {
            return MemberData.NewMembers.Where(m =>m.Gender.Equals(TypeGender.Male)).ToList();
        }
     public List<Member> AllPeople()
        {
            return MemberData.NewMembers.ToList();
        }
      public DataTable Data()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] { new DataColumn("First name"), new DataColumn("Last Name"), new DataColumn("Gender"), new DataColumn("Date Of Birth"), new DataColumn("Phone Number"), new DataColumn("BirthPlace"), new DataColumn("Granduated"), });
            foreach (var item in AllPeople())
            {
                table.Rows.Add(item.FirtName, item.LastName, item.Gender, item.DateOfBirth, item.PhoneNumber, item.BirthPlace, item.Graduated? "yes":"no");
            }
            return table;
        }
    
    

 }
