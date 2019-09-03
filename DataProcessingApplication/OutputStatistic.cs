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
        public List<int> ModusMath { get; set; }

        [DataMember]
        public List<int> ModusPhysics { get; set; }

        [DataMember]
        public List<int> ModusEnglish { get; set; }

        /// <summary>
        /// fill model with data from <see cref="StudentModel"/> & calculate rest
        /// </summary>
        /// <param name="group"></param>
        public void LoadData(StudentGroup group)
        {
            this.AverageMath = StudentCalculation.calcAverageMath(group.StudentList);
            this.AveragePhysics = StudentCalculation.calcAveragePhys(group.StudentList);
            this.AverageEnglish = StudentCalculation.calcAverageEngl(group.StudentList);
            this.MedianMath = StudentCalculation.calcMedianMath(group.StudentList);
            this.MedianPhysics = StudentCalculation.calcMedianPhys(group.StudentList);
            this.MedianEnglish = StudentCalculation.calcMedianEngl(group.StudentList);
            this.ModusMath = StudentCalculation.calcModusMath(group.StudentList);
            this.ModusPhysics = StudentCalculation.calcModusPhys(group.StudentList);
            this.ModusEnglish = StudentCalculation.calcModusEngl(group.StudentList);
        }

    }
}
