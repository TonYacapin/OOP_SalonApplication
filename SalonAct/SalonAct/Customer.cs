using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAct
{
    internal class Customer
    {
        private string name;
        private bool member = false;
        private string memberType;
        public Customer() {
            this.name = "";
        
        }

        public Customer(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public bool isMember()
        {
            return member;
        }

        public void setMember(bool member)
        {
            this.member = member;
        }

        public string getMemberType()
        {

            return memberType;
        }

        public void setMemberType(string type)
        {
           
                this.memberType = type;
            
          
        }

        public String toString()
        {
            return "Name: " + name + ", Member: " + member + ", Member Type: " + memberType;
        }
    }
}
