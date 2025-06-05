using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace celiacBakehila.BLL
{
    public class client
    {
        private string tel;
        private string pel;
        private string nameFather;
        private string nameMother;
        private string lastName;
        private int child;
        private int city;
        private string street;
        private string houseNumber;
        private string mail;
        private bool status;
        private int branch;
        private string creditCardDetailsNumber;
        private string creditCardDetailsValidityM;
        private string creditCardDetailsValidityY;
        private string creditCardDetailsCvv;
        private string creditCardDetailsTz;
        private DataRow dr;
        public client()
        {

        }
        public client(DataRow dr) : this()
        {
            this.dr = dr;
            this.Tel = dr["tel"].ToString();
            this.Pel = dr["pel"].ToString();
            this.NameFather = dr["nameFather"].ToString();
            this.NameMother = dr["nameMother"].ToString();
            this.LastName = dr["lastName"].ToString();
            this.Child = Convert.ToInt32(dr["child"]);
            this.City = Convert.ToInt32(dr["city"]);
            this.Street = dr["street"].ToString();
            this.HouseNumber = dr["houseNumber"].ToString();
            this.mail = dr["mail"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
            this.branch = Convert.ToInt32(dr["branch"]);
            this.CreditCardDetailsNumber = dr["creditCardDetailsNumber"].ToString();
            this.CreditCardDetailsValidityM = dr["creditCardDetailsValidityM"].ToString();
            this.CreditCardDetailsValidityY = dr["creditCardDetailsValidityY"].ToString();
            this.CreditCardDetailsCvv = dr["creditCardDetailsCvv"].ToString();
            this.CreditCardDetailsTz = dr["creditCardDetailsTz"].ToString();

        }
        public void PutInto()
        {
            dr["tel"] = Tel;
            dr["pel"] = Pel;
            dr["nameFather"] = NameFather;
            dr["nameMother"] = NameMother;
            dr["lastName"] = LastName;
            dr["child"] = Child;
            dr["city"] = City;
            dr["street"] = Street;
            dr["houseNumber"] = HouseNumber;
            dr["mail"] = mail;
            dr["status"] = status;
            dr["branch"] = branch;
            dr["creditCardDetailsNumber"] = CreditCardDetailsNumber;
            dr["creditCardDetailsValidityM"] = CreditCardDetailsValidityM;
            dr["creditCardDetailsValidityY"] = CreditCardDetailsValidityY;
            dr["creditCardDetailsCvv"] = CreditCardDetailsCvv;
            dr["creditCardDetailsTz"] = CreditCardDetailsTz;
        }
        public string Tel
        {
            get => tel; set
            {
                if (!Validation.IsTel(value))
                    throw new Exception("טלפון לא תקין!"); tel = value;
            }
        }
        public string Pel
        {
            get => pel; set
            {
                if (!Validation.IsPelepon(value))
                    throw new Exception("פלאפון לא תקין!"); pel = value;
            }
        }
        public string NameFather
        {
            get => nameFather; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("אותיות בעברית בלבד!"); nameFather = value;
            }
        }
        public string NameMother
        {
            get => nameMother; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("אותיות בעברית בלבד!"); nameMother = value;
            }
        }
        public string LastName
        {
            get => lastName; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); lastName = value;
            }
        }
        public int Child
        {
            get => child; set
            {
                if (!Validation.IsNum((value).ToString()))
                    throw new Exception("מספרים בלבד"); child = value;
            }
        }
        public int City
        { get => city; set => city = value; }
        public string Street
        {
            get => street; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("אותיות בעברית בלבד!"); street = value;
            }
        }
        public string HouseNumber
        {
            get => houseNumber; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("מספרים בלבד!"); houseNumber = value;
            }
        }

        public string Mail { get => mail; set => mail = value; }

        public bool Status { get => status; set => status = value; }
        public int Branch { get => branch; set => branch = value; }

        public DataRow Dr { get => dr; set => dr = value; }
        public string CreditCardDetailsNumber { get => creditCardDetailsNumber; set => creditCardDetailsNumber = value; }
        public string CreditCardDetailsValidityM { get => creditCardDetailsValidityM; set => creditCardDetailsValidityM = value; }
        public string CreditCardDetailsValidityY { get => creditCardDetailsValidityY; set => creditCardDetailsValidityY = value; }
        public string CreditCardDetailsCvv
        {
            get => creditCardDetailsCvv; set
            {
                if (!Validation.IsNum(value.ToString()))
                    throw new Exception("ספרות בלבד");
                if(value.Length<3)
                    throw new Exception("ספרות בטיחות מכילות 3 ספרות");
                creditCardDetailsCvv = value;
            }
        }
        public string CreditCardDetailsTz
        {
            get => creditCardDetailsTz; set
            {
                if (!Validation.CheckId(value.ToString()))
                    throw new Exception("ת.ז. לא תקינה"); creditCardDetailsTz = value;
            }
        }

        public cities CitiesOfClient()
        {
            return new citiesDB().SearchId(this.City);
        }
        public branches BranchesOfClient()
        {
            return new branchesDB().SearchId(this.branch);
        }
        //בדיקת תקינות למספר אשראי
        public bool IsValidCreditCardNumber(string creditCardNumber)
        {
            //הסרת רווחים או - ממספר כרטיס אשראי
            creditCardNumber = creditCardNumber.Replace(" ", "").Replace("-", "");
            //בדיקת אורך מספר כרטיס אשראי
            if (creditCardNumber.Length < 13 || creditCardNumber.Length > 16)
                return false;
            //בדיקה שהמספר מכיל רק מספרים
            foreach (char c in creditCardNumber)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            //בדיקה אם מספר האשראי תקף
            int sum = 0;
            bool alternate = false;
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(creditCardNumber[i].ToString());
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }
                sum += digit;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}
