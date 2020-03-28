using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    class Member
    {
        int memberid;

        public int Memberid
        {
            get { return memberid; }
            set { memberid = value; }
        }

        String lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        String firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        String regionname;

        public string Regionname
        {
            get { return regionname; }
            set { regionname = value; }
        }

        public Member(int memberid, string lastname, string firstname, string regionname)
        {
            this.memberid = memberid;
            this.lastname = lastname;
            this.firstname = firstname;
            this.regionname = regionname;
        }
    }
}
