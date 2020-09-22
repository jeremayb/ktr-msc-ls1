using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktr_msc_ls1_project
{
    class BuisnessCard
    {
        private string CardName;
        private string CompanyName;
        private string EmailAdress;
        private string PhoneNumber;
        private string Owner;

        public string cardName { get { return CardName; } set { CardName = value; } }
        public string companyName { get { return CompanyName; } set { CompanyName = value; } }
        public string emailAdress { get { return EmailAdress; } set { EmailAdress = value; } }
        public string phoneNumber { get { return PhoneNumber; } set { PhoneNumber = value; } }
        public string owner { get { return Owner; } set { Owner = value; } }

        public BuisnessCard(string CardName, string CompanyName, string EmailAdress, string PhoneNumber,string Owner)
        {
            this.cardName = CardName;
            this.companyName = CompanyName;
            this.emailAdress = EmailAdress;
            this.phoneNumber = PhoneNumber;
            this.owner = Owner;
        }

        public override string ToString()
        {
            return "Buisnesscard name: " + cardName + ",\nCompany name: " + companyName + ",\nEmail Adresse: " + emailAdress + ",\nPhone Number: " + phoneNumber;
        }
    }
}
