using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Gradebook.Model;

namespace Gradebook.Data
{
    class GradebookDao
    {
        //TODO: Make into a property string
        private const String PATH = "gradebook.xml";

        public static GradebookModel getGradebook()
        {
            GradebookModel gradebook = new GradebookModel();
            XmlSerializer deserializer = new XmlSerializer(typeof(GradebookModel));

            try
            {
                using (StreamReader reader = new StreamReader(PATH))
                {
                    gradebook = (GradebookModel)deserializer.Deserialize(reader);
                }
            }
            catch (FileNotFoundException)
            {
                //TODO: Do Something
            }



            return gradebook;
        }

        public static void SaveGradebook(GradebookModel gradebook)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GradebookModel));
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                serializer.Serialize(writer, gradebook);
            }
        }
    }
}
