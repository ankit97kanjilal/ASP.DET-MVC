using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHelloWorld.Models;

namespace MVCHelloWorld.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        //default action method is index
        public ActionResult Index() 
        {
            return View();
        }
        //Manually done
        public ActionResult GetData()
        {
            Employee emp = new Employee
            {
                Ecode = 101,
                Ename = "Ravi",
                Salary = 1111,
                Deptid = 201
            };
            return View(emp);
        }
        public ActionResult GetEmpData()
        {
            Employee emp = new Employee
            {
                Ecode = 101,
                Ename = "Ravi",
                Salary = 1111,
                Deptid = 201
            };
            return View(emp);
        }
        //Manually done
        public ActionResult GetAllEmps()
        {
            var lstEmps = new List<Employee>
            {
                new Employee{Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
                new Employee{Ecode=102,Ename="Raman",Salary=2222,Deptid=201},
                new Employee{Ecode=103,Ename="Raja",Salary=3333,Deptid=202},
                new Employee{Ecode=104,Ename="Ramu",Salary=4444,Deptid=202},
                new Employee{Ecode=105,Ename="Ram",Salary=5555,Deptid=203},
            };

            return View(lstEmps);
        }
        public ActionResult GetEmps()
        {
            var lstEmps = new List<Employee>
            {
                new Employee{Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
                new Employee{Ecode=102,Ename="Raman",Salary=2222,Deptid=201},
                new Employee{Ecode=103,Ename="Raja",Salary=3333,Deptid=202},
                new Employee{Ecode=104,Ename="Ramu",Salary=4444,Deptid=202},
                new Employee{Ecode=105,Ename="Ram",Salary=5555,Deptid=203},
            };

            return View(lstEmps);
        }
        public ActionResult Create()
        {
            //Employee emp = new Employee(); no need to pass here
            return View();
        }

        public ActionResult FormWT()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FormST()
        {
            Registration reg = new Registration
            {
                Hobbies = new List<Hobby>
                {
                    new Hobby { IsSelected = false, HobbyType = "painting" },
                    new Hobby { IsSelected = false, HobbyType = "dancing" },
                    new Hobby { IsSelected = true, HobbyType = "singing" },
                },
                Cities = new List<SelectListItem>
                { 
                    new SelectListItem{Text="Bangalore",Value="BLR"},
                    new SelectListItem{Text="Chennai",Value="CHN"},
                    new SelectListItem{Text="Delhi",Value="DLI"},
                    new SelectListItem{Text="Hyderabad",Value="HYD"},
                    new SelectListItem{Text="Jaipur",Value="JPR"}
                },
            };

            return View(reg);
        }
        [HttpPost]
        public ActionResult FormST(Registration reg)
        {
            return RedirectToAction("Index");
        }
    }
}