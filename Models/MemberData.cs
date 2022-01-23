using  ASP_MVC_Core_1.Models;
namespace ASP_MVC_Core_1.Models{

public static class MemberData
     {
          public static List<Member> NewMembers = new List<Member>() {
               new Member("Huy", "Pham", TypeGender.Male , new DateTime(1999,2,12), "0963164813", "HaNoi", false),
               new Member("Hoang", "Nguyen", TypeGender.Male , new DateTime(2000,2,12), "0963164813", "HaNoi", true),
               new Member("Thuy", "Pham", TypeGender.Female , new DateTime(2000,2,12), "0963164813", "HaNoi", true),
               new Member("Cuong", "Nguyen", TypeGender.Male , new DateTime(2001,2,12), "0963164813", "HaNoi", false)
          };
     }
}