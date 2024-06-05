using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public static class Factory
    {
        public static Sorcerer CreateSorcerer(string line)
        {
            string[] split = line.Split(';');
            string name = split[0];
            Grade grade = (Grade)Enum.Parse(typeof(Grade), split[1]);
            int age = int.Parse(split[2]);
            Gender gender = (Gender)Enum.Parse(typeof(Gender), split[3]);
            string ct = split[4];
            int cea = int.Parse(split[5]);
            bool canUseDomain = bool.Parse(split[6]);
            string? domainName = canUseDomain ? split[7] : null;
            return new Sorcerer(name, grade, age, gender, ct, cea, canUseDomain, domainName);
        }
        public static Curse CreateCurse(string line)
        {
            string[] split = line.Split(';');
            string name = split[0];
            Grade grade = (Grade)Enum.Parse(typeof(Grade), split[1]);
            string? exc = split[2] == "null" ? null : split[2];
            Emotion em = (Emotion)Enum.Parse(typeof(Emotion), split[3]);
            bool canUseDomain = bool.Parse(split[4]);
            string? domainName = canUseDomain ? split[5] : null;
            string ct = split[6];
            int cea = int.Parse(split[7]);
            return new Curse(name, grade, exc, em, canUseDomain, ct, domainName, cea);
        }

        public static Battle CreateBattle(string line)
        {
            string[] split = line.Split(';');
            string place = split[0];
            DateTime date = DateTime.Parse(split[1]);
            TimeSpan length = TimeSpan.Parse(split[2]);
            (IJujutsu, IJujutsu) opps;
            if (Jujutsu.Get(split[3]) != null && Jujutsu.Get(split[4]) != null)
                opps = (Jujutsu.Get(split[3]), Jujutsu.Get(split[4]));
            else
                throw new Exception("Sorcerer or Curse not in data!");
            IJujutsu winner;
            if (Jujutsu.Get(split[5]) != null)
                winner = Jujutsu.Get(split[5]);
            else
                throw new Exception("Sorcerer or Curse not in data!");
            return new Battle(place, date,length, opps, winner);
        }
    }
}
