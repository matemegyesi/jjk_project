using jjkLib;
namespace jjkTest
{
    [TestClass]
    public class JujutsuTest
    {
        private Sorcerer sorcerer1;
        private Sorcerer sorcerer2;
        private Curse curse1;
        private Curse curse2;
        private Curse curse3;
        private Battle battle1;
        private Battle battle2;

        [TestInitialize]
        public void SetUp()
        {
            sorcerer1 = new Sorcerer("Sorcerer1", Grade.First, 25, Gender.Male, "Cursed Technique 1", 100, true, "Domain1");
            sorcerer2 = new Sorcerer("Sorcerer2", Grade.Second, 30, Gender.Female, "Cursed Technique 2", 200, false, null);
            curse1 = new Curse("Curse1", Grade.Third, "Exorcist1", Emotion.Wrath, true, "Cursed Technique 3", "Domain2", 150);
            curse2 = new Curse("Curse2", Grade.Fourth, "Exorcist2", Emotion.Pride, false, "Cursed Technique 4", null, 250);
            curse3 = new Curse("Curse3", Grade.Fourth, "Exorcist3", Emotion.Pride, false, "Cursed Technique 5", null, 200);
            battle1 = new Battle("Place1", DateTime.Now, TimeSpan.FromHours(2), (sorcerer1, curse1), sorcerer1);
            battle2 = new Battle("Place2", DateTime.Now, TimeSpan.FromHours(1), (curse1, curse2), curse1);

            Jujutsu.InitSorcerers(new List<Sorcerer> { sorcerer1, sorcerer2 });
            Jujutsu.InitCurses(new List<Curse> { curse1, curse2 });
            Jujutsu.InitBattles(new List<Battle> { battle1, battle2 });
        }

        [TestMethod]
        public void GetReturnsCorrectJujutsu()
        {
            var result1 = Jujutsu.Get("Sorcerer1");
            var result2 = Jujutsu.Get("Curse1");
            Assert.AreEqual(sorcerer1, result1);
            Assert.AreEqual(curse1, result2);
        }

        [TestMethod]
        public void HighestCursedEnergyAmountAmongSorcerersReturnsCorrectValue()
        {
            var result = Jujutsu.HighestCursedEnergyAmountAmongSorcerers;
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void HighestCursedEnergyAmountAmongCursesReturnsCorrectValue()
        {
            var result = Jujutsu.HighestCursedEnergyAmountAmongCurses;
            Assert.AreEqual(250, result);
        }

        [TestMethod]
        public void Strongest3SorcerersReturnsCorrectValues()
        {
            var result = Jujutsu.Strongest3Sorcerers;
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(sorcerer2, result[0]);
            Assert.AreEqual(sorcerer1, result[1]);
        }

        [TestMethod]
        public void Strongest3CursesReturnsCorrectValues()
        {
            var result = Jujutsu.Strongest3Curses;

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(curse2, result[0]);
            Assert.AreEqual(curse1, result[1]);
        }

        [TestMethod]
        public void DomainNamesReturnsCorrectValues()
        {
            var result = Jujutsu.DomainNames();
            CollectionAssert.Contains(result, "Domain1");
            CollectionAssert.Contains(result, "Domain2");
        }

        [TestMethod]
        public void DomainClashReturnsCorrectValue()
        {
            var result1 = Jujutsu.DomainClash(sorcerer1, curse1);
            Assert.AreEqual(-1, result1);
        }

        [TestMethod]
        public void GetDomainUserReturnsCorrectUser()
        {
            var result1 = Jujutsu.GetDomainUser("Domain1");
            var result2 = Jujutsu.GetDomainUser("Domain2");
            var result3 = Jujutsu.GetDomainUser("Domain3");

            Assert.AreEqual("Sorcerer1", result1);
            Assert.AreEqual("Curse1", result2);
            Assert.AreEqual("none", result3);
        }
        [TestMethod]
        public void BattleResultIsCorrect()
        {
            Assert.AreEqual(sorcerer1, battle1.Winner);
            Assert.AreEqual(curse1, battle2.Winner);
        }

        [TestMethod]
        public void StrengthCheckReturnsCorrectResult()
        {
            var result1 = Jujutsu.StrengthCheck(sorcerer1, sorcerer2);
            var result2 = Jujutsu.StrengthCheck(curse1, curse2); 
            var result3 = Jujutsu.StrengthCheck(sorcerer2, curse3);

            Assert.AreEqual(-1, result1);
            Assert.AreEqual(-1, result2);
            Assert.AreEqual(0, result3);
        }
    }
}