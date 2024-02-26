using FamilyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Views
{
    internal class View
    {
        public void Print(String text)
        {
            Console.WriteLine(text);
        }
        public void Print(params FamilyMember[] familyMembers)
        {
            foreach (var familyMember in familyMembers)
            {
                if (familyMember != null)
                {
                    Console.WriteLine(familyMember.ToString());
                }
                else Console.WriteLine("---");
            }
        }
        public void Print(List<FamilyMember> familyMembers)
        {
            foreach (var familyMember in familyMembers)
            {
                if (familyMember != null)
                {
                    Console.WriteLine(familyMember.ToString());
                }
                else Console.WriteLine("---");
            }


        }
    }
}
