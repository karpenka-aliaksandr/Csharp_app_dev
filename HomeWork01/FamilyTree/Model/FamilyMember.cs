using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FamilyTree.Model
{
    internal class FamilyMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public FamilyMember? Father { get; set; } = null;
        public FamilyMember? Mother { get; set; } = null;

        public override string ToString()
        {
            return $" Имя - \t\t\t{FirstName}\n Фамилия - \t\t{LastName}\n Дата рождения - \t{Birthday.ToShortDateString()}\n\n ";
        }

    }
}
