using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Gradebook.Model;

namespace Gradebook.Data
{
    class CourseDao
    {
        private const String PATH = "C:\\Users\\Andy.Kauffman\\courses.xml";

        public static List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Course>));

            try
            {
                using (StreamReader reader = new StreamReader(PATH))
                {
                    courses = (List<Course>)deserializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                //DO NOTHING
            }

            //Assignment assignment = new Assignment() { Name = "Reading Assignment", Points = 100, AssignmentDate = new DateTime() };
            //List<Assignment> assignments = new List<Assignment>();
            //assignments.Add(assignment);
            //Course course = new Course() { Name = "Reading", Assignments = assignments };
            //courses.Add(course);

            //Assignment assignment2 = new Assignment() { Name = "Writing Assignment", Points = 50, AssignmentDate = new DateTime() };
            //List<Assignment> assignments2 = new List<Assignment>();
            //assignments2.Add(assignment2);
            //Course course2 = new Course() { Name = "Writing", Assignments = assignments2 };
            //courses.Add(course2);

            return courses;
        }

        public static void saveCourses(List<Course> courses)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Course>));
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                serializer.Serialize(writer, courses);
            }
        }
    }
}
