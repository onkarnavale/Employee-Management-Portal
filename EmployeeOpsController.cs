using Microsoft.AspNetCore.Mvc;
using Mini_project.Models;

namespace Mini_project.Controllers
{
    public class EmployeeOpsController : Controller
    {
        EmployeeOperations op = new EmployeeOperations();

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add(Models.Employee e)
        {
            if (ModelState.IsValid)
            {
                int res = op.createNewEmployee(e);

                if(res > 0)
                {
                    ViewBag.msg = "Employee details saved successfuly";

                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Employee details cannot be saved, plese check and enter valid details";
                }
            }
            return View();
        }

        public IActionResult show()
        {
            List<Models.Employee> lis = op.readAllEmployee();

            return View(lis);
        }


        public IActionResult delete(int id)
        {
            Models.Employee emp = op.FindEmployee(id);
            
            return View(emp);
        }

        [HttpPost]
        public IActionResult delete(int id, int temp)
        {
            Models.Employee emp = op.FindEmployee(id);
            
            int res = op.deleteEmployee(emp.eid);

            if (emp != null)
            {
                if (res > 0)
                {
                    ViewBag.msg = "Employee Deleted successfuly";

                    ModelState.Clear();
                }
            }
         
            else
            {
                ViewBag.msg = "Employee not found";
            }
            return View();
        }


        
        public IActionResult update(int id)
        {
            Models.Employee emp = op.FindEmployee(id);

            return View(emp);
        }

        [HttpPost]
        public IActionResult update(int id, int temp)
        {
            Models.Employee emp = op.FindEmployee(id);

            int res = op.updateEmployee(emp.eid);

            if (res > 0)
            {
                ViewBag.msg = "Employee updated successfuly";

                ModelState.Clear();
            }
            else
            {
                ViewBag.msg = "Employee not found";
            }

            return View();
        }
    }
}
