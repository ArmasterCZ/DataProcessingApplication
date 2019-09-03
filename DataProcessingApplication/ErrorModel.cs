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
    /// model to store information about exceptions
    /// </summary>
    [DataContract]
    [XmlType(TypeName = "Error")]
    public class ErrorModel
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
