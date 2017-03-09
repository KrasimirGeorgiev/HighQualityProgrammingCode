namespace Telerik.Homeworks.HQC.UnitTesting.School
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    public class Student
    {
        private const uint UniqueIdMinValue = 10000;

        private const uint UniqueIdMaxValue = 99999;

        private static uint nextStudentId = UniqueIdMinValue;

        private static List<Student> allStudentInstances = new List<Student>();

        private bool disposed = false;

        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private string name;

        private uint id;

        public Student(string name)
        {
            this.Name = name;
            this.id = AssignNextId();

            allStudentInstances.Add(this);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Reveived null for Student.Name");
                }

                this.name = value;
            }
        }

        public uint ID
        {
            get
            {
                return this.id;
            }
        }

        public bool Disposed
        {
            get
            {
                return this.disposed;
            }
        }

        public static uint GetMinIdValue()
        {
            return UniqueIdMinValue;
        }

        public static uint GetMaxIdValue()
        {
            return UniqueIdMaxValue;
        }

        public static void FreeAllStudents()
        {
            foreach (var student in allStudentInstances)
            {
                student.Dispose();
            }

            nextStudentId = UniqueIdMinValue;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.handle.Dispose();
            }

            this.disposed = true;
        }

        private static uint AssignNextId()
        {
            if (nextStudentId > UniqueIdMaxValue)
            {
                throw new ArgumentOutOfRangeException("Reached Student UniqueIdMaxValue");
            }
            else
            {
                return nextStudentId++;
            }
        }

        private void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
