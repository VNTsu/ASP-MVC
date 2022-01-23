using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_MVC_Core_1.Models;
using System.Data;
using ClosedXML.Excel;



namespace ASP_MVC_Core_1.Controllers
{

public class RookiesController : Controller
{
    private readonly ILogger<RookiesController> _logger;

    private readonly MemberReturn _memberReturn;


    public RookiesController(ILogger<RookiesController> logger, MemberReturn memberReturn)
    {
        _memberReturn = memberReturn;
        _logger = logger;
    }
     public IActionResult AllPeople() 
        {
            return Ok(_memberReturn.AllPeople());
        }

        public IActionResult Index()
        {
            return View();
        }
         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


        public IActionResult MaleMember()
        {
            return Ok(_memberReturn.MaleMember());
        }

        public IActionResult OldestMember()
        {
            return Ok(_memberReturn.OldestMember());
        }

        public IActionResult MemberYear(int year)
        {
            return Ok(_memberReturn.MemberYear(year));
        }


        public IActionResult FullNames()
        {
            return Ok(_memberReturn.FullNames());
        }
         public FileResult ExporttExcelFile()
        {
            var table = _memberReturn.Data();
            using (XLWorkbook ex = new XLWorkbook())
            {
                ex.Worksheets.Add(table, "AllMember");
                using (MemoryStream stream = new MemoryStream())
                {
                    ex.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AllPeople.xlsx");
                }
            }
        }

}
}

