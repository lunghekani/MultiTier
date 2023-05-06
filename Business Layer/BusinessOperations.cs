using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace Business_Layer
{
    public class BusinessOperations
    {
       public List<User> LoadAllInfo()
        {
            DataOperations objData = new DataOperations();
            List<User> users = new List<User>();    


            var lstUsers = objData.ReadFromFile();

            foreach (var item in lstUsers)
            {
                var userDetails =item.Split(',');
                var loadedUser = new User()
                {
                    Id = userDetails[0],
                    FirstName = userDetails[1],
                    LastName = userDetails[2],
                    Email = userDetails[3],
                    Gender = userDetails[4],
                    IpAddress = userDetails[5]

                };  
                users.Add(loadedUser);
            }
            return users;
        }

        public void WriteToDB(string name, string lastName, string email, string gender, string IP)
        {
            var objData = new DataOperations();    

            var user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                Gender = gender,
                IpAddress = IP,
            };

            objData.WriteToFile(user.FirstName, user.LastName, user.Email, user.Gender,user.IpAddress);
        }
        public void UpdateCSV(string name, string lastName, string email, string gender, string IP)
        {
            var objData = new DataOperations();

            var user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                Gender = gender,
                IpAddress = IP,
            };

            objData.UpdateToFile(user.FirstName, user.LastName, user.Email, user.Gender, user.IpAddress);
        }
    }

    public class User
    {
        public User()
        {

        }
        // id,first_name,last_name,email,gender,ip_address

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IpAddress { get; set; }
    }
}
