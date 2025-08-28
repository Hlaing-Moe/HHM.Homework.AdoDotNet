using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HHM.Homework.AdoDotNet. ConsoleApp
{
    public class AdoDotNetServices
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "HHM.Homework.AdoDotNet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
           string query = @"SELECT[StudentId]
                              ,[StudentNo]
                              ,[StudentName]
                              ,[FatherName]
                              ,[Gender]
                              ,[DateOfBirth]
                              ,[Adderss]
                              ,[Result]
                              ,[DeleteFlag]
                         FROM[dbo].[Tbl_StudentResult]";// read the date from the table
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                Console.WriteLine($"{dataRow["StudentId"]} {dataRow["StudentNo"]} {dataRow["StudentName"]}");
            }
            #endregion
        }
        public void Create()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open(); 
            string query = @"INSERT INTO[dbo].[Tbl_StudentResult]
            ([StudentNo]
           , [StudentName]
           , [FatherName]
           , [Gender]
           , [DateOfBirth]
           , [Adderss]
           , [Result]
           , [DeleteFlag])
     VALUES
           ('S001'
           , 'Phyu'
           , 'U Kaung'
           , 'Female'
           , 'Natmauk'
           , 'Pass'
           , '0'
           
           )";
                SqlCommand cmd = new SqlCommand (query, sqlConnection);
            int row = cmd.ExecuteNonQuery();
            string message = row > 0 ? $"{row} rows affected." : "insterting failed";
            Console.WriteLine(message);
            sqlConnection.Close ();
            #endregion
        }
        public void Update()
        {
            #region
            SqlConnection sqlconnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlconnection.Open();
            string query = @"UPDATE[dbo].[Tbl_StudentResult]
                   SET[StudentName] = 'Hsu'
                   WHERE StudentId = 1";
            SqlCommand cmd = new SqlCommand(query, sqlconnection);
            int row = cmd.ExecuteNonQuery();
            string message = row > 0 ? $"{row} rows affected." : "updating failed";
            Console.WriteLine(message);
            sqlconnection.Close ();
            #endregion
        }
        public void Delete()
        {
            #region
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE[dbo].[Tbl_StudentResult]
                    SET [DeleteFlag] = 1
                    WHERE StudentId = 1";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int row = cmd.ExecuteNonQuery();
            string message = row > 0 ? $"{row} rows affecred." : "deleting failed";
            Console.WriteLine(message);
            sqlConnection.Close();
            #endregion


        }


    }

}

