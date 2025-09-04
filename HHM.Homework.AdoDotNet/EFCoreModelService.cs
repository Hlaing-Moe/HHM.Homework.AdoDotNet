using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHM.Homework.AdoDotNet
{
    internal class EFCoreModelService
    {
        AppDbContext db = new AppDbContext();

        public void Read()
        {
            List<StudentDto> lst = db.StudentResult.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine($"{item.StudentNo} - {item.StudentName}");
            }
        }
        public void Create()
        {
            StudentDto student = new StudentDto();
            {
                String StudentNo = "S005";
                String StudentName = "Phyu";
                String FatherName = "U Kaung";
                String Gender = "Male";
                String Adderss = "Natmauk";
                String Result = "Pass";
            };
            if (student != null)
            {
                db.StudentResult.Add(student);
                int result = db.SaveChanges();
                string message = result > 0 ? "Create Successful!" : "Create Failed!";
                Console.WriteLine(message);
            }
        }
        public void Update()
        {
            StudentDto? editStudent = db.StudentResult.Where(x => x.StudentId == 5).FirstOrDefault();
            if (editStudent != null)
            {
                editStudent.Gender = "Male";
                int result = db.SaveChanges();
                String message = result > 0 ? "Update successful!" : "Update failed!";
                Console.WriteLine(message);

            }
        }
        public void Delete()
        {
            StudentDto? removeStudent = db.StudentResult.Where(x => x.StudentId == 3).FirstOrDefault();
            if (removeStudent != null)
            {
                StudentResult.DeleteFlag = true;
                db.SaveChanges();
                int result = db.SaveChanges();
                String message = result > 0 ? "Update successful!" : "Update failed!";
                Console.WriteLine(message);
            }
        }
    }
}
