using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMSBusinessLib;
using HRMSEntitiesLib;

namespace HRMSMVCApp.Controllers
{
    public class HRMSController : Controller
    {
        // GET: HRMS
        public ActionResult Index()
        {
            //retrieve record using Business Layer
            BusinessLayer bll = new BusinessLayer();
            var lstEmps = bll.GetAllEmps()
                                .Select(o=>new HRMSMVCApp.Models.Employee 
                                {
                                    Ecode=o.Ecode,
                                    Ename=o.Ename,
                                    Salary=o.Salary,
                                    Deptid=o.Deptid
                                });

            return View(lstEmps);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //get all the deptid from DB using Business layer
            BusinessLayer bll = new BusinessLayer();
            var dids = bll.GetAllEmps()
                        .Select(o => o.Deptid)
                        .Distinct()
                        .Select(o => new SelectListItem
                        {
                            Text = o.ToString(),
                            Value = o.ToString()
                        }).ToList();

            //var selectItemDids = new List<SelectListItem>();
            //foreach (var item in dids)
            //{
            //    selectItemDids.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
            //}

            var emp = new Models.Employee
            {
                Deptids = dids
            };
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(Models.Employee emp)
        {
            var record = new HRMSEntitiesLib.Employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                Salary = emp.Salary,
                Deptid = emp.Deptid
            };

            //Insert using Business layer
            BusinessLayer bll = new BusinessLayer();
            bll.AddEmployee(record);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Delete using business layer
            BusinessLayer bll = new BusinessLayer();
            bll.DeleteEmployee(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            //get details of Employee using Business layer
            BusinessLayer bll = new BusinessLayer();
            var emp=bll.SelectEmpById(id);
            var record = new Models.Employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                Salary = emp.Salary,
                Deptid = emp.Deptid
            };
            return View(record);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //populate the deptid field
            BusinessLayer bll = new BusinessLayer();
            var dids = bll.GetAllEmps()
                        .Select(o => o.Deptid)
                        .Distinct()
                        .Select(o => new SelectListItem
                        {
                            Text = o.ToString(),
                            Value = o.ToString()
                        }).ToList();

            //Get the Employee record using Business Layer            
            var emp = bll.SelectEmpById(id);
            var record = new Models.Employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                Salary = emp.Salary,
                Deptid = emp.Deptid,
                Deptids = dids
            };
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Models.Employee emp)
        {
            var record = new HRMSEntitiesLib.Employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                Salary = emp.Salary,
                Deptid = emp.Deptid
            };

            //save to database using business layer
            BusinessLayer bll = new BusinessLayer();
            bll.UpdateEmployee(record);

            return RedirectToAction("Index");
        }
    }
}