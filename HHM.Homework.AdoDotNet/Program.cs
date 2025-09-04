using HHM.Homework.AdoDotNet;

AppDbContext db = new AppDbContext();
List<StudentDto> lst = db.StudentResult.ToList();
foreach(var item in lst)
{
    Console.WriteLine($"{item.StudentNo} - {item.StudentName}");
}
StudentDto student = new StudentDto();
{
    String StudentNo = "S001";
    String StudentName = "Phyu";
    String FatherName = "U Kaung";
    String Gender = "Female";
    String Adderss = "Natmauk";
    String Result = "Pass";
};
db.StudentResult.Add(student);
int result = db.SaveChanges();

StudentDto editStudent = db.StudentResult.Where(x => x.StudentId == 5).FirstOrDefault();
if (editStudent != null)
{
    editStudent.StudentName = "Moe";
    db.SaveChanges();
}

StudentDto removeStudent = db.StudentResult.Where(x => x. StudentId == 3).FirstOrDefault();
if (removeStudent != null)
{
   db.StudentResult.Remove(student);
    db.SaveChanges();
}
    Console.ReadLine();
