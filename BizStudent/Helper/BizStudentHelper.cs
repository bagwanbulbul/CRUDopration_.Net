using System;
using System.Collections.Generic;
using System.Text;
using DtStudent.Helper;
using DtStudent.Model;
using BizStudent.Model;

namespace BizStudent.Helper
{
    public class BizStudentHelper
    {
        public List<BizStudentModel> BizGetStudent()
        {
            DtStudentHelper obj = new DtStudentHelper();
            List<DtStudentModel> BizList = obj.GetStudent();
            List<BizStudentModel> IList = new List<BizStudentModel>();
            foreach (DtStudentModel item in BizList)
            {
                BizStudentModel bObj = new BizStudentModel();
                bObj.Name = item.Name;
                bObj.Id = item.Id;
                bObj.Email = item.Email;
                bObj.Class = item.Class;
                
                IList.Add(bObj);
            }
            return IList;
        }

        public bool BizAddStudent(string name, string email,string class1)
        {
            DtStudentHelper obj = new DtStudentHelper();
            return obj.AddStudent(name, email, class1);
        }

        public bool BizUpdateById(BizStudentModel model, int id)
        {
            DtStudentHelper Hobj = new DtStudentHelper();
            DtStudentModel obj = new DtStudentModel();
            obj.Class = model.Class;
            obj.Name = model.Name;
            obj.Email = model.Email;
            return Hobj.UpdateById(obj, id);
        }

        public bool DeleteById(int id)
        {
            DtStudentHelper Hobj = new DtStudentHelper();
            return Hobj.DeleteById(id);
        }
    }
}
