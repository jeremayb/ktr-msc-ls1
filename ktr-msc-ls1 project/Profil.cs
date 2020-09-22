using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktr_msc_ls1_project
{
    class Profil
    {
        private string ProfilName;
        private string CompanyName;
        private string EmailAdress;
        private string PhoneNumber;
        private bool Actif;
        protected string Password;

        public string profilName  { get { return ProfilName; } set { ProfilName = value; } }
        public string companyName { get { return CompanyName; } set { CompanyName = value; } }
        public string emailAdress { get { return EmailAdress; } set { EmailAdress = value; } }
        public string phoneNumber { get { return PhoneNumber; } set { PhoneNumber = value; } }
        public string password { get { return Password; } set { Password = value; } }
        public bool actif { get { return Actif; } set { Actif = value; } }

        public Profil(string ProfilName,string CompanyName,string EmailAdress, string PhoneNumber, string Password, bool Actif)
        {
            this.profilName = ProfilName;
            this.companyName = CompanyName;
            this.emailAdress = EmailAdress;
            this.phoneNumber = PhoneNumber;
            this.password = Password;
            this.actif = Actif;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public override string ToString()
        {
            return "Profil name: " + profilName + ",\nCompany name: " + companyName + ",\nEmail Adresse: " + emailAdress + ",\nPhone Number: " + phoneNumber;
        }

        static void login(List<Profil> ListProfil) //step 2
        {
            Console.Clear();
            string answer;
            string name;
            string passwordd;
            string companyname;
            string emailadress;
            string phonenumber;
            Console.WriteLine("Hello do you have an account ? (y=yes ; n=no)");
            answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.Clear();
                Console.WriteLine("Enter your profil Name.");
                name = Console.ReadLine();
                Console.WriteLine("Enter your password.");
                passwordd = Console.ReadLine();
                if (ListProfil.Count == 0)
                {
                    Console.WriteLine("There is no profil in the list.");
                }
                else
                {
                    /*foreach (Profil profil in ListProfil)
                    {
                        Console.WriteLine(profil.ToString());
                    }*/
                }

                foreach (Profil profil in ListProfil.ToList())
                {
                    if (profil.profilName == name)
                    {
                        if (profil.password == passwordd)
                        {
                            Console.WriteLine("Your are now connected to your profil, welcome back " + name+" !");
                            profil.actif = true;
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong password or user name, try again.(press enter)");
                            Console.ReadKey();
                            login(ListProfil);
                        }
                    }
                }
            }
            else if(answer == "n")
            {
                Console.Clear();
                Console.WriteLine("Okay ! Let's create a new profil then !\nWrite your profil name.");
                name = Console.ReadLine();
                Console.WriteLine("Write your company's name.");
                companyname = Console.ReadLine();
                Console.WriteLine("Write your email adress.");
                emailadress = Console.ReadLine();
                Console.WriteLine("Write your phone number.");
                phonenumber = Console.ReadLine();
                Console.WriteLine("Write your password.");
                passwordd = Console.ReadLine();
                Profil profil = new Profil(name, companyname, emailadress, phonenumber, passwordd,true);

                foreach (Profil p in ListProfil)
                {
                    if (profil.profilName == p.profilName)
                    {
                        Console.WriteLine("Profil name already used by an other user. Please choose another one.");
                        profil.profilName = Console.ReadLine();
                    }
                    if (profil.emailAdress == p.emailAdress)
                    {
                        Console.WriteLine("Email adress already used by an other user. Please choose another one.");
                        profil.emailAdress = Console.ReadLine();
                    }
                }
                ListProfil.Add(profil);
                Console.Clear();
                Console.WriteLine("Congrats, your profil is succesfully created!");
            }
            else
            {
                Console.WriteLine("Wrong answer retry. (press enter)");
                Console.ReadKey();
                login(ListProfil);
            }
        }

        static void AddCard(List<BuisnessCard> ListCard,string owner)
        {
            string name;
            string companyname;
            string emailadress;
            string phonenumber;

            Console.WriteLine("Let's add a new buisness card.\nWrite the name of the buisness card's owner.");
            name = Console.ReadLine();
            Console.WriteLine("Write your company's name.");
            companyname = Console.ReadLine();
            Console.WriteLine("Write your email adress.");
            emailadress = Console.ReadLine();
            Console.WriteLine("Write your phone number.");
            phonenumber = Console.ReadLine();
            BuisnessCard NewCard = new BuisnessCard(name, companyname, emailadress, phonenumber, owner);

            foreach (BuisnessCard BC in ListCard)
            {
                if (BC.emailAdress == NewCard.emailAdress)
                {
                    Console.WriteLine("Email adress already used in another card. Please write another one.");
                    BC.emailAdress = Console.ReadLine();
                }
            }
            ListCard.Add(NewCard);
            Console.Clear();
            Console.WriteLine("Congrats, your new buisness card is succesfully created!");
            Console.WriteLine(NewCard.ToString());
        }

        static bool testifnull(string test)
        {
            bool result = true;
            if (test == "")
            {
                result = false;
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<Profil> ListProfil = new List<Profil>();
            List<BuisnessCard> ListCard = new List<BuisnessCard>();
            string choix;
            string actifprofil = "";

            Profil P = new Profil("Jeremy Butin", "Eurobite", "jeremy.butin@yahoo.com", "0658370842", "sopalin;)",false);
            ListProfil.Add(P); 
            login(ListProfil);

            
            Console.WriteLine();
            Console.WriteLine("Welcome in your user profil !");
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Write the number of the functionnality you want to reach.");
                Console.WriteLine();

                Console.WriteLine("Add new buisness card ?(1)");
                Console.WriteLine("Visualize cards already added?(2)");
                Console.WriteLine("Logout ?(3)");

                choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        foreach(Profil O in ListProfil)
                        {
                            if (O.actif == true)
                            {
                                actifprofil = O.profilName;
                            }
                        }
                        AddCard(ListCard,actifprofil);
                        break;
                    case "2":
                        Console.Clear();
                        if(ListCard.Count == 0)
                        {
                            Console.WriteLine("No card has been added yet. (Press enter)");
                            Console.ReadKey();
                        }
                        else
                        {
                            foreach (Profil O in ListProfil)
                            {
                                if (O.actif == true)
                                {
                                    actifprofil = O.profilName;
                                }
                            }
                            foreach (BuisnessCard BC in ListCard)
                            {
                                if (BC.owner == actifprofil)
                                {
                                    Console.WriteLine(BC.ToString());
                                    Console.WriteLine();
                                }
                            }
                            Console.WriteLine("Press enter");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("You successfully logout.(press enter)");
                        Console.ReadKey();
                        foreach(Profil O in ListProfil)
                        {
                            if(O.actif == true)
                            {
                                O.actif = false;
                            }
                        }
                        login(ListProfil);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Name of the functionnality incorrect");
                        break;
                }
            } while (choix != "4");
                 
            Console.ReadKey();
        }
    }
}
