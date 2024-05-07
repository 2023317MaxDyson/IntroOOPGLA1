using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;

namespace GLA1_Max_Dyson
{

    class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
    }

    internal class Program
    {
        public static void DisplayListAll(List<Contact> myList)
        {
            //This method is complete, you do not need to modify this method.
            if (myList.Count == 0)
            {
                Console.WriteLine("List is empty!");
            }
            else
            {
                Console.WriteLine("\nAll Contacts from the phonebook: \n");
                foreach (var item in myList)
                {
                    Console.WriteLine("Name: {0}, Phone: {1}", item.Name, item.Phone);
                }
            }

        }

        public static string ConvertToNameCase(string name)
        {
            //This method is complete, you do not need to modify this method.
            return name[0].ToString().ToUpper() + name.Substring(1);
        }




        //Complete the ToDo Methods, additionally, you may also add new methods, if you need.


        public static void DisplayAllContactsOfAUserName(List<Contact> myList , string userName)
            //you may change parameters if required
        {
            //ToDo
            //All contacts of a single user name
            //if an user have two contact number, print user name once followed by contact numbers
            //please see provided input/output for the formatting

   
            Console.WriteLine($"All Contacts of {userName} : ");
           
            foreach (var contact in myList)
            {
                if (contact.Name == userName)
                {
                    Console.WriteLine($"Contact No {contact.Name} : {contact.Phone}");


                    
                }
            }



        }

        public static Contact FindContactGivenAPhone(List<Contact> myList, long phone)
        {
            //ToDo: remove the return null statement and complete the method
            //Note: this method should return a Contact object
            foreach (Contact contacts in myList)
            {
                if (contacts.Phone == phone)
                {

                   return contacts;
                }
               
            }
            return null;
        }
        public static List<Contact> FindAllContactsOfAGivenName(List<Contact> myList, string name)
        {
            //ToDo: remove the return null statement and complete the method
            //Note: this method returns a List of Contacts; even if a single contact record exists for the given name

            List<Contact> foundcontactName = new List<Contact>();
            
            foreach (var list in myList) 
            {
                if(list.Name == name)
                {
                    foundcontactName.Add(list);
                  
                }
            }

            return foundcontactName;


        }
        //ToDo Methods

        



        static void Main(string[] args)
        {
            List<Contact> contactList = new List<Contact>();
            string command;
            do
            {
                Console.WriteLine("\nEnter a command: ");
                command = Console.ReadLine();
                command = command.ToLower();
                while (command.Contains("  ")) command = command.Replace("  ", " ");   //replaces multiple spaces
                command = command.Trim();                                              //to remove single whitespces from start & end.
                var split = command.Split(null);
                if (split.Length == 1)
                {
                    //This conditional block is complete, you do not need to modify this block.
                    if (split[0] == "exit")
                    {
                        break;
                    }
                    else if (split[0] == "findall")
                    {
                        DisplayListAll(contactList);
                    }

                }
                else if (split.Length == 0) continue; //this condition is for : "users entered nothing, stay in the loop and do nothing!"
                else if (split[0] == "add")
                {
                    //This conditional block is complete, you do not need to modify this block.
                    for (int i = 1; i < split.Length - 1; i++)
                    {
                        split[i] = ConvertToNameCase(split[i]);
                    }
                    contactList.Add(new Contact() { Name = string.Join(" ", split, 1, split.Length - 2), Phone = long.Parse(split[split.Length - 1]) });
                }
                else if (split[0] == "delete")
                {
                    //ToDo
                    //Complete this block
                    //separate the phone number from the 'split' array
                    if (split.Length == 2)
                    {
                        long todeletePhoneNumber = long.Parse(split[1]);
                        //choose the method to find all contacts when given a phone number
                        Contact contactToDelete = FindContactGivenAPhone(contactList, todeletePhoneNumber);
                        //remove the contact from the contactList
                        if (contactToDelete != null) { 
                        contactList.Remove(FindContactGivenAPhone(contactList, todeletePhoneNumber));
                    }
                    }

                }
                else if (split[0] == "find")
                {
                    //ToDo
                    //Complete this block
                    //separate the correctly formatted name from the 'split' array
                    if (split.Length == 3)
                    {
                        string finduserName = ConvertToNameCase(split[1]);
                        //choose the method to find all contacts when given a user name
                        List<Contact> foundcontactsofName = FindAllContactsOfAGivenName(contactList, finduserName);
                        //choose method to display all contacts of that user name
                         DisplayAllContactsOfAUserName(foundcontactsofName, finduserName);
                        //NB: A user name can have one or more contact numbers
                    }
                }
                else if (split[0] == "update")
                {
                    //ToDo update <Old Number> <Updated Name> <New Number>

                       


                    //ToDo
                    //Complete this block
                    //separate old number from array the 'split' 

                    if (split.Length >= 6)
                    {

                        long removeOldNumber = long.Parse(split[1]);
                        //choose the method to find a contact when given the old phone number
                       Contact foundcontactofOldNumber = FindContactGivenAPhone(contactList, removeOldNumber) ;

                        //remove the contact containing the old phone number from the contactList
                        contactList.Remove(FindContactGivenAPhone(contactList, removeOldNumber));

                        //extract the correctly formatted new user name <Updated Name> and the <New Number> from the 'split' array
                        

                        //Add a new contact object into the contactList with <Updated Name> and <New Number>

                        Contact UpdateContact = new Contact();
                        UpdateContact.Name = split[1];
                        UpdateContact.Phone = long.Parse(split[1]);
                    


                     

                    }
                }
                else
                {
                    Console.WriteLine("Unknown command! \nPlease enter command in correct format...");
                }
            } while (true);
        }
    }
}






