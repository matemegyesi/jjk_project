using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public class Sorcerer : IJujutsu
    {
        public string Name { get; private set; }
        public Grade Grade { get; private set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public string CursedTechnique { get; private set; }
        public int CursedEnergyAmount { get; private set; }
        public bool CanUseDomainExpansion { get; private set; }
        public string? DomainName { get; private set; }

        public Sorcerer(string name, Grade grade, int age, Gender gender, string cursedTechnique, int cursedEnergyAmount, bool canUseDomainExpansion, string? domainName)
        {
            Name = name;
            Grade = grade;
            Age = age;
            Gender = gender;
            CursedTechnique = cursedTechnique;
            CursedEnergyAmount = cursedEnergyAmount;
            CanUseDomainExpansion = canUseDomainExpansion;
            DomainName = domainName;
        }
    }
}
