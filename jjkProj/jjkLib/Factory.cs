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
            var split = line.Split(';');

            string name = split[0];
            Grade grade = ParseEnum<Grade>(split[1]);
            int age = int.Parse(split[2]);
            Gender gender = ParseEnum<Gender>(split[3]);
            string ct = split[4];
            int cea = int.Parse(split[5]);
            bool canUseDomain = bool.Parse(split[6]);
            string? domainName = canUseDomain ? split[7] : null;

            return new Sorcerer(name, grade, age, gender, ct, cea, canUseDomain, domainName);

            TEnum ParseEnum<TEnum>(string value) where TEnum : struct => (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static Curse CreateCurse(string line)
        {
            var split = line.Split(';');

            string name = split[0];
            Grade grade = ParseEnum<Grade>(split[1]);
            string? exc = split[2] == "null" ? null : split[2];
            Emotion em = ParseEnum<Emotion>(split[3]);
            bool canUseDomain = bool.Parse(split[4]);
            string? domainName = canUseDomain ? split[5] : null;
            string ct = split[6];
            int cea = int.Parse(split[7]);

            return new Curse(name, grade, exc, em, canUseDomain, ct, domainName, cea);

            TEnum ParseEnum<TEnum>(string value) where TEnum : struct => (TEnum)Enum.Parse(typeof(TEnum), value);
        }


        public static Battle CreateBattle(string line)
        {
            var split = line.Split(';');

            string place = split[0];
            DateTime date = DateTime.Parse(split[1]);
            TimeSpan length = TimeSpan.Parse(split[2]);

            var opp1 = GetJujutsuOrThrow(split[3]);
            var opp2 = GetJujutsuOrThrow(split[4]);
            (IJujutsu, IJujutsu) opps = (opp1, opp2);

            IJujutsu winner = GetJujutsuOrThrow(split[5]);

            return new Battle(place, date, length, opps, winner);

            IJujutsu GetJujutsuOrThrow(string name)
            {
                var jujutsu = Jujutsu.Get(name);
                if (jujutsu == null)
                {
                    throw new Exception("Sorcerer or Curse not in data!");
                }
                return jujutsu;
            }
        }

    }
}
