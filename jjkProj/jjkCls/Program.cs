using jjkLib;
string[] sLines = File.ReadAllLines("sorcerers.csv");
string[] cLines = File.ReadAllLines("curses.csv");
string[] bLines = File.ReadAllLines("battles.csv");
IEnumerable<Sorcerer> Sorcerers(){
    foreach (var line in sLines)
        yield return Factory.CreateSorcerer(line);
}
IEnumerable<Curse> Curses()
{
    foreach (var line in cLines)
        yield return Factory.CreateCurse(line);
}
IEnumerable<Battle> Battles()
{
    foreach (var line in bLines)
        yield return Factory.CreateBattle(line);
}

Jujutsu.InitSorceres(Sorcerers());
Jujutsu.InitCurses(Curses());
Jujutsu.InitBattles(Battles());

//Task 1. Average Sorcerer Cursed Energy
double avg = Jujutsu.Sorcerers.Average(e => e.CursedEnergyAmount);
Console.WriteLine($"Average cursed energy of sorcerers: {avg}");
//Task 2. Strongest Sorcerer
Sorcerer strongest = Jujutsu.Sorcerers.First(e => e.CursedEnergyAmount == Jujutsu.HighestCursedEnergyAmountAmongSorcerers);
Console.WriteLine($"Strongest jujutsu sorcerer:\n\tName: {strongest.Name}\n\tAge: {strongest.Age}\n\tCursed technique: {strongest.CursedTechnique}\n\tDomain: {strongest.DomainName}");
//Task 3. Would the the strongest sorcerer excorsise the strongest curse
Curse cStrongest = Jujutsu.Curses.First(e => e.CursedEnergyAmount == Jujutsu.HighestCursedEnergyAmountAmongCurses);
int check = Jujutsu.StrengthCheck(strongest, cStrongest);
switch (check)
{
    case 0:
        Console.WriteLine("The strongest sorcerer and curse are equally strong!");
        break;
    case 1:
        Console.WriteLine("The strongest sorcerer would defeat the strongest curse!");
        break;
    case -1:
        Console.WriteLine("The strongest curse would defeat the strongest sorcerer!");
        break;
    default:
        break;
}