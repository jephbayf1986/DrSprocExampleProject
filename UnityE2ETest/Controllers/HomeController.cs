using DALE2ETest.Models;
using DALE2ETest.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnityE2ETest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly ITransactionRepository _transactionRepo;

        public HomeController(IEmployeeRepository employeeRepo, IDepartmentRepository departmentRepo, ITransactionRepository transactionRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<ActionResult> Index()
        {
            var employees = await _employeeRepo.GetEmployees();

            return View(employees);
        }

        public ActionResult Departments()
        {
            var departments = _departmentRepo.GetDepartments();

            return View(departments);
        }

        public async Task<ActionResult> CreateRandomEmployee()
        {
            using (var transaction = _transactionRepo.GetTransaction())
            {
                var depo = new Department
                {
                    Name = ""
                };

                var newDepoartmentId = _departmentRepo.CreateDepartment(depo);

                var employee = new Employee
                {
                    Department = new Department
                    {
                        Id = newDepoartmentId,
                        Name = depo.Name,
                    }
                };
                
                var newEmployeeId = await _employeeRepo.CreateEmployee(employee, transaction);
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Employee(int employeeId)
        {
            var employee = await _employeeRepo.GetEmployee(employeeId);

            return View(employee);
        }
    }
}