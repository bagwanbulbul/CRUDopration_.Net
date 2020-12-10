using Microsoft.AspNetCore.Mvc;
using System;
using BizStudent.Helper;
using BizStudent.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOpration.Models;

namespace CrudOpration.Controllers
{
    public class StudentController : Controller
    {
        public List<StudentModel> GetAllStudent()
        {
            BizStudentHelper bizObj = new BizStudentHelper();
            List<BizStudentModel> data = bizObj.BizGetStudent();
            List<StudentModel> stdList = new List<StudentModel>();
            foreach (BizStudentModel item in data)
            {
                StudentModel stdObj = new StudentModel();
                stdObj.Id = item.Id;
                stdObj.Name = item.Name;
                stdObj.Email = item.Email;
                stdObj.Class = item.Class;
                stdList.Add(stdObj);
            }
            return stdList;
        }

        [HttpGet]
        public IActionResult allStudent()
        {
            ViewBag.Data = GetAllStudent();
            return View();
        }

        [HttpPost]
        public IActionResult allStudent(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                BizStudentHelper bizObj = new BizStudentHelper();
                bizObj.BizAddStudent(model.Name, model.Email, model.Class);
                ViewBag.Data = GetAllStudent();
                return View("allStudent", new StudentModel());
            }
            else
            {
                ViewBag.Data = GetAllStudent();
                return View("allStudent", model);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<StudentModel> alldata = GetAllStudent();
            StudentModel myModel = new StudentModel();
            foreach (StudentModel item in alldata)
            {
                if (item.Id == id)
                {
                    myModel.Id = item.Id;
                    myModel.Name = item.Name;
                    myModel.Email = item.Email;
                    myModel.Class = item.Class;
                }
            }
            ViewBag.data = GetAllStudent();
            return View("allStudent", myModel);
        }

        [HttpPost]
        public IActionResult update(StudentModel model, int id)
        {
            if (ModelState.IsValid)
            {
                BizStudentHelper HObj = new BizStudentHelper();
                BizStudentModel bizObj = new BizStudentModel();
                bizObj.Id = id;
                bizObj.Name = model.Name;
                bizObj.Email = model.Email;
                bizObj.Class = model.Class;
                HObj.BizUpdateById(bizObj, id);
                ViewBag.Data = GetAllStudent();
                return RedirectToAction("allStudent", new StudentModel());
            }
            else
            {
                ViewBag.Data = GetAllStudent();
                return View("allStudent", model);
            }
        }

        [HttpGet]
        public IActionResult delete(int id)
        {
            BizStudentHelper HObj = new BizStudentHelper();
            HObj.DeleteById(id);
            ViewBag.data = GetAllStudent();
            return RedirectToAction("allStudent", new StudentModel());
        }
    }
}
