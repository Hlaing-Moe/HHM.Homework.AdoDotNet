using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHM.Homework.AdoDotNet
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "HHM.Homework.AdoDotNet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            var query = db.Query<StudentResult>("select * from Tbl-StudentResult");
            List<StudentResult> lst = query.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                StudentResult item = lst[i];
                Console.WriteLine($"{i + 1} {item.StudentNo} - {item.StudentName}");
            }
        }

        public void Create()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute("INSERT INTO[dbo].[Tbl_StudentResult]\r\n            ([StudentNo]\r\n           , [StudentName]\r\n           , [FatherName]\r\n           , [Gender]\r\n           , [DateOfBirth]\r\n           , [Address]\r\n           , [Result]\r\n           , [DeleteFlag])\r\n     VALUES\r\n           ('S001'\r\n           , 'Phyu'\r\n           , 'U Kaung'\r\n           , 'Female'\r\n           , 'Natmauk'\r\n           , 'Pass'\r\n           , '0'\r\n           \r\n           )\";\r\n                SqlCommand cmd = new SqlCommand(queryCreate, connection);\r\n                int result = cmd.ExecuteNonQuery();\r\n\r\n                string message = result > 0 ? \"Created Successful\" : \"failed to Create\";\r\n                Console.WriteLine(message);\r\n            }");
        }

        public void Update()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute(" @\"UPDATE[dbo].[Tbl_StudentResult]\r\n                   SET[StudentName] = 'Hsu'\r\n                   WHERE StudentId = 1\";\r\n\r\n                SqlCommand cmd = new SqlCommand(query, connection);\r\n                int result = cmd.ExecuteNonQuery();\r\n\r\n                string message = result > 0 ? \"Successful Update\" : \"failed Update\";\r\n                Console.WriteLine(message);");
        }

        public void Delete()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute("@\"UPDATE[dbo].[Tbl_StudentResult]\r\n                    SET [DeleteFlag] = 1\r\n                    WHERE StudentId = 1\";\r\n                SqlCommand cmd = new SqlCommand(query, connection);\r\n                int result = cmd.ExecuteNonQuery();\r\n                string message = result > 0 ? \"Deleting Successful\" : \"Deleting failed.\";\r\n                Console.WriteLine(message);");
        }
    }    
}
