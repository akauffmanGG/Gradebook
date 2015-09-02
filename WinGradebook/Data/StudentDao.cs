using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Gradebook.Model;

namespace Gradebook.Data
{
    class StudentDao
    {
        private const String PATH = "C:\\Users\\Andy.Kauffman\\students.xml";

        public static List<Student> getStudents()
        {
            List<Student> students = new List<Student>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Student>));

            try
            {
                using (StreamReader reader = new StreamReader(PATH))
                {
                    students = (List<Student>)deserializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                //DO NOTHING
            }

            return students;
        }

        public static void saveStudents(List<Student> students)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                serializer.Serialize(writer, students);
            }
        }
    }
}

