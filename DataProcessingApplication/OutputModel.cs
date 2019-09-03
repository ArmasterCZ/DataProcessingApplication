using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    /// <summary>
    /// base of serialized object.
    /// next level is <see cref="OutputGroup"/> with <see cref="OutputStatistic"/> & <see cref="ErrorModel"/>
    /// last one is <see cref="OutputStudentModel"/>
    /// </summary>
    [DataContract]
    public class OutputModel
    {
        [DataMember]
        public List<OutputGroup> Groups { get; set; } = new List<OutputGroup>();

        [DataMember]
        public OutputStatistic Statistics { get; set; } = new OutputStatistic();

        /// <summary>
        /// transfere <see cref="StudentGroup"/> to <see cref="OutputGroup"/>
        /// </summary>
        public void LoadData(List<StudentGroup> groups)
        {
            StudentGroup globalGroup = new StudentGroup() { Name = "Global statistic" };
            foreach (var group in groups)
            {
                OutputGroup outputGroup = new OutputGroup();
                outputGroup.LoadData(group);
                this.Groups.Add(outputGroup);

                globalGroup.StudentList.AddRange(group.StudentList);
            }
            Statistics.LoadData(globalGroup);
        }

    }
}
