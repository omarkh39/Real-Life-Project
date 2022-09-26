using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Project
{
    public static class Logger
    {
        private static string TimeDirectory;
        private static string DirectoryPath = @"Logs\";
        private const string DateFormat = "dd-MMMM-yyyy";
        private const string TimeFormat = " h:mm:ss fff tt";

        private static void FileCheck(string path)
        {
            if (File.Exists(DirectoryPath + DateTime.Now.ToString(DateFormat) + path))
            {
                TimeDirectory = DateTime.Now.ToString(DateFormat);
            }
            else
            {
                if (Directory.Exists(DirectoryPath))
                {
                    if (!Directory.Exists(DirectoryPath + DateTime.Now.ToString(DateFormat)))
                    {
                        Directory.CreateDirectory(DirectoryPath + DateTime.Now.ToString(DateFormat));
                    }
                }
                else
                {
                    Directory.CreateDirectory(DirectoryPath + DateTime.Now.ToString(DateFormat));
                }
                TimeDirectory = DateTime.Now.ToString(DateFormat);
                File.Create(DirectoryPath + TimeDirectory + path).Close();
            }
        }

        private static void CheckTime(string path)
        {
            FileCheck(path);
            var result = DateTime.ParseExact(DateTime.Now.ToString(DateFormat), DateFormat, CultureInfo.InvariantCulture)
                .Subtract(DateTime.ParseExact(TimeDirectory.ToString(), DateFormat, CultureInfo.InvariantCulture));

            if (result.Days > 0)
            {
                FileChanger(path);
            }
        }

        private static void FileChanger(string path)
        {
            TimeDirectory = DateTime.Now.ToString(DateFormat);
            File.Create(DirectoryPath + TimeDirectory + path);
        }

        public static void LogTransactionWritter(string message)
        {
            string filePath = @"\Transaction";
            StackFrame stackFrame = new StackTrace(true).GetFrame(1);
            CheckTime(filePath);
            using (StreamWriter writer = new StreamWriter(DirectoryPath + TimeDirectory + filePath, true))
            {
                writer.WriteLine(DateTime.Now.ToString(TimeFormat) + "\t\t" + Path.GetFileName(stackFrame.GetFileName())
                    + "\t\t" + stackFrame.GetMethod().Name + "\t\t\t" + message);
            }
        }

        public static void LogExceptionWritter(Exception exception)
        {
            string filePath = @"\Exception";
            string message = "Excpetion Message \t" + exception.Message + "\t Exception stack Trace" + exception.StackTrace + "\n";
            CheckTime(filePath);
            using (StreamWriter writer = new StreamWriter(DirectoryPath + TimeDirectory + filePath, true))
            {
                writer.WriteLine(DateTime.Now.ToString(TimeFormat) +
                     "\t" + message);
            }
        }

    }
}
