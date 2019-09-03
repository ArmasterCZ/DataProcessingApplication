using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessingApplication
{
    /// <summary>
    /// Model to display of all data about one group.
    /// Need to be loaded thrue <see cref="LoadData(StudentGroup)"/>
    /// </summary>
    [DataContract]
    [XmlType(TypeName = "Group")]
    public class OutputGroup
    {
        [DataMember(Name = "GroupName")]
        [XmlAttribute(AttributeName = "GroupName")]
        public string Name { get; set; }

        [DataMember]
        public OutputStatistic Statistics { get; set; } = new OutputStatistic();

        [DataMember(Name = "Students")]
        [XmlArray (ElementName = "Students")]
        public List<OutputStudentModel> StudentList { get; set; } = new List<OutputStudentModel>();

        [DataMember(Name = "Errors")]
        [XmlArray(ElementName = "Errors")]
        public List<ErrorModel> ErrorList { get; set; } = new List<ErrorModel>();



        /// <summary>
        /// fill model with data from <see cref="StudentModel"/> & calculate rest
        /// </summary>
        /// <param name="group"></param>
        public void LoadData(StudentGroup group)
        {
            this.Name = group.Name;
            this.ErrorList = group.ErrorList;
            this.StudentList = convertStudentModelToOutput(group.StudentList);
            this.Statistics.LoadData(group);
        }


        /// <summary>
        /// convert <see cref="StudentModel"/> to <see cref="OutputStudentModel"/>
        /// </summary>
        /// <param name="StudentList"></param>
        /// <returns>list that can be placed to this group</returns>
        private List<OutputStudentModel> convertStudentModelToOutput(List<StudentModel> StudentList)
        {
            List<OutputStudentModel> outputStudents = new List<OutputStudentModel>();
            foreach (var student in StudentList)
            {
                OutputStudentModel outputStudent = new OutputStudentModel();
                outputStudent.LoadData(student);
                outputStudents.Add(outputStudent);
            }
            return outputStudents;
        }
    }
}
