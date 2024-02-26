using FamilyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Reposytory
{
    internal class FamilyMembersRepository
    {
        public List<FamilyMember> FamilyMembers { get; init; } = [];
        
        public void Add(FamilyMember familyMember)
        {
            FamilyMembers.Add(familyMember);
        }
    }
}
