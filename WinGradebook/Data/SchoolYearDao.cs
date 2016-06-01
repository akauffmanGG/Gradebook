using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Gradebook.Model;

namespace Gradebook.Data
{
    class SchoolYearDao
    {
        //TODO: Make into a property string
        private const String PATH = "C:\\Users\\Andy.Kauffman\\schoolYear.xml";

        //TODO: Support multiple school years
        public static SchoolYear getCurrentSchoolYear()
        {
            SchoolYear schoolYear = new SchoolYear();
            XmlSerializer deserializer = new XmlSerializer(typeof(SchoolYear));

            try
            {
                using (StreamReader reader = new StreamReader(PATH))
                {
                    schoolYear = (SchoolYear)deserializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                //TODO: Do Something
            }



            return schoolYear;
        }

        public static void SaveSchoolYear(SchoolYear schoolYear)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SchoolYear));
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                serializer.Serialize(writer, schoolYear);
            }
        }
    }
}
