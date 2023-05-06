using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // use this to conduct operations on a file
namespace Data_Layer
{
    public class DataOperations
    {
        private static string filePath = "./MOCK_DATA.csv";
        public static  List<string> lstResults = new List<string>();
        private static string exportFile = "./export.txt";
       public  List<string> ReadFromFile()
        {
            using (var sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                   string line = sr.ReadLine();
                   lstResults.Add(line);
                }
            }
            return lstResults;
       }

        public  void WriteToFile(string name, string lastName, string email, string gender, string IP)
        {
            using (var sw = new StreamWriter(exportFile))
            {
               sw.WriteLine($"Name: {name} LastName: {lastName} Email: {email} Gender: {gender} IP-Addr {IP} ");
            }
        }

        public  void UpdateToFile(string name, string lastName, string email, string gender, string IP)
        {
            Random random = new Random();
            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{ random.Next(1000,2000) },{name}, {lastName},{email},{gender}, {IP} ");
            }
        }

        public static void DeleteRecord(List<string> users)
        {
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var item in users)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }


    public class User
    {
        public User()
        {
            IpAddress = "150.106.5.10";
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
