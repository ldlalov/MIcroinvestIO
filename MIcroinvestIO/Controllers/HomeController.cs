using MIcroinvestIO.Data;
using MIcroinvestIO.Micro;
using MIcroinvestIO.Models;
using MIcroinvestIO.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace MIcroinvestIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly MultiContext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ICashBookService cashBookService;
        private readonly IConfiguration _configuration;

        private List<CashBook> records;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _httpContextAccessor, MultiContext context, ICashBookService _cashBookService, IConfiguration configuration)
        {
            _logger = logger;
            httpContextAccessor = _httpContextAccessor;
            _context = context;
            cashBookService = _cashBookService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Pass it to the view using ViewBag
            ViewBag.ConnectionString = connectionString;
            return View();
        }

        public async Task<IActionResult> Database()
        {
            var dbData = new Database();
            return View(dbData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Database(Database dbData)
        {
            string connectionString = $"    \"DefaultConnection\": \"Server={dbData.Ip};Database={dbData.DatabaseName};user={dbData.User};password={dbData.Password};encrypt=false;\"";
            var filePath = Path.Combine(AppContext.BaseDirectory, "../../../appsettings.json");/// !!!Change it in final project to work!!!
            List<string> json = System.IO.File.ReadAllLines(filePath).ToList();
            json.RemoveAt(2);
            json.Insert(2, connectionString);
            System.IO.File.Delete(filePath);
            System.IO.File.AppendAllLines(filePath,json);
            string conString = $"server={dbData.Ip};Database={dbData.DatabaseName};User Id={dbData.User};Password={dbData.Password};encrypt=false;";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {

                    con.Open();
                    dbData.Success = "Success!";
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(dbData);
        }
        public IActionResult CashBook()
        {
            ViewBag.City = "Всички";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CashBook(DateTime? startDate, DateTime? endDate, string? city)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.City = city;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var result = new List<CashBookViewModel>();
            if (startDate == null || endDate == null)
            {
                return View();
            }
            try
            {
                records = await cashBookService.FiltheredRecords(startDate, endDate);
                var objects = _context.Objects.ToList();// Not good but I will fix it

                foreach (var record in records) 
                {
                    result.Add(new CashBookViewModel
                    {
                        CashBook = record,
                        Object = objects.FirstOrDefault(objects => objects.Id == record.ObjectId).Name
                    });
                    
                }
                if (city !=null && city != "Всички")
                {
                    result = result.FindAll(r => r.Object == city);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
