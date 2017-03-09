namespace Telerik.Homeworks.HQC.UnitTesting.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private const int MaxStudentsCount = 30;

        private List<Student> enlistedStudents = new List<Student>();

        private string title;

        public Course(string title)
        {
            this.Title = title;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Course title cannot be null");
                }

                this.title = value;
            }
        }

        public static int GetMaxStudentsCount()
        {
            return MaxStudentsCount;
        }

        public void AddStudents(params Student[] students)
        {
            if (students.Length > MaxStudentsCount)
            {
                throw new ArgumentOutOfRangeException("AddStudents received too large count of students");
            }

            if (students.Length == 0)
            {
                throw new ArgumentOutOfRangeException("AddStudents received no students");
            }

            if (students.Length + this.enlistedStudents.Count > MaxStudentsCount)
            {
                throw new OverflowException("AddStudents received enough studdents that enlisting them will overpopulate the course");
            }

            foreach (var student in students)
            {
                if (this.enlistedStudents.Contains(student))
                {
                    throw new ArgumentException("The student is already enlisted for this course");
                }
            }

            this.enlistedStudents.AddRange(students.ToList());
        }

        public object[] GetEnlistedStudents()
        {
            object[] namesAndIds = new object[this.enlistedStudents.Count];
            for (int i = 0; i < namesAndIds.Length; i++)
            {
                namesAndIds[i] = new 
                {
                    Name = this.enlistedStudents[i].Name,
                    ID = this.enlistedStudents[i].ID
                };
            }

            return namesAndIds;
        }

        public void RemoveStudents(params uint[] ids)
        {
            if (ids.Length == 0)
            {
                throw new ArgumentOutOfRangeException("RemoveStudents received no students to remove");
            }

            var indexesToBeRemoved = new List<int>();

            for (int i = 0; i < this.enlistedStudents.Count; i++)
            {
                if (ids.Contains(this.enlistedStudents[i].ID))
                {
                    indexesToBeRemoved.Add(i);
                }
            }

            if (indexesToBeRemoved.Count != ids.Length)
            {
                throw new ArgumentException("RemoveStudents received a Student ID that is not enlisted to this course");
            }

            foreach (var index in indexesToBeRemoved)
            {
                this.enlistedStudents.RemoveAt(index);
            }
        }

        public void RemoveAllStudents()
        {
            this.enlistedStudents.Clear();
        }
    }
}