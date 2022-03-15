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
        public string Login(string log, string pass)
        {
            Auth auth = new Auth();
            try
            {
                var users = _db.GetContext().Users;
                foreach (Models.Users u in users)
                {
                    if (log == u.Log && pass == u.Pass)
                    {
                        return "true";
                    }
                }
                return "false";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }

        }

        public string Registration(string log, string pass, string email)
        {
            Auth auth = new Auth();
            try
            {
                if (log != "" && pass != "" && email != "")
                {
                    var users = _db.GetContext().Users;
                    bool access = false;
                    foreach (Models.Users u in users)
                    {
                        if (log == u.Log)
                        {
                            access = true;
                        }
                    }
                    if (access == false)
                    {
                        Models.Users user = new Models.Users() { Log = log, Pass = pass, Email = email, Role = "User" };
                        _db.GetContext().Users.Add(user);
                        _db.GetContext().SaveChanges();
                        MessageBox.Show("Успешная регистрация!");
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                else return "empty";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "false";
            }
        }

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
