using NttData.FileManagement.Common.Model;
using NttData.FileManagement.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.DataAccess.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        public bool Add(Student student)
        {
            string path = "..\\..\\..\\student.txt";
            
            using (FileStream aFile = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(student.Id + "," + student.Name + "," + student.Surname + "," + student.Birthday + "," + student.Age);
            }
            
            return File.Exists(path);
        }
    }
}
