using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    public class branchManager
    {
        private string telManager;
        private string firstName;
        private string lastName;
        private int city;
        private string street;
        private int houseNumber;
        private string phone;
        private string cellPhone;
        private string mail;
        private DataRow dr;
        public branchManager()
        {
        }
        public branchManager(DataRow dr) : this()
        {
            this.dr = dr;
            this.telManager = dr["telManager"].ToString();
            this.firstName = dr["firstName"].ToString();
            this.lastName = dr["lastName"].ToString();
            this.city = Convert.ToInt32(dr["city"]);
            this.street = dr["street"].ToString();
            this.houseNumber = Convert.ToInt32(dr["houseNumber"]);
            this.phone = dr["phone"].ToString();
            this.cellPhone = dr["cellPhone"].ToString();
            this.mail = dr["mail"].ToString();
        }
        public void PutInto()
        {
            dr["telManager"] = telManager;
            dr["firstName"] = firstName;
            dr["lastName"] = lastName;
            dr["city"] = city;
            dr["street"] = street;
            dr["houseNumber"] = houseNumber;
            dr["phone"] = phone;
            dr["cellPhone"] = cellPhone;
            dr["mail"] = mail;
        }
        public string TelManager
        { get => telManager; set
            {
                if (!Validation.IsTel(value))
                    throw new Exception("טלפון לא תקין!"); telManager = value;
            }
        }
        public string FirsrName
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
        public int City
        { get => city; set => city = value; }
        public string Street
        {
            get => street; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); street = value;
            }
        }
        public int HouseNumber
        { get => houseNumber; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); houseNumber = value;
            }
        }
        public string Phone
        { get => phone; set
            {
                if (!Validation.IsTel(value))
                    throw new Exception("טלפון לא תקין!"); phone = value;
            }
        }
        public string CellPhone
        { get => cellPhone; set
            {
                if (!Validation.IsPelepon(value))
                    throw new Exception("פלפון לא תקין!"); cellPhone = value;
            }
        }
        public string Mail
        { get => mail; set
            {
                if (!Validation.IsMail(value))
                    throw new Exception("מייל לא תקין!"); mail = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public cities citiesOfBranchesManager()
        {
            return new citiesDB().SearchId(this.city);
        }
        public override string ToString()
        {
            return this.FirsrName + " " + this.lastName;
        }
    }
}
