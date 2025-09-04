using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HHM.Homework.AdoDotNet
{
    public class StudentResult
    {
        public int StudentId { get; set; }
        public string StudentNo { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string FatherName {  get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public DateTime DateOfBirth {  get; set; }
        public string Address {  get; set; }
        public string Result {  get; set; }
        public bool Deleteflag {  get; set; }

        // CREATE TABLE[dbo].[Tbl_StudentResult]
        (
        
            [StudentId][int] IDENTITY(1,1) NOT NULL,
        
            [StudentNo] [varchar] (50) NOT NULL,
        
            [StudentName] [varchar] (50) NOT NULL,
        
            [FatherName] [varchar] (50) NOT NULL,
        
            [Gender] [varchar] (50) NOT NULL,
        
            [DateOfBirth] [varchar] (50) NOT NULL,
        
            [Adderss] [varchar] (50) NOT NULL,
        
            [Result] [varchar] (50) NOT NULL,
        
            [DeleteFlag] [bit]
        NOT NULL,
         CONSTRAINT[PK_Tbl_StudentResult] PRIMARY KEY CLUSTERED
        (
            [StudentId] ASC
        )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
internal static bool DeleteFlag;
    }
}
