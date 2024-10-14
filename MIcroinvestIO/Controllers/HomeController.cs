using MIcroinvestIO.Micro;
using MIcroinvestIO.Models;
using MIcroinvestIO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MIcroinvestIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly MultiContext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ICashBookService cashBookService;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;//?
        private readonly Database _dbSettings;
        public IPaymentService paymentService;
        private List<Payment> payments;
        private List<CashBook> records;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _httpContextAccessor, MultiContext context, ICashBookService _cashBookService, IConfiguration configuration, IServiceProvider serviceProvider, Database dbSettings, IPaymentService _paymentService)
        {
            _logger = logger;
            httpContextAccessor = _httpContextAccessor;
            _context = context;
            cashBookService = _cashBookService;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _dbSettings = dbSettings;
            paymentService = _paymentService;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection").Split(';');

            // Pass it to the view using ViewBag
            ViewBag.ConnectionString = $"{connectionString[0]}, {connectionString[1]}";
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
            var filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");/// !!!Change it in final project to work!!!
            List<string> json = System.IO.File.ReadAllLines(filePath).ToList();
            json.RemoveAt(2);
            json.Insert(2, connectionString);
            System.IO.File.Delete(filePath);
            System.IO.File.AppendAllLines(filePath, json);
            string conString = $"server={dbData.Ip};Database={dbData.DatabaseName};User Id={dbData.User};Password={dbData.Password};encrypt=false;";

            //Update
            _dbSettings.Ip = dbData.Ip;
            _dbSettings.DatabaseName = dbData.DatabaseName;
            _dbSettings.User = dbData.User;
            _dbSettings.Password = dbData.Password;
            string newConnectionString = dbData.ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(newConnectionString))
                {

                    con.Open();
                    dbData.Success = "Success!";
                }
            }
            catch (Exception)
            {
                dbData.Success = "Fail!";
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
                var objects = _context.Objects.ToList();// Not good but I will fix it someday

                foreach (var record in records)
                {
                    result.Add(new CashBookViewModel
                    {
                        CashBook = record,
                        Object = objects.FirstOrDefault(objects => objects.Id == record.ObjectId).Name//Get the name of the city from Objects table
                    });

                }
                if (city != null && city != "Всички")
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
        public IActionResult Payments()
        {
            ViewBag.Paystatus = "Платени";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payments(DateTime? startDate, DateTime? endDate, string paystatus)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.Paystatus = paystatus;
            if (paystatus == "Платени")
            {
                payments = await paymentService.Paid();
            }
            else
            {
                payments = await paymentService.Unpaid();

            }
            payments = payments.Where(p => p.Date >= startDate && p.Date <= endDate).ToList();
            var result = new List<PaymentsViewModel>();
            foreach (var payment in payments)
            {
                result.Add(new PaymentsViewModel
                {
                    Acct = payment.Acct,
                    DateTime = payment.Date,
                    Qtty = payment.Qtty,
                    Partner = _context.Partners.First(p => p.Id == payment.PartnerId),
                    Payment = payment,
                    OperationType = _context.OperationTypes.First(o => o.Id == payment.OperType),
                    Object = _context.Objects.First(o => o.Id == payment.ObjectId)
                });
            }
            return View(result);
        }
        public IActionResult OperationDetails(string desc)
        {
            var operNumber = Regex.Match(desc, "(?<=No\\. )\\d+");
            int operationNumber = 0;
            if (operNumber.Success)
            {
                operationNumber = int.Parse(operNumber.Value);
            }
            var operations = _context.Operations.Where(o => o.Acct == operationNumber & o.OperType == 2).ToList();
            var goods = new List<Good>();
            foreach (var op in operations)
            {

                goods.Add(_context.Goods.FirstOrDefault(g => g.Id == op.GoodId));
            }
            var result = new OperationDetailsViewModel
            {
                Acct = operationNumber,
                goods = goods,
            };
            return PartialView("OperationDetails", result);
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
