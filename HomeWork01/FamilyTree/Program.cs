using FamilyTree.Controller;
using FamilyTree.Model;
using FamilyTree.Reposytory;
using FamilyTree.Service;
using FamilyTree.Views;

namespace FamilyTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemberController memberController = new (new View(), new FamylyMemberService(new FamilyMembersRepository()));
            FamilyMember fatherfather = new () { FirstName = "Василий", LastName = "Карпенко", 
                Birthday = new DateTime(1930, 11, 20), Gender = Gender.Male };
            FamilyMember fathermother = new () { FirstName = "Антонина", LastName = "Карпенко", 
                Birthday = new DateTime(1931, 12, 20), Gender = Gender.Female };
            FamilyMember father = new () { FirstName = "Олег", LastName = "Карпенко", 
                Birthday = new DateTime(1952, 11, 10), Gender = Gender.Male, Father = fatherfather, Mother = fathermother};
            FamilyMember matherfather = new () { FirstName = "Владимир", LastName = "Карташевич", 
                Birthday = new DateTime(1928, 8, 10), Gender = Gender.Male };
            FamilyMember mothermother = new () { FirstName = "Зоя", LastName = "Карташевич", 
                Birthday = new DateTime(1929, 2, 8), Gender = Gender.Female };
            FamilyMember mother = new () {FirstName = "Людмила", LastName = "Карпенко",
                Birthday = new DateTime(1954, 2, 8), Gender = Gender.Female, Father = matherfather, Mother = mothermother};
            FamilyMember sister = new () {FirstName = "Татьяна", LastName = "Якоб",
                Birthday = new DateTime(1976, 8, 25), Gender = Gender.Female, Father = father, Mother = mother};
            FamilyMember me = new () {FirstName = "Александр", LastName = "Карпенко",
                Birthday = new DateTime(1981, 10, 6), Gender = Gender.Male, Father = father, Mother = mother};
            FamilyMember wifemotherfather = new () {FirstName = "Сергей", LastName = "Андрукевич",
                Birthday = new DateTime(1935, 4, 8), Gender = Gender.Male};
            FamilyMember wifemother = new () {FirstName = "Валентина", LastName = "Туркова",
                Birthday = new DateTime(1956, 3, 11), Gender = Gender.Female, Father = wifemotherfather};
            FamilyMember wife = new () {FirstName = "Наталья", LastName = "Карпенко",
                Birthday = new DateTime(1983, 6, 12), Gender = Gender.Female, Mother = wifemother};
            FamilyMember daughter = new () {FirstName = "Евгения", LastName = "Карпенко",
                Birthday = new DateTime(2017, 1, 11), Gender = Gender.Female, Father = me, Mother = wife};
           

            memberController.Add([fatherfather, fathermother, father, matherfather, mothermother, mother, sister, me, wife, daughter]);

            memberController.Print("Сведения обо мне");
            memberController.Print(me);

            memberController.Print("Мои дедушки");
            memberController.Print(memberController.GetGrandFathers(me));

            memberController.Print("Мои бабушки");
            memberController.Print(memberController.GetGrandMothers(me));


            memberController.Print("Моя жена");
            memberController.Print(memberController.GetSpouse(me));

            memberController.Print("Дерево моей дочери");
            memberController.PrintTree(4, daughter);

        }
    }
}
