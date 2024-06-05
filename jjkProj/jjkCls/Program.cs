using jjkLib;
IEnumerable<Sorcerer> Sorcerers()
{
    foreach (var line in File.ReadAllLines("sorcerers.csv"))
        yield return Factory.CreateSorcerer(line);
}

IEnumerable<Curse> Curses()
{
    foreach (var line in File.ReadAllLines("curses.csv"))
        yield return Factory.CreateCurse(line);
}

IEnumerable<Battle> Battles()
{
    foreach (var line in File.ReadAllLines("battles.csv"))
        yield return Factory.CreateBattle(line);
}

Jujutsu.InitSorcerers(Sorcerers());
Jujutsu.InitCurses(Curses());
Jujutsu.InitBattles(Battles());

//Task 1. Average Sorcerer Cursed Energy
double avg = Jujutsu.Sorcerers.Average(e => e.CursedEnergyAmount);
Console.WriteLine($"Average cursed energy of sorcerers: {avg}");

//Task 2. Strongest Sorcerer
Sorcerer strongest = Jujutsu.Sorcerers.First(e => e.CursedEnergyAmount == Jujutsu.HighestCursedEnergyAmountAmongSorcerers);
Console.WriteLine($"Strongest jujutsu sorcerer:\n\tName: {strongest.Name}\n\tAge: {strongest.Age}\n\tCursed technique: {strongest.CursedTechnique}\n\tDomain: {strongest.DomainName}");

//Task 3. Would the the strongest sorcerer excorsise the strongest curse
var strongestSorcerer = Jujutsu.Sorcerers.FirstOrDefault(e => e.CursedEnergyAmount == Jujutsu.HighestCursedEnergyAmountAmongSorcerers);
var strongestCurse = Jujutsu.Curses.FirstOrDefault(e => e.CursedEnergyAmount == Jujutsu.HighestCursedEnergyAmountAmongCurses);

if (strongestSorcerer != null && strongestCurse != null)
{
    switch (Jujutsu.StrengthCheck(strongestSorcerer, strongestCurse))
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
}


//Task 4. Curse names in alphabetical order
Console.WriteLine("All curses names:");
foreach (var item in Jujutsu.CurseNames.OrderBy(e => e))
{
    Console.WriteLine("\t" + item);
}

//Task 5. Whose domain is stronger in the top 3
for (int i = 0; i < 3; i++)
{
    Sorcerer currentS = Jujutsu.Strongest3Sorcerers[i];
    Curse currentC = Jujutsu.Strongest3Curses[i];
    int clash = Jujutsu.DomainClash(currentS, currentC);

    string result = clash switch
    {
        0 => $"{currentS.Name}'s and {currentC.Name}'s domains are equally strong!",
        1 => $"{currentS.Name}'s {currentS.DomainName} domain would defeat {currentC.Name}!",
        -1 => $"{currentC.Name}'s {currentC.DomainName} domain would defeat {currentS.Name}!",
        _ => ""
    };

    Console.WriteLine(result);
}

//Task 6. All domains' names in alphabetical order
Console.WriteLine("All domains in alphabetical order and it's user:");
Jujutsu.DomainNames().OrderBy(e => e).ToList().ForEach(e => Console.WriteLine($"\t{e} - {Jujutsu.GetDomainUser(e)}"));