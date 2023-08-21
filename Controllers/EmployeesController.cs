using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            //List<Employee> lstEmp = new List<Employee>();
            //lstEmp.Add(new Employee { EmpNo = 1, Name = "Kajal", Basic = 1000000, DeptNo = 30 });
            //lstEmp.Add(new Employee { EmpNo = 2, Name = "Kalyani", Basic = 1000, DeptNo = 10 });
            //lstEmp.Add(new Employee { EmpNo = 3, Name = "Kamlesh", Basic = 10000, DeptNo = 30 });
            //return View(lstEmp);

            List<Employee> lstEmp = Employee.GetAllEmployee();
            return View(lstEmp);

        }

        public ActionResult Show()
        {
            List<Employee> lstEmp = Employee.GetAllEmployee();
            return View(lstEmp);
        }
        



        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Kunal";
            //obj.Basic = 100000;
            //obj.DeptNo = 10;
            //return View(obj);

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //public ActionResult Create(Employee obj)
        public ActionResult Create(Employee obj,IFormCollection collection,string Name)
        {
            try
            {

                //string EmpNo = collection["EmpNo"];
                //string Name1 = collection["Name"];
                //string Basic = collection["Basic"];
                //string DeptNo = collection["DeptNo"];

                Employee.InsertEmployee(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(obj);
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Kunal";
            //obj.Basic = 100000;
            //obj.DeptNo = 10;
            //return View(obj);

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.UpdateEmployee(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Kunal";
            //obj.Basic = 100000;
            //obj.DeptNo = 10;
            //return View(obj);

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
