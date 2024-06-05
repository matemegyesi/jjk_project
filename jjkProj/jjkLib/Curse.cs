using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public class Curse : IJujutsu
    {
        public string Name { get; private set; }
        public Grade Grade { get; private set; }
        public string? Excorsist { get; private set; }
        public Emotion BirthEmotion { get; private set; }
        public bool CanUseDomainExpansion { get; private set; }
        public string? DomainName { get; private set; }
        public string CursedTechnique { get; private set; }
        public int CursedEnergyAmount { get; private set; }

        public Curse(string name, Grade grade, string excorsist, Emotion birthEmotion, bool canUseDomainExpansion, string cursedTechnique, string? domainName, int cursedEnergyAmount)
        {
            Name = name;
            Grade = grade;
            Excorsist = excorsist;
            BirthEmotion = birthEmotion;
            CanUseDomainExpansion = canUseDomainExpansion;
            DomainName = domainName;
            CursedTechnique = cursedTechnique;
            CursedEnergyAmount = cursedEnergyAmount;
        }
    }
}
