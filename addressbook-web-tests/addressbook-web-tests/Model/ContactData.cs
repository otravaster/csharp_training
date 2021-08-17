﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Id { get; set; }

        public string Firstname { get; set; }

        //public string Middlename { get; set; }

        public string Lastname { get; set; }

        //public string Nickname { get; set; }

        //public string Company { get; set; }

        //public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        //public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        //public string Homepage { get; set; }

        //public string Birthday { get; set; }

        //public string Anniversary { get; set; }

        //public string Address2 { get; set; }

        //public string HomePhone2 { get; set; }

        //public string Notes { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (Firstname + " " + Lastname + "\r\n" 
                        + CleanUpAddress(Address) + "\r\n"
                        + CleanUpPhone("H: ", HomePhone) + CleanUpPhone("M: ", MobilePhone) + CleanUpPhone("W: ", WorkPhone) + "\r\n"
                        + CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string CleanUp(string info)
        {
            if (info == null || info == "")
            {
                return String.Empty;
            }
            return Regex.Replace(info, "[ -()]", String.Empty) + "\r\n";
        }

        private string CleanUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return String.Empty;
            }
            return address + "\r\n";
        }

        private string CleanUpPhone(string type, string phone)
        {
            if (phone == null || phone == "")
            {
                return String.Empty;
            }
            return type + phone + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname= " + Firstname + "\nlastname= " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }
            if (Lastname == other.Lastname)
            {
                if (Firstname == other.Firstname)
                {
                    return 0;
                }
            }
            return Lastname.CompareTo(other.Lastname);
        }
    }
}
