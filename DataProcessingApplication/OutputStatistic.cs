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
    /// sub model to store all calculated information
    /// </summary>
    [DataContract]
    [XmlType(TypeName = "Statistics")]
    public class OutputStatistic
    {
        [DataMember]
        public int AverageMath { get; set; }

        [DataMember]
        public int AveragePhysics { get; set; }

        [DataMember]
        public int AverageEnglish { get; set; }

        [DataMember]
        public double MedianMath { get; set; }

        [DataMember]
        public double MedianPhysics { get; set; }

        [DataMember]
        public double MedianEnglish { get; set; }

        [DataMember]
        [XmlArray]
        public List<int> ModusMath { get; set; }

        [DataMember]
        [XmlArray]
        public List<int> ModusPhysics { get; set; }

        [DataMember]
        [XmlArray]
        public List<int> ModusEnglish { get; set; }

        /// <summary>
        /// fill model with data from <see cref="StudentModel"/> & calculate rest
        /// </summary>
        /// <param name="group"></param>
        public void LoadData(StudentGroup group)
        {
            this.AverageMath = StudentCalculation.CalcAverageMath(group.StudentList);
            this.AveragePhysics = StudentCalculation.CalcAveragePhys(group.StudentList);
            this.AverageEnglish = StudentCalculation.CalcAverageEngl(group.StudentList);
            this.MedianMath = StudentCalculation.CalcMedianMath(group.StudentList);
            this.MedianPhysics = StudentCalculation.CalcMedianPhys(group.StudentList);
            this.MedianEnglish = StudentCalculation.CalcMedianEngl(group.StudentList);
            this.ModusMath = StudentCalculation.CalcModusMath(group.StudentList);
            this.ModusPhysics = StudentCalculation.CalcModusPhys(group.StudentList);
            this.ModusEnglish = StudentCalculation.CalcModusEngl(group.StudentList);
        }

    }
}
