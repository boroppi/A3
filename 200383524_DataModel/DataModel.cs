using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace _200383524_DataModel
{
    public class DataModel : ISerializable
    {
        public List<Person> People;
        
        public DataModel() { }


        #region Serialization Part

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("People", People, typeof(List<Person>));
        }

        public DataModel(SerializationInfo info, StreamingContext context)
        {
            People = (List<Person>)info.GetValue("People", typeof(List<Person>));
        }

        #endregion

    }
}
