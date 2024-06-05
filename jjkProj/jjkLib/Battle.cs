using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public class Battle
    {
        public string Place { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan Length { get; private set; }
        public (IJujutsu, IJujutsu) Opponents { get; private set; }
        public IJujutsu Winner { get; private set; }

        public Battle(string place, DateTime date, TimeSpan length, (IJujutsu, IJujutsu) opponents, IJujutsu winner)
        {
            Place = place;
            Date = date;
            Length = length;
            Opponents = opponents;
            Winner = winner;
        }
    }
}
