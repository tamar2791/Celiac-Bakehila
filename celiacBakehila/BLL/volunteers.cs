using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    internal class volunteers
    {
        private string tel;
        private string firstName;
        private string lastName;
        private int city;
        private string street;
        private string houseNumber;
        private string pel;
        private string mail;
        private bool status;
        private int branch;
        private DataRow dr;
        public volunteers()
        {
        }
        public volunteers(DataRow dr) : this()
        {
            this.dr = dr;
            this.Tel = dr["tel"].ToString();
            this.firstName = dr["firstName"].ToString();
            this.lastName = dr["lastName"].ToString();
            this.city = Convert.ToInt32(dr["city"]);
            this.street = dr["street"].ToString();
            this.houseNumber = dr["houseNumber"].ToString();
            this.Pel = dr["pel"].ToString();
            this.mail = dr["mail"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
            this.branch = Convert.ToInt32(dr["branch"]);
        }
        public void PutInto()
        {
            dr["tel"] = Tel;
            dr["firstName"] = firstName;
            dr["lastName"] = lastName;
            dr["city"] = city;
            dr["street"] = street;
            dr["houseNumber"] = houseNumber;
            dr["pel"] = Pel;
            dr["mail"] = mail;
            dr["status"] = status;
            dr["branch"] = branch;
        }
        public string Tel
        {
            get => tel; set
            {
                if (!Validation.IsTel(value))
                    throw new Exception("טלפון לא תקין!"); tel = value;
            }
        }

        public string FirstName
        { get => firstName; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); firstName = value;
            }
        }
        public string LastName 
        { get => lastName; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); lastName = value;
            }
        }
        public int City { get => city; set => city = value; }
        public string Street { get => street; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); street = value;
            }
        }
        public string HouseNumber { get => houseNumber; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); houseNumber = value;
            }
        }
        public string Pel
        {
            get => pel; set 
            {
                if (!Validation.IsPelepon(value))
                    throw new Exception("פלפון לא תקין!"); pel = value;
            }
        }
        public string Mail { get => mail; set=> mail = value;}
        public bool Status { get => status; set => status = value; }
        public int Branch { get => branch; set => branch = value; }
        public DataRow Dr { get => dr; set => dr = value; }        

        public cities CitiesOfVolunteers()
        {
            return new citiesDB().SearchId(this.city);
        }
        public branches BranchesOfVolunteers()
        {
            return new branchesDB().SearchId(this.branch);
        }

    }
}
