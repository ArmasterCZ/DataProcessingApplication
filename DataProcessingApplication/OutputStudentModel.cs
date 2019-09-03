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
    /// display information about student
    /// </summary>
    [DataContract]
    [XmlType(TypeName = "Student")]
    public class OutputStudentModel
    {
        [DataMember]
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [DataMember]
        public int Math { get; set; }

        [DataMember]
        public int Physics { get; set; } 

        [DataMember]
        public int English { get; set; }

        [DataMember]
        public int Average { get; set; }

        /// <summary>
        /// fill this object with data
        /// </summary>
        /// <param name="studentModel">input data</param>
        public void LoadData(StudentModel studentModel)
        {
            this.Name = studentModel.Name;
            this.Math    = studentModel.Math;
            this.Physics = studentModel.Physics;
            this.English = studentModel.English;
            this.Average = StudentCalculation.calcAverageAll(studentModel);
        }
    }
}
