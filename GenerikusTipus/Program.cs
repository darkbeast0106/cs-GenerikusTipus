using GenerikusTipus;

BuszAtszallas("102.txt", "105.txt");
    
void BuszAtszallas(string egyikFajlNev, string masikFajlNev)
{
    Set<string> egyikBuszMegalloi = HalmazFajlbol(egyikFajlNev);
    Set<string> masikBuszMegalloi = HalmazFajlbol(masikFajlNev);
    Set<string> kozosMegallok = egyikBuszMegalloi.Intersection(masikBuszMegalloi);
    Console.WriteLine("Az egyik buszról a másikra {0} helyen lehet átszállni. Ezek a megállók:" +
        "\n{1}", kozosMegallok.Size, kozosMegallok);
}

Set<string> HalmazFajlbol(string fajlNev)
{
    Set<string> halmaz = new Set<string>();
    using (var reader = new StreamReader(fajlNev))
    {
        while (!reader.EndOfStream)
        {
            halmaz.Add(reader.ReadLine());
        }
    }
    return halmaz;
}