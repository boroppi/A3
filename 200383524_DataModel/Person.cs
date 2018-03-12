using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _200383524_DataModel
{
    public class Person : ISerializable
    {
        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        public Boolean HasDriversLicense { get; private set; }
        public String Email { get; private set; }

        
        [JsonConstructor] // I guess required because I use properties and default constructor does not set values... perhaps I could set values directly inside another constructor but this way it validates json values again.
        public Person(string firstName, string lastName, bool hasDriversLicense, string email)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            HasDriversLicense = hasDriversLicense;
            SetEmail(email);
        }

        // validates if the parameter matches to regex pattern then sets the properties
        public void SetFirstName(string fname)
        {
            if (RegexMatch.NameMatchesRegex(fname))
                FirstName = fname;
            else
                throw new ArgumentException("First Name does not match required format.");
        }
        // validates if the parameter matches to regex pattern then sets the properties
        public void SetLastName(string lname)
        {
            if (RegexMatch.NameMatchesRegex(lname))
                LastName = lname;
            else
                throw new ArgumentException("Last Name does not match required format.");
        }
        // validates if the parameter matches to regex pattern then sets the properties
        public void SetEmail(string email)
        {
            if (RegexMatch.EmailMatchesRegex(email))
                Email = email;
            else
                throw new ArgumentException("Email does not match required format.");
        }

        #region Serialization Part

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName, typeof(String));
            info.AddValue("LastName", LastName, typeof(String));
            info.AddValue("HasDriversLicense", HasDriversLicense, typeof(Boolean));
            info.AddValue("Email", Email, typeof(String));
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            FirstName = (String)info.GetValue("FirstName", typeof(String));
            LastName = (String)info.GetValue("LastName", typeof(String));
            HasDriversLicense = (Boolean)info.GetValue("HasDriversLicense", typeof(Boolean));
            Email = (String)info.GetValue("Email", typeof(String));
        }

        #endregion


    }
}
