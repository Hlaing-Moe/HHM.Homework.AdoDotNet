using Dapper;
using HHM.Homework.AdoDotNet;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
{
    DataSource = ".",
    InitialCatalog = "HHM.Homework.AdoDotNet",
    UserID = "sa",
    Password = "sasa@123",
    TrustServerCertificate = true
};

using IDbConnection db = new SqlConnection(sb.ConnectionString);
db.Open();
var query = db.Query<StudentResult>("select * from Tbl-StudentResult");
List<StudentResult> lst  = query.ToList();
for (int i = 0; i < lst.Count; i++)
{
    StudentResult item = lst[i];
    Console.WriteLine($"{i + 1} {item.StudentNo} - {item.StudentName}");
}
int no = 0;
foreach (StudentResult item in lst)
{
    Console.WriteLine($"{no + 1} {item.StudentNo} - {item.StudentName}");
    no++;
}

Console.ReadLine();









