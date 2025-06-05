using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;

namespace celiacBakehila.BLL
{
    public class suppliers
    {
        private string tzSupplier;
        private string nameSupplier;
        private string phone;
        private string cellPhone;
        private string mail;
        private bool status;
        private DataRow dr;
        public suppliers()
        {
        }
        public suppliers(DataRow dr) : this()
        {
            this.dr = dr;
            this.tzSupplier = dr["tzSupplier"].ToString();
            this.nameSupplier = dr["nameSupplier"].ToString();
            this.phone = dr["phone"].ToString();
            this.cellPhone = dr["cellPhone"].ToString();
            this.mail = dr["mail"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }
        public void PutInto()
        {
            dr["tzSupplier"] = tzSupplier;
            dr["nameSupplier"] = nameSupplier;
            dr["phone"] = phone;
            dr["cellPhone"] = cellPhone;
            dr["mail"] = mail;
            dr["status"] = status;
        }
        public string TzSupplier
        { get => tzSupplier; set
            {
                if (!Validation.CheckId(value))
                    throw new Exception("ת.ז. לא תקינה!"); tzSupplier = value;
            }
        }
        public string NameSupplier
        { get => nameSupplier; set
            {
                if (!Validation.IsHebrew(value))
                    throw new Exception("עברית בלבד!"); nameSupplier = value;
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
                    throw new Exception("פלאפון לא תקין!"); cellPhone = value;
            }
        }
        public string Mail
        { get => mail; set 
            {
                if (!Validation.IsMail(value))
                    throw new Exception("מייל לא תקין!");
                mail = value;
            }
        }
        public DataRow Dr { get => dr; set => dr = value; }
        public bool Status { get => status; set => status = value; }
        public override string ToString()
        {
            return this.NameSupplier;
        }
    }
}
