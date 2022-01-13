using DrSprocExample.DAL.Models;
using DrSprocExample.DAL.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnityE2ETest.Helpers;

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
                    Name = RandomHelper.RandomString()
                };

                var newDepoartmentId = _departmentRepo.CreateDepartment(depo, transaction);

                var employee = new Employee
                {
                    FirstName = RandomHelper.RandomString(),
                    LastName = RandomHelper.RandomString(),
                    DateOfBirth = RandomHelper.DateInPast(10000),
                    Department = new Department
                    {
                        Id = newDepoartmentId,
                        Name = depo.Name,
                    }
                };
                
                await _employeeRepo.CreateEmployee(employee, transaction);

                transaction.Commit();
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdateEmployeeRandomly(int employeeId)
        {
            var existing = await _employeeRepo.GetEmployee(employeeId);

            var updated = new Employee
            {
                Id = employeeId,
                FirstName = RandomHelper.RandomString(),
                LastName = RandomHelper.RandomString(),
                DateOfBirth = RandomHelper.DateInPast(10000),
                Department = existing.Department
            };

            await _employeeRepo.UpdateEmployee(updated);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateDepartmentRandomly(int departmentId)
        {
            var updated = new Department
            {
                Id = departmentId,
                Name = RandomHelper.RandomString()
            };

            _departmentRepo.UpdateDepartment(updated);

            return RedirectToAction("Departments");
        }
    }
}