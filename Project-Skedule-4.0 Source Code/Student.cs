using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skedule_v3
{
    public class Student
    {
        public string emailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int studentID { get; set; }
        public string password { get; set; }

   


        public Student(string emailAddress, string firstName, string lastName, int studentID, string password)
        {
            this.emailAddress = emailAddress;
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentID = studentID;
            this.password = password;
      
        }
    }
}
