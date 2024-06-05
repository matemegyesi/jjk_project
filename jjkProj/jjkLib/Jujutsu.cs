﻿using System;
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
        public static List<Sorcerer> Sorcerers { get; private set; }
        public static List<Curse> Curses { get; private set; }
        public static List<Battle> Battles { get; private set; }
        public static IJujutsu? Get(string name)
        {
            if (Sorcerers.Exists(e => e.Name == name))
                return Sorcerers.First(e => e.Name == name);
            else if (Curses.Exists(e => e.Name == name))
                return Curses.First(e => e.Name == name);
            return null;
        }

        public static void InitSorceres(IEnumerable<Sorcerer> sors)
        {
            Sorcerers = sors.ToList();
        }
        public static void InitCurses(IEnumerable<Curse> curs)
        {
            Curses = curs.ToList();
        }
        public static void InitBattles(IEnumerable<Battle> bats)
        {
            Battles = bats.ToList();
        }

        public static int HighestCursedEnergyAmountAmongSorcerers => Sorcerers.Max(e => e.CursedEnergyAmount);
        public static int HighestCursedEnergyAmountAmongCurses => Curses.Max(e => e.CursedEnergyAmount);
        public static int StrengthCheck(IJujutsu j1, IJujutsu j2)
        {
            if (j1.CursedEnergyAmount == j2.CursedEnergyAmount)
                return 0;
            else if (j1.CursedEnergyAmount > j2.CursedEnergyAmount)
                return 1;
            else
                return -1;
        }
    }
}