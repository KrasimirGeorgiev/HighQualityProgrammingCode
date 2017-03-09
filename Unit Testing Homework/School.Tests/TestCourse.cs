namespace Telerik.Homeworks.HQC.UnitTesting.School.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.Homeworks.HQC.UnitTesting.School;

    [TestClass]
    public class TestCourse
    {
        private static List<Student> freeStudentsForSale = new List<Student>();

        private Course experimentalCourse = new Course("Experimental 00");

        private Random rnd = new Random();

        [ClassInitialize]
        public static void GenerateSomeFreeStudents(TestContext context) 
        {
            int count = Course.GetMaxStudentsCount() + 1;

            for (int i = 0; i < count; i++)
            {
                var freeStudent = new Student(string.Format("Slave Number {0}", i));
                freeStudentsForSale.Add(freeStudent);
            }
        }

        [TestCleanup]
        public void RemoveStudentsFromCourse()
        {
            this.experimentalCourse.RemoveAllStudents();
        }

        [TestMethod]
        public void Test_Should_Create_Course_With_Given_Title()
        {
            string title = "Driving Lessons";

            var drivingCourse = new Course(title);

            Assert.AreEqual(title, drivingCourse.Title, "Expected: DrivingCourse title to equal " + title);
        }

        [TestMethod]
        public void Test_Adding_30_Students_To_Empty_Course_Should_Add_30_Students()
        {
            Student[] students = freeStudentsForSale.GetRange(0, 30).ToArray();

            this.experimentalCourse.AddStudents(students);

            object[] courseEnlistedStudnets = this.experimentalCourse.GetEnlistedStudents();

            Assert.AreEqual(30, courseEnlistedStudnets.Length, "Expected: Course to have exactly 5 students enlisted");
        }

        [TestMethod]
        public void Test_Removing_5_Students_From_A_Full_Course_Should_Remove_5_Students()
        {
            Student[] students = freeStudentsForSale.GetRange(0, 30).ToArray();

            this.experimentalCourse.AddStudents(students);

            for (int i = 0; i < 5; i++)
            {
                this.experimentalCourse.RemoveStudents(students[i].ID);
            }

            Assert.AreEqual(25, this.experimentalCourse.GetEnlistedStudents().Length, "Expected: Enlisted students to equal 25 when 5 are removed");
        }

        [TestMethod]
        public void Test_Removing_Student_With_Given_ID_Should_Remove_It_From_The_Corse()
        {
            Student[] students = freeStudentsForSale.GetRange(0, 10).ToArray();

            int removeThisId = this.rnd.Next((int)students[0].ID, (int)students[9].ID);

            this.experimentalCourse.AddStudents(students);

            this.experimentalCourse.RemoveStudents((uint)removeThisId);

            var namesAndId = this.experimentalCourse.GetEnlistedStudents();

            for (int i = 0; i < namesAndId.Length; i++)
            {
                Assert.AreNotEqual(removeThisId, namesAndId[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Should_Throw_Adding_More_Than_MaxCount_Students_At_Once()
        {
            Student[] students = freeStudentsForSale.ToArray();

            this.experimentalCourse.AddStudents(students);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Test_Should_Throw_Adding_More_Than_MaxCount_Students_On_Portions()
        {
            Student[] studentsList1 = freeStudentsForSale.GetRange(0, 10).ToArray();

            Student[] studentList2 = freeStudentsForSale.GetRange(9, freeStudentsForSale.Count - 10).ToArray();

            this.experimentalCourse.AddStudents(studentsList1);

            this.experimentalCourse.AddStudents(studentList2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Should_Throw_Adding_The_Same_Student_Twice()
        {
            var student = freeStudentsForSale[7];

            this.experimentalCourse.AddStudents(student);
            this.experimentalCourse.AddStudents(student);
        }
    }
}
