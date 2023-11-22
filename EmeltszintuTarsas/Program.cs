

List<string> osvenyek = new List<string>();
osvenyek.AddRange(File.ReadLines("osvenyek.txt").Select(s => s.Trim()));


List<int> dobasok;
dobasok = File.ReadAllText("dobasok.txt").Split(" ").Select(int.Parse).ToList();

//--------------------------------------------------------------------------------------------------------------------//
Console.WriteLine("\n2. feladat");
Console.WriteLine($"A dobások száma: {dobasok.Count()}");
Console.WriteLine($"Az ösvények száma: {osvenyek.Count()}");

//--------------------------------------------------------------------------------------------------------------------//
/*
 * Határozza meg, hogy melyik ösvény áll a legtöbb mezőből, és jelenítse meg az ösvény 
sorszámát és a mezők számát! Ha több ilyen is van, elegendő egyet megjelenítenie.
*/
//--------------------------------------------------------------------------------------------------------------------//
Console.WriteLine("\n3. feladat");
int osszesOsveny = 0;
for (int i = 1; i < osvenyek.Count; i++)
{
    if (osvenyek[i].Length > osvenyek[osszesOsveny].Length)
    {
        osszesOsveny = i;
    }
}
Console.WriteLine($"Az egyik leghosszabb a {osszesOsveny + 1}. ösvény és a hossza: {osvenyek[osszesOsveny].Length}");

//--------------------------------------------------------------------------------------------------------------------//
/*
 Olvassa be és tárolja el egy ösvény sorszámát és a játékot játszók számát (legalább 2,
legfeljebb 5)! A későbbiekben ezekkel az adatokkal dolgozzon!
 */
//--------------------------------------------------------------------------------------------------------------------//
Console.WriteLine("\n4. feladat:");

Console.Write("Adja meg egy ösvény sorszámát! ");
int osvenySorszam = Convert.ToInt32(Console.ReadLine());

Console.Write("Adja meg a játékosok számát! ");
int jatekosSzam = Convert.ToInt32(Console.ReadLine());

string osveny = osvenyek[osvenySorszam - 1];
//--------------------------------------------------------------------------------------------------------------------//
/*
 * Készítsen statisztikát a megadott sorszámú ösvény mezőiből! Jelenítse meg, hogy ez milyen
típusú mezőből mennyit tartalmaz! Ha egy adott típusú mező nem szerepel, akkor azt ne
jelenítse meg! (Megoldása teszteléséhez használja az első három ösvényt is, ezek ugyanis
nem tartalmaznak minden karaktert!)
*/
//--------------------------------------------------------------------------------------------------------------------//


Console.WriteLine("\n5. feladat");
Dictionary<char, int> ertek = new Dictionary<char, int>();
foreach (char betu in osveny)
{
    if (!ertek.ContainsKey(betu))
    {
        ertek[betu] = 0;
    }
    ertek[betu]++;
}

foreach (var i in ertek)
{
    Console.WriteLine($"{i.Key}: {i.Value} darab");
}
//--------------------------------------------------------------------------------------------------------------------//
/*
 Írja a kulonleges.txt fájlba, hogy a választott ösvény mely mezői különlegesek!
Soronként egy mezőt adjon meg a mező sorszámával és a mező típusát megadó karakterrel!
A két értéket egy tabulátor karakterrel válassza el egymástól!
 */
//--------------------------------------------------------------------------------------------------------------------//
File.WriteAllLines("kulonleges.txt",
    osveny.Select((mezo, sorszam) => mezo != 'M' ? $"{sorszam + 1}\t{mezo}" : null)
    .Where(line => line != null));
//--------------------------------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------------------------------//
