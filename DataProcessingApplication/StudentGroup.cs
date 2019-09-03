using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace DataProcessingApplication
{
    /// <summary>
    /// store loaded group name and list of students
    /// </summary>
    [DataContract]
    public class StudentGroup
    {
        [DataMember(Name = "GroupName")]
        [XmlElement(ElementName = "GroupName")]
        public string Name { get; set; } = "";

        [DataMember]
        public List<StudentModel> StudentList { get; set; } = new List<StudentModel>();

        [DataMember]
        public List<ErrorModel> ErrorList { get; set; } = new List<ErrorModel>();

    }
}
