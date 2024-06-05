using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public enum Emotion
    {
        Gluttony,
        Lust,
        Greed,
        Despair,
        Wrath,
        Sloth,
        Pride
    }
    public enum Grade
    {
        Special,
        First,
        Second,
        Third,
        Fourth
    }
    public enum Gender
    {
        Male,
        Female
    }
    public class Jujutsu
    {
        public static List<Sorcerer> Sorcerers { get; private set; } = new List<Sorcerer>();
        public static List<Curse> Curses { get; private set; } = new List<Curse>();
        public static List<Battle> Battles { get; private set; } = new List<Battle>();

        public static IJujutsu? Get(string name)
        {
            return Sorcerers.FirstOrDefault(e => e.Name == name) ?? (IJujutsu?)Curses.FirstOrDefault(e => e.Name == name);
        }

        public static void InitSorcerers(IEnumerable<Sorcerer> sorcerers)
        {
            Sorcerers = sorcerers.ToList();
        }

        public static void InitCurses(IEnumerable<Curse> curses)
        {
            Curses = curses.ToList();
        }

        public static void InitBattles(IEnumerable<Battle> battles)
        {
            Battles = battles.ToList();
        }

        public static int HighestCursedEnergyAmountAmongSorcerers => GetHighestCursedEnergyAmount(Sorcerers);

        public static int HighestCursedEnergyAmountAmongCurses => GetHighestCursedEnergyAmount(Curses);

        public static Sorcerer[] Strongest3Sorcerers => GetStrongest3(Sorcerers);

        public static Curse[] Strongest3Curses => GetStrongest3(Curses);

        private static int GetHighestCursedEnergyAmount<T>(List<T> list) where T : IJujutsu
        {
            return list.Any() ? list.Max(e => e.CursedEnergyAmount) : 0;
        }

        private static T[] GetStrongest3<T>(List<T> list) where T : IJujutsu
        {
            return list.OrderByDescending(e => e.CursedEnergyAmount).Take(3).ToArray();
        }

        public static int StrengthCheck(IJujutsu j1, IJujutsu j2)
        {
            return j1.CursedEnergyAmount.CompareTo(j2.CursedEnergyAmount);
        }


        public static string[] SorcererNames => Sorcerers.Select(e => e.Name).ToArray();

        public static string[] CurseNames => Curses.Select(e => e.Name).ToArray();

        public static List<string> DomainNames()
        {
            List<string> names = new();
            names.AddRange(Sorcerers.Where(e => e.CanUseDomainExpansion).Select(e => e.DomainName));
            names.AddRange(Curses.Where(e => e.CanUseDomainExpansion).Select(e => e.DomainName));
            return names;
        }

        public static int DomainClash(IJujutsu j1, IJujutsu j2)
        {
            if (!j1.CanUseDomainExpansion && !j2.CanUseDomainExpansion)
                return 0;
            if (!j1.CanUseDomainExpansion)
                return -1;
            if (!j2.CanUseDomainExpansion)
                return 1;
            return StrengthCheck(j1, j2);
        }

        public static string GetDomainUser(string domain)
        {
            var sorcerer = Sorcerers.FirstOrDefault(e => e.DomainName == domain);
            if (sorcerer != null)
                return sorcerer.Name;

            var curse = Curses.FirstOrDefault(e => e.DomainName == domain);
            if (curse != null)
                return curse.Name;

            return "none";
        }

    }
}
