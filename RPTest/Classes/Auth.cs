using RPTest.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using _db = RPTest.Models.DBModel;

namespace RPTest.Classes
{
    public class Auth
    {
       
         public bool AddSpecializtion(string name, string code, string qualification)
         {
             try
             {
                 Models.Specialty specialty = new Models.Specialty() { Name = name, Code = code, Qualification = qualification };
                 _db.GetContext().Specialty.Add(specialty);
                 _db.GetContext().SaveChanges();
                 return true;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
                 return false;
             }

         }

        public bool AddSkill(string name, int idDis)
        {
            try
            {
                Models.Skills skill = new Models.Skills() { Name = name, Id_Discipline = idDis };
                _db.GetContext().Skills.Add(skill);
                _db.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool RemoveSkill(string name)
        {
            try
            {
                Models.Skills skill = _db.GetContext().Skills.Where(s => s.Name == name).FirstOrDefault();
                _db.GetContext().Skills.Remove(skill);
                _db.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool RemoveSpecializtion(string code)
         {
             try
             {
                 Models.Specialty specialty = _db.GetContext().Specialty.Where(s => s.Code == code).FirstOrDefault();
                 _db.GetContext().Specialty.Remove(specialty);
                 _db.GetContext().SaveChanges();
                 return true;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
                 return false;
             }
         }

         public bool EditSpecializtion(string name, string code)
         {
             try
             {
                 Models.Specialty specialty = _db.GetContext().Specialty.Where(s => s.Name == name).FirstOrDefault();
                 _db.GetContext().Specialty.Remove(specialty);
                 specialty.Code = code;
                 _db.GetContext().Specialty.Add(specialty);
                 _db.GetContext().SaveChanges();
                 return true;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
                 return false;
             }
         }

    }
}
