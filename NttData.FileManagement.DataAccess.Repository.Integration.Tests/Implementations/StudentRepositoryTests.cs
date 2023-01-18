using Microsoft.VisualStudio.TestTools.UnitTesting;
using NttData.FileManagement.Common.Model;
using NttData.FileManagement.DataAccess.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttData.FileManagement.DataAccess.Repository.Implementations.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Student createdStudent = new Student()
            {
                Id = 1,
                Name = "Juan",
                Surname = "Jimenez",
                Birthday = DateTime.ParseExact("10/10/2000", "dd/MM/yyyy", null),
                Age = 22
            };

            var path = @ConfigurationManager.AppSettings.Get("StudentsFilePath");

            //Se puede hacer todo en un solo using con C# 8

            StudentRepository studentRepository = new StudentRepository();
            studentRepository.Add(createdStudent);

            Student studentFromFile = GetStudent(path);

            DeleteStudentsFile(path);

            Assert.AreEqual(createdStudent, studentFromFile);
        }

        private Student GetStudent(string path)
        {
            Student student = new Student();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                if ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    student = new Student()
                    {
                        Id = int.Parse(data[0]),
                        Name = data[1],
                        Surname = data[2],
                        Birthday = DateTime.ParseExact(data[3], "dd/MM/yyyy", null),
                        Age = int.Parse(data[4])
                    };
                }
            }

            return student;
        }

        private void DeleteStudentsFile(string path)
        {
            File.Delete(path);
        }
    }
}