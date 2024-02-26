using FamilyTree.Model;
using FamilyTree.Service;
using FamilyTree.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Controller
{
    internal class MemberController(View view, FamylyMemberService memberService)
    {
        private readonly View view = view;
        private readonly FamylyMemberService memberService = memberService;

        public List<FamilyMember> GetGrandFathers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = [member.Mother?.Father, member.Father?.Father];
            return grandFathers;
        }
        public List<FamilyMember> GetGrandMothers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = [member.Mother?.Mother, member.Father?.Mother];
            return grandFathers;
        }
        public FamilyMember GetSpouse(FamilyMember member)
        {
            foreach(FamilyMember fm in memberService.GetAll())
            {
                if (fm.Mother == member)
                {
                    return fm.Father;
                }
                if (fm.Father == member)
                {
                    return fm.Mother;
                }
            }
            return null;
        }

        public void Add(params FamilyMember[] famylyMembers)
        {
            foreach (var member in famylyMembers)
            {
                memberService.Add(member);
            }
            
        }



        public void Print(String text)
        {
            view.Print(text);
        }
        public void Print(params FamilyMember[] familyMembers)
        {
            view.Print(familyMembers);
        }
        public void PrintTree(int level, FamilyMember member)
        {
            if (level > 4) { level = 4; }
            if (level <= 1)
            {
                Print(member?.LastName + " " + member?.FirstName);
                return;
            }
            else
            {
                
                FamilyMember[] tree = new FamilyMember[(int)Math.Pow(2,level)-1];
                tree[0]= member;
                for (int i = 0; i < tree.Length/2; i++)
                {
                    tree[i * 2 + 1] = tree[i]?.Father;
                    tree[i * 2 + 2] = tree[i]?.Mother;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = level; i > 0; i--)
                {
                    int tab = -10 + 10 * ((int)Math.Pow(2,level - i));
                    sb.Append(' ',tab);
                    for (int j = (int)Math.Pow(2, i - 1) - 1 ; j < (int)Math.Pow(2, i) - 1; j++)
                    {
                        sb.Append(String.Format("{0,-"+320/(int)Math.Pow(2, i)+"}", tree[j]?.LastName + " " + tree[j]?.FirstName));
                    }
                    sb.Append("\n\n");
                }
                Print(sb.ToString());
            }
        }
        public void Print(List<FamilyMember> member)
        {
            view.Print(member);
        }

    }
}
