using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace HHM.Homework.AdoDotNet
{
    public class AdoDotNetService
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "HHM.Homework.AdoDotNet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string queryRead = @"SELECT[StudentId]
                              ,[StudentNo]
                              ,[StudentName]
                              ,[FatherName]
                              ,[Gender]
                              ,[DateOfBirth]
                              ,[Address]
                              ,[Result]
                              ,[DeleteFlag]
                         FROM[dbo].[Tbl_StudentResult]";
                SqlCommand cmd = new SqlCommand(queryRead, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string no = dr["StudentNo"].ToString();
                    string name = dr["StudentName"].ToString();
                    Console.WriteLine($"{i + 1} {no} - {name}");
                }
                connection.Close();
            }
        }
        public void Create()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();

                string queryCreate = @"INSERT INTO[dbo].[Tbl_StudentResult]
            ([StudentNo]
           , [StudentName]
           , [FatherName]
           , [Gender]
           , [DateOfBirth]
           , [Address]
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
                SqlCommand cmd = new SqlCommand(queryCreate, connection);
                int result = cmd.ExecuteNonQuery();

                string message = result > 0 ? "Created Successful" : "failed to Create";
                Console.WriteLine(message);
                connection.Close();
            }

        }
        public void Update()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();

                string query = @"UPDATE[dbo].[Tbl_StudentResult]
                   SET[StudentName] = 'Hsu'
                   WHERE StudentId = 1";

                SqlCommand cmd = new SqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();

                string message = result > 0 ? "Successful Update" : "failed Update";
                Console.WriteLine(message);

                connection.Close();
            }
        }

        public void Delete()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string query = @"UPDATE[dbo].[Tbl_StudentResult]
                    SET [DeleteFlag] = 1
                    WHERE StudentId = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Deleting Successful" : "Deleting failed.";
                Console.WriteLine(message);
                connection.Close();


            }


        }

    }
}

