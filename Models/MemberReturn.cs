using System.Data;
using  ASP_MVC_Core_1.Models;

namespace ASP_MVC_Core_1.Models
{
 public interface MemberReturn
    {
        List<Member> MaleMember();
        Member OldestMember();
        Tuple<List<Member>, List<Member>, List<Member>> MemberYear(int year);
        List<Member> AllPeople();
        List<string> FullNames();
        DataTable Data();
    }
}