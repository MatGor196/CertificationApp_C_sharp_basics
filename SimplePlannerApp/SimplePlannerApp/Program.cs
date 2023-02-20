
string user_name = "";

if (!File.Exists("user_name.txt"))
{
    Console.WriteLine("PIERWSZE URUCHOMIENIE");
    Console.WriteLine("Witaj! Jak się nazywasz?");

    user_name = Console.ReadLine();

    using (var writeStream = File.AppendText("user_name.txt"))
    {
        writeStream.WriteLine(user_name);
    }
}
else
{
    using (var readStream = File.OpenText("user_name.txt"))
    {
        user_name = readStream.ReadLine();
    }
}

bool appRun = true;
while (appRun)
{
    Console.Clear();
    Console.WriteLine($"Witaj {user_name}!");
    Console.WriteLine("Oto twój osobisty terminarz. Powiedz mi co chcesz zrobić?");
    Console.WriteLine();

    Console.WriteLine("1. Zobaczyć swój plan");
    Console.WriteLine("2. Dodać lub zmienić plan na dany dzień tygodnia");
    Console.WriteLine("3. Zresetować plan na cały tydzień");
    Console.WriteLine("4. Wyjście z aplikacji");

    Console.WriteLine();

    var choosenOptionStr = Console.ReadLine();

    if (int.TryParse(choosenOptionStr, out int choosenOption))
    {
        switch (choosenOption)
        {
            case 1:
                Console.WriteLine("a");
                break;
            case 2:
                Console.WriteLine("a");
                break;
            case 3:
                Console.WriteLine("a");
                break;
            case 4:
                appRun = false;
                break;
            default:
                break;
        }
    }
}