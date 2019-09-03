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
    /// model to store loaded information about student
    /// </summary>
    [DataContract]
    public class StudentModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Math { get; set; } = -1;

        [DataMember]
        public int Physics { get; set; } = -1;

        [DataMember]
        public int English { get; set; } = -1;

        /// <summary>
        /// check if all int was set to 0-100, and have a name.
        /// </summary>
        /// <returns>if object is valid</returns>
        public bool isValid()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(Name))
            {
                isValid = false;
            }
            if ((Math < 0 ) || (Math > 100))
            {
                isValid = false;
            }
            if ((Physics < 0) || (Physics > 100))
            {
                isValid = false;
            }
            if ((English < 0) || (English > 100))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
