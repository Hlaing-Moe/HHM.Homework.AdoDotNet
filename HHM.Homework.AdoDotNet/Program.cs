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
List<StudentResult> lst  = db.Query<StudentResult>("select * from tbl-StudentResult");








