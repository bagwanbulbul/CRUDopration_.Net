using DtStudent.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Text;

namespace DtStudent.Helper
{
    public class DtStudentHelper
    {

        public string connString = "Server=DESKTOP-EU7KMUI;Database=StudentPortal;Integrated Security=yes;Uid=auth_windows;";

        public List<DtStudentModel> GetStudent()
        {
            List<DtStudentModel> MyList = new List<DtStudentModel>();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetAllStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                DtStudentModel obj = new DtStudentModel();
                obj.Id = Convert.ToInt32(data["Id"].ToString());
                obj.Name = data["Name"].ToString();
                obj.Email = data["Email"].ToString();
                obj.Class = data["Class"].ToString();
                
                MyList.Add(obj);
            }
            conn.Close();
            return MyList;
        }

       

        public bool AddStudent(string name,string email, string class1)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddStudent", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Class", class1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public bool UpdateById(DtStudentModel model,int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateById", conn);
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Class1", model.Class);
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        public bool DeleteById(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteById", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
    }
}
