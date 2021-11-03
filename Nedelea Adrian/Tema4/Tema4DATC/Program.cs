using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;
namespace Tema4DATC
{
    class Program
    {
        private static CloudTableClient tableClient;

        private static CloudTable studentsTable;
        static void Main(string[] args)
        {
            Task.Run(async () => { await Initialize(); })
            .GetAwaiter()
            .GetResult();
        }
        static async Task Initialize()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=azuretema4datc;AccountKey=FKMuF3LQXB4w5uRWo2shWeSjsiosE+EB+QJFl3npGJc2FmNGMdwou/Hr/pDIo3mYGlhC5Tdypc1fB5D38xq8uA==;EndpointSuffix=core.windows.net";



            var account = CloudStorageAccount.Parse(storageConnectionString);
            tableClient = account.CreateCloudTableClient();

            studentsTable = tableClient.GetTableReference("studenti");
            await studentsTable.CreateIfNotExistsAsync();
            await AddNewStudent();
        }

        private static async Task AddNewStudent()
        {
            var student = new StudentEntity("UVT", "1990708353456");
            student.FirstName = "Daniel";
            student.LastName = "Dan";
            student.Email = "daniel.dan@gmail.com";
            student.Year = "3";
            student.PhoneNumber = "0765432158";
            student.Faculty = "FEEA";
            var insertOperation = TableOperation.Insert(student);
            await studentsTable.ExecuteAsync(insertOperation);
        }
    }
}
