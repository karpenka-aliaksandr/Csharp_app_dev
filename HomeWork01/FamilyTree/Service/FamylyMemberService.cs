using FamilyTree.Model;
using FamilyTree.Reposytory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Service
{
    internal class FamylyMemberService(FamilyMembersRepository repository)
    {
        private readonly FamilyMembersRepository repository = repository;

        public void Add(FamilyMember familyMember)
        {
            repository.Add(familyMember);
        }
        public List<FamilyMember> GetAll()
        {
            return repository.FamilyMembers;
        }

    }
}