//Sample Input/output:

/*
//when the following commands are executed, the program produces the following output:

add Mahbub Murshed 1234567890
Add Susan Harper 1111111111
Add Mahbub Murshed 3333333333
add David alwright 7777777777
add supreet kaur 2222222222
findall
find mahbub murshed
delete 1111111111
delete 1234567890
findall
UPDATE 3333333333 MAHBUB MURSHED BOWVALLEY COLLEGE 5555222211
FINDALL
exit
*/

/*
//Output
Enter a command:
add Mahbub Murshed 1234567890
 
Enter a command:
Add Susan Harper 1111111111
 
Enter a command:
Add Mahbub Murshed 3333333333
 
Enter a command:
add David alwright 7777777777
 
Enter a command:
add supreet kaur 2222222222
 
Enter a command:
findall
 
All Contacts from the phonebook:
 
Name: Mahbub Murshed, Phone: 1234567890
Name: Susan Harper, Phone: 1111111111
Name: Mahbub Murshed, Phone: 3333333333
Name: David Alwright, Phone: 7777777777
Name: Supreet Kaur, Phone: 2222222222
 
Enter a command:
find mahbub murshed
 
All Contacts of Mahbub Murshed:
Contact No 1: 1234567890
Contact No 2: 3333333333
 
Enter a command:
delete 1111111111
 
Enter a command:
delete 1234567890
 
Enter a command:
findall
 
All Contacts from the phonebook:
 
Name: Mahbub Murshed, Phone: 3333333333
Name: David Alwright, Phone: 7777777777
Name: Supreet Kaur, Phone: 2222222222
 
Enter a command:
UPDATE 3333333333 MAHBUB MURSHED BOWVALLEY COLLEGE 5555222211
 
Enter a command:
FINDALL
 
All Contacts from the phonebook:
 
Name: David Alwright, Phone: 7777777777
Name: Supreet Kaur, Phone: 2222222222
Name: Mahbub Murshed Bowvalley College, Phone: 5555222211
 
Enter a command:
exit
 
 */
