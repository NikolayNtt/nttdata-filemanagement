using NttData.FileManagement.Business.Logic.Contracts;
using NttData.FileManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.Business.Logic.Implementations
{
    public class StudentService : IStudentService
    {
        public bool Add(Student student)
        {
            student.Age = CalculateAge(student.Birthday);

            return false;
        }

        private int CalculateAge(DateTime birthday)
        {
            var days = (DateTime.Now - birthday).TotalDays;

            return (int)Math.Floor(days / 365);
        }
    }
}
