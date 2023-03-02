// See https://aka.ms/new-console-template for more information


using Lyntest17223;
using System.Diagnostics;


#region Opgave 2

Cykel c1 = new Cykel(434, "Everton", 2018);
Cykel c2 = new Cykel(565, "Avenue", 2020);
Cykel c3 = new Cykel(387, "Everton", 2021);
Cykel c4 = new Cykel(874, "Everton", 2017);
Cykel c5 = new Cykel(534, "KOGA", 2023);
Cykel c6 = new Cykel(765, "Everton", 2021);

//En måde at tilføje til listen 
List<Cykel> list = new List<Cykel> { c1, c2, c3 };
//En anden måde, at tilføje til listen
list.Add(c4);
list.Add(c5);
list.Add(c6);

#endregion

#region Opgave 3
Console.WriteLine("Opgave 3. Cykler efter år 2020");
Console.WriteLine("Opgave 3 iterativ");
foreach (Cykel c in list)
{
    if (c.Aar>2020)
        Console.WriteLine(c.ToString());
}
Console.WriteLine("Opgave 3 FindAll + predicate/lambda");
foreach (Cykel c in list.FindAll(c=>c.Aar>2020))
{
    Console.WriteLine(c.ToString());
}

Console.WriteLine("Opgave 3 lINQ");
var opg3lQ = from c in list
           where c.Aar > 2020
           select c;

foreach (Cykel c in opg3lQ)
{ 
    Console.WriteLine(c.ToString()); 
}

Console.WriteLine("Opgave 3 LINQ FLUENT");
var opgFl = list.Where(c => c.Aar > 2020);
foreach (Cykel cykel in opgFl)
{
    Console.WriteLine(cykel.ToString());
}

#endregion


#region Opgave 4

Console.WriteLine("Cykel med laveste stelnr:");
Console.WriteLine("Opgave 4. Iterativ");
if (list.Count > 0)
{
    Cykel lowest = list[0];
    foreach (Cykel c in list)
    {
        if (lowest.Stelnr > c.Stelnr)
            lowest = c;
    }
    Console.WriteLine($"Laveste stelnr {lowest}");
}

Console.WriteLine("Opgave 4. Linq");
int lowestStelnr = (from cy in list select cy.Stelnr).ToList().Min();
Console.WriteLine("Laveste stelnr " + lowestStelnr);
var qAll = from c in list
                  where c.Stelnr == (from cy in list select cy.Stelnr).ToList().Min()
                  select c;
Console.WriteLine("Lavest stelnr linq " + qAll.First());

Console.WriteLine("Opgave 4. Fluent");
int lst= (list.Select(cy => cy.Stelnr).ToList()).Min();
Cykel lavestStelnrFl = list.Where( c => { return c.Stelnr == (list.Select(cy => cy.Stelnr).ToList()).Min(); } ).First();
Console.WriteLine("Laveste stelnr " + lavestStelnrFl.ToString());

#endregion


#region Opgave 5
Console.WriteLine("Opgave 5. Cyklerne sorteret efter stelnr:");
list.Sort(); // anvender CompareTo i class Cykel
foreach (Cykel c in list)
    Console.WriteLine(c);
#endregion


#region Opgave 6

Console.WriteLine("Opgave 6 Iterativ. Alle cykler af mærket Everton:");
foreach (Cykel c in list)
{
    if (c.Model == "Everton")
        Console.WriteLine(c);
}
Console.WriteLine("Opgave 6 FindAll. Alle cykler af mærket Everton:");
List<Cykel> alleEverton = list.FindAll(c => c.Model == "Everton");
foreach(Cykel c in alleEverton)
    Console.WriteLine(c.ToString());

Console.WriteLine("Opgave 6 Linq. Alle cykler af mærket Everton:");
var qAllEvertonL = from c in list
                  where c.Model == "Everton"
                  select c;
foreach (Cykel c in qAllEvertonL)
    Console.WriteLine(c.ToString());

Console.WriteLine("Opgave 6 Fluent. Alle cykler af mærket Everton:");
var qAllEvertonFl = list.Where(c=> c.Model == "Everton");
foreach (Cykel c in qAllEvertonFl)
    Console.WriteLine(c.ToString());

#endregion



