using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (type == "tasks")
            {
                GenerateForTasks(count, filename, format);
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data" + type);
            }
        }

        static void GenerateForTasks(int count, string filename, string format)
        {
            List<TaskData> tasks = new List<TaskData>();
            for (int i = 0; i < count; i++)
            {
                tasks.Add(new TaskData(GenerateRandomString(20), GenerateRandomString(20)));
            }
            if (format == "xml")
            {
                using(var stream = new StreamWriter(filename))
                {
                    WriteTasksToXmlFile(tasks, stream);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }

        }

        static void WriteTasksToXmlFile(List<TaskData> tasks, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<TaskData>)).Serialize(writer, tasks);
        }

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}