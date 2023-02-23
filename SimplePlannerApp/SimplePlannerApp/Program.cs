using SimplePlannerApp;

// Mateusz Goraj

// STRUKTURA APLIKACJI
// Nieskończona pętla zawiera menu, które przekierowuje do odpowiednich
// procedur odpowiedzialnych za opcje w aplikacji z głównego menu
// Program zawiera 3 podstawowe klasy:
// * Schedule - będzie istniała tylko 1 instancja na cały program
// głównie przez jej metody wykonywane będą wszystkie operacje
// * DayOfWeek - będzie 7 instancji znajdujących się na liście w Schedule,
// będą one zawierać listy zadań z danego dnia
// * TaskInShedule - klasa model danych zawierająca opis zadania, godzinę
// wykonania i priorytet, tak by wygodnie można się było do nich odwoływać

string user_name = GetUserName();
Schedule schedule = new Schedule();

// Główna pętla programu
bool appRun = true;
while (appRun)
{
    // Podstawowe menu
    Console.WriteLine($"Witaj {user_name}!");
    Console.WriteLine("Oto twój osobisty terminarz. Powiedz mi co chcesz zrobić:");
    Console.WriteLine();

    Console.WriteLine("1. Zobaczyć swój plan");
    Console.WriteLine("2. Dodać lub zmienić plan na dany dzień tygodnia");
    Console.WriteLine("3. Zresetować dzień lub cały plan");
    Console.WriteLine("4. Wybrać sposób segregowania zadań");
    Console.WriteLine("5. Wyjść z aplikacji");

    Console.WriteLine();

    var choosenOptionStr = Console.ReadLine();

    if (int.TryParse(choosenOptionStr, out int choosenOption))
    {
        switch (choosenOption)
        {
            // Nazwy powinny mówić same za siebie
            case 1:
                DisplayPlan();
                break;
            case 2:
                AddToOrChangePlan();
                break;
            case 3:
                ResetDayOrPlan();
                break;
            case 4:
                ChooseSegregationWay();
                break;
            case 5:
                appRun = false;
                break;
            default:
                break;
        }
    }

    Console.Clear();
}

void DisplayPlan()
    // W tym miejscu przechodzimy przez wszystkie dni i przez wszystkie zadania w danych dniach
    // by je wyświetlić
{
    Console.Clear();

    foreach (var currentDay in schedule.DaysList)
    {
        Console.WriteLine($"{currentDay.DayName}:");
        int indexOfTask = 1;
        foreach (var taskFromList in currentDay.ListOfTasks)
        {
            Console.WriteLine($"{indexOfTask}. {taskFromList.TaskHour}:00, {taskFromList.TaskPriority}: {taskFromList.TaskDescription}");
            indexOfTask++;
        }
        Console.WriteLine();
    }

    Console.ReadLine();
}

void AddToOrChangePlan()
{
    // Menu zmiany planu
    Console.Clear();
    
    Console.WriteLine("Który dzień chcesz zmienić?");
    Console.WriteLine("Poniedziałek: 1");
    Console.WriteLine("Wtorek: 2");
    Console.WriteLine("Środa: 3");
    Console.WriteLine("Czwartek: 4");
    Console.WriteLine("Piątek: 5");
    Console.WriteLine("Sobota: 6");
    Console.WriteLine("Niedziela: 7");
    Console.WriteLine("Wróć: 8");
    Console.WriteLine();
    Console.Write("(podaj liczbę): ");

    string choosenDayStr = Console.ReadLine();

    // Walidacja, czy jest możliwa konwersja wybranej opcji na int
    if(!int.TryParse(choosenDayStr, out int output))
    {
        Console.WriteLine("Nieprawidłowe dane wejściowe!");
        Console.ReadLine();
        return;
    }
    
    // Obniżone o 1, żeby było zgodne z numeracją tablic
    int choosenDay = int.Parse(choosenDayStr) - 1;

    switch(choosenDay)
    {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
            // Podawanie zadań dla danego dnia (każdy indeksowany od 0 do 6)
            Console.Clear();

            Console.WriteLine("Podaj nowe zadania na ten dzień:");
            Console.WriteLine("(Jeśli chcesz zakończyć wpisz w opisie 'w')");
            Console.WriteLine();

            // Lista na nowe zadania na dany dzień
            var newTasks = new List<TaskInShedule>();

            // Zbieramy do pamięci nowe zadania od użytkownika
            // i od razu dodajemy obiekty zadań do newTasks
            while (true)
            {
                Console.Write("Podaj opis: ");
                var description = Console.ReadLine();

                if (description == "w")
                    break;

                Console.Write("Podaj godzinę (0 - 23): ");

                string hourStr;
                int hour;
                while(true)
                {
                    hourStr = Console.ReadLine();

                    if (int.TryParse(hourStr, out hour))
                    {
                        if(0 <= hour && hour <= 23)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy zakres");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowe dane wejściowe");
                    }
                }

                Console.Write("Podaj priorytet (1 - 5): ");

                string priorityStr;
                int priority;
                while (true)
                {
                    priorityStr = Console.ReadLine();

                    if (int.TryParse(priorityStr, out priority))
                    {
                        if (1 <= priority && priority <= 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy zakres");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowe dane wejściowe");
                    }
                }

                var taskToAdd = new TaskInShedule(description, hour, priority);
                newTasks.Add(taskToAdd);

                Console.WriteLine();
            }

            // Przekazujemy nową listę, by zastąpiła aktualną z danego dnia
            schedule.ChangeDay(choosenDay, newTasks);
            break;
        case 7:
            return;
        default:
            // Walidacja zakresu
            Console.WriteLine("Nieprawidłowy zakres!");
            break;
    }

    Console.ReadLine();
}

void ResetDayOrPlan()
{
    // Menu resetu
    Console.Clear();

    Console.WriteLine("Co chciałbyś zresetować?");
    Console.WriteLine("Poniedziałek: 1");
    Console.WriteLine("Wtorek: 2");
    Console.WriteLine("Środa: 3");
    Console.WriteLine("Czwartek: 4");
    Console.WriteLine("Piątek: 5");
    Console.WriteLine("Sobota: 6");
    Console.WriteLine("Niedziela: 7");
    Console.WriteLine("Wszystko: 8");
    Console.WriteLine("Wróć: 9");
    Console.WriteLine();
    Console.Write("(podaj liczbę): ");

    string choosenDayStr = Console.ReadLine();

    // Walidacja resetu
    if (!int.TryParse(choosenDayStr, out int output))
    {
        Console.WriteLine("Nieprawidłowe dane wejściowe!");
        Console.ReadLine();
        return;
    }

    int choosenDay = int.Parse(choosenDayStr) - 1;

    string input;
    switch (choosenDay)
    {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
            // Reset konkretnego dnia
            Console.Clear();
            Console.WriteLine("Czy na pewno zresetować ten dzień?");
            Console.Write("[t/n]: ");

            input = Console.ReadLine();

            if (input == "t")
            {
                schedule.ResetDay(choosenDay);

                Console.WriteLine("Pomyślnie zresetowano dzień");
            }
            else
            {
                Console.WriteLine("Wycofano zmiany");
            }
            break;
        case 7:
            // Reset tygodnia
            Console.Clear();
            Console.WriteLine("Wybrano reset tygodnia");
            Console.WriteLine("Aby kontynuować wpisz: 'reset'");

            input = Console.ReadLine();

            if (input == "reset")
            {
                // Reset polega po prostu na zastapieniu wszystkich list zadań
                // dla każdego dnia listami pustymi
                schedule.ResetWeek();
                Console.Clear();
                Console.WriteLine("Pomyślnie zresetowano cały tydzień");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wycofano zmiany");
            }
            break;
        case 8:
            return;
        default:
            // Walidacja zakresu
            Console.WriteLine("Nieprawidłowy zakres!");
            break;
    }

    Console.ReadLine();
}

void ChooseSegregationWay()
{
    // Menu sortowania
    Console.Clear();

    Console.WriteLine("Czy zadania mają być segregowanie godzinowo, czy priorytetami?");
    Console.WriteLine("(Wpisz: 'g' - godziny, 'p' - priorytety)");
    Console.Write("[g/p]: ");

    string input = Console.ReadLine();

    // W zależności, czy użytkownik wybrał segregowanie z użyciem godzin, czy z użyciem
    // priorytetów wybieramy właściwą funkcję
    switch (input)
    {
        case "g":
            schedule.SetDisplayToHours(true);
            Console.WriteLine("Pomyślnie wprowadzono zmiany");
            break;
        case "p":
            schedule.SetDisplayToHours(false);
            Console.WriteLine("Pomyślnie wprowadzono zmiany");
            break;
        default:
            Console.WriteLine("Wycofano zmiany");
            break;
    }

    Console.ReadLine();
}

string GetUserName()
    // Tylko pobiera imię użytkownika z pliku, no chyba że nie istnieje,
    // wtedy procedura pyta użytkownika o imię
{
    string user_name;

    if (!File.Exists("user_name.txt"))
    {
        Console.WriteLine("PIERWSZE URUCHOMIENIE");
        Console.WriteLine("Witaj! Jak się nazywasz?");

        user_name = Console.ReadLine();

        using (var writeStream = File.AppendText("user_name.txt"))
        {
            writeStream.WriteLine(user_name);
        }

        Console.Clear();
    }
    else
    {
        using (var readStream = File.OpenText("user_name.txt"))
        {
            user_name = readStream.ReadLine();
        }
    }

    return user_name;
}
