namespace Telerik.Homeworks.HQC.UnitTesting.School.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.Homeworks.HQC.UnitTesting.School;

    [TestClass]
    public class TestStudent
    {
        private List<Student> students = new List<Student>();

        private Random rnd = new Random();

        [TestCleanup]
        public void CleanUpList()
        {
            this.students.Clear();
            Student.FreeAllStudents();
        }

        [TestMethod]
        public void Test_Should_Create_Student_With_Given_Name()
        {
            string name = "Arnold";

            var testVolunteer001 = new Student(name);
            this.students.Add(testVolunteer001);

            Assert.AreEqual(name, testVolunteer001.Name, "Expected: testVolunteer003 Name to equal: " + name);
        }

        [TestMethod]
        public void Test_Should_Create_Student_With_LowestId_Value()
        {
            uint idMinValue = Student.GetMinIdValue();

            var testVolunteer001 = new Student("Ceco");
            this.students.Add(testVolunteer001);

            Assert.IsTrue(testVolunteer001.ID == idMinValue, "Expected: The first instance of a student to have the lowest possible ID");
        }

        [TestMethod]
        public void Test_Student_Should_Have_An_ID_Within_Allowed_Range()
        {
            var testVolunteer001 = new Student("Ceco");
            this.students.Add(testVolunteer001);

            uint maxValue = Student.GetMaxIdValue();
            uint minValue = Student.GetMinIdValue();

            Assert.IsTrue(
                (minValue <= testVolunteer001.ID) && (testVolunteer001.ID <= maxValue),
                "Expected: Student Id to be within the allowed range");
        }

        [TestMethod]
        public void Test_Should_Create_2_Students_With_DifferentIDs()
        {
            var testVolunteer002 = new Student("Ivan");
            var testVolunteer003 = new Student("John");

            this.students.Add(testVolunteer002);
            this.students.Add(testVolunteer003);

            Assert.AreNotEqual(testVolunteer002.ID, testVolunteer003.ID, "Expected: Students to have different IDs");
        }

        [TestMethod]
        public void Test_Should_Dispose_Of_All_Student_Instances()
        {
            int instancesCount = 10;

            for (int i = 0; i < instancesCount; i++)
            {
                var currentTestCandidate = new Student(string.Format("Test Candidate {0}", i));
                this.students.Add(currentTestCandidate);
            }

            Student.FreeAllStudents();

            foreach (var student in this.students)
            {
                Assert.IsTrue(student.Disposed, "Expected: All created students to be disposed and each property disposed to equal true");
            }
        }

        [TestMethod]
        public void Test_Should_Create_Max_Student_Instances_Without_An_Error()
        {
            uint instancesCount = (Student.GetMaxIdValue() - Student.GetMinIdValue()) + 1; // Inclusive

            for (int i = 0; i < instancesCount; i++)
            {
                var currentStudent = new Student(string.Format("Test Candidate {0}", i));
                this.students.Add(currentStudent);
            }
        }

        [TestMethod]
        public void Test_Should_Create_Max_Student_Instances_With_Unique_IDs()
        {
            // Inclusive
            uint instancesCount = (Student.GetMaxIdValue() - Student.GetMinIdValue()) + 1; 

            var uniqueIDs = new HashSet<uint>();

            for (int i = 0; i < instancesCount; i++)
            {
                var currentStudent = new Student(string.Format("Test Candidate {0}", i));
                this.students.Add(currentStudent);

                uniqueIDs.Add(currentStudent.ID);
            }

            Assert.AreEqual(this.students.Count, uniqueIDs.Count, "Expected: uniqueIDs count to be equal to students count");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Should_Throw_If_Student_Name_Is_Null()
        {
            var testVolunteer001 = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Should_Throw_When_Creating_More_Than_MaxIdCount_Instances()
        {
            uint instancesCount = Student.GetMaxIdValue() + 1;

            for (int i = 0; i < instancesCount; i++)
            {
                var currentStudent = new Student(string.Format("Test Candidate {0}", i));
                this.students.Add(currentStudent);
            }
        }

        [TestMethod]
        public void Test_Student_ID_Should_Return_Uint_Within_Range()
        {
            uint maxAllowedValue = Student.GetMaxIdValue();
            uint minAllowedValue = Student.GetMinIdValue();

            uint instancesCount = (maxAllowedValue - minAllowedValue) + 1; // Inclusive

            for (int i = 0; i < instancesCount; i++)
            {
                var currentStudent = new Student(string.Format("Test Candidate {0}", i));
                this.students.Add(currentStudent);
            }

            uint pickedStudentId = this.students[this.rnd.Next((int)minAllowedValue, (int)maxAllowedValue)].ID;

            bool isWithinRange = minAllowedValue <= pickedStudentId && pickedStudentId <= maxAllowedValue;

            Assert.IsTrue(isWithinRange, "Expected: The Selected Id to be within the Allowed Range. Selected ID: " + pickedStudentId);
        }
    }
}
