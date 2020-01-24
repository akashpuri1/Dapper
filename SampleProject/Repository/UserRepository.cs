using DapperExtensions;
using Microsoft.Data.SqlClient;
using SampleProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Repository
{
    public class UserRepository : GenericRepository <Data>, IUserRepository
    {
        public Data CreateUser(Data userModel, string password)
        {
            var users = new Data();
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                connection.Open();

                Data data = new Data {
                Title = @userModel.Title,
                FirstName = @userModel.FirstName,
                LastName = @userModel.LastName,
                Email = @userModel.Email,
                Password = @userModel.Password };

                connection.Insert(data);
                connection.Close();
            }
            return users;
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                var users = connection.Delete(connection.Get<Data>(id));
            }
        }

        public Data EditUser(Data userModel)
        {
            var users = new Data();
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                connection.Open();
                int userId = @userModel.ID;
                Data data = connection.Get<Data>(userId);

                data.Title = @userModel.Title;
                data.FirstName = @userModel.FirstName;
                data.LastName = @userModel.LastName;
                data.Email = @userModel.Email;
                data.Password = @userModel.Password;

                connection.Update(data);
                connection.Close();
            }
            return users;
        }

        public Data GetUserById(int id)
        {
            var users = new Data();
            using (var connection = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                users = connection.Get<Data>(id);
            }
            return users;
        }

        public List<Data> GetUsers()
        {
            var users = new List<Data>();
            using (SqlConnection connection  = new SqlConnection("Data Source=PUNEET\\SQLEXPRESS;Initial Catalog=ReactiveForm;Integrated Security=True"))
            {
                connection.Open();
                users = connection.GetList<Data>().ToList();
                connection.Close();
            }
            return users;
        }
    }
}
