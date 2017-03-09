namespace CohesionAndCoupling.FileMethods
{
    using System;

    public static class File
    {
        public static string GetExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("The given file name doesn't have an extension");
            }

            var extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetName(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Invalid filename - no extension");
            }

            var extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}