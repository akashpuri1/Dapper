using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SampleProject.Models;

namespace SampleProject.Services
{
    public class UserServices : IUserServices
    {
        public User CreateUser(User userModel, string password)
        {
            string sql = string.Format("INSERT INTO Data (Title,FirstName,LastName,Email,Password) Values ('{0}','{1}','{2}','{3}','{4}')",
               @userModel.Title,@userModel.FirstName, @userModel.LastName, @userModel.Email, @userModel.Password);

            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {

                connection.Open();

                var affectedRows = connection.Execute(sql, userModel);
            }

            return userModel;

        }

        public void DeleteUser(int id)
        {
            string sql = "Delete FROM Data where ID=" + id;
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                var users = connection.Query<User>(sql).FirstOrDefault();
            }
        }

        public User EditUser(User userModel)
        {
            string sql = string.Format("Update Data SET Title='{1}',FirstName='{2}',LastName='{3}',Email='{4}',Password='{5}' where ID= {0}",
               @userModel.ID, @userModel.Title, @userModel.FirstName, @userModel.LastName, @userModel.Email, @userModel.Password);

            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                connection.Open();

                var affectedRows = connection.Execute(sql, userModel);
            }
            return userModel;
        }

        public User GetUserById(int id)
        {
            string sql = "SELECT * FROM Data where ID=" +id;
            var users = new User();
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                users = connection.Query<User>(sql).FirstOrDefault();
            }

            return users;
        }

        public List<User> GetUsers()
        {
            string sql = "SELECT * FROM Data";
            var users = new List<User>();
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                 users = connection.Query<User>(sql).ToList();
            }

            return users;
        }
    }
}
