namespace SimplePlannerApp
{
    public class DayOfWeek : DayOfWeekBase
        // Istnieje dokładnie 7 instancji tej klasy w liście w klasie Schedule
    {
        private readonly string dayFileName;
        public string DayName { get; private set; }
        // Mimo że jest określony, odwołujemy się do dni raczej liczbami 0-6

        public List<TaskInShedule> ListOfTasks { get; private set; }

        public DayOfWeek(int numOfDay)
        {
            // Ustawienie zmiennych
            DayName = ReturnDayNameFromNumber(numOfDay);
            dayFileName = DayName + ".txt";
            ListOfTasks = new List<TaskInShedule>();

            // Jeśli istnieje plik odpowiadający danemu dniu
            // zczytujemy z niego wszystkie zadania
            if (File.Exists(dayFileName))
            {
                ReadMemoryFromFile();
            }
        }

        public override void ModifyDay(List<TaskInShedule> newTasks)
        // Zastępujemy listę zadań nową i zapisujemy ją do pliku
        // Standardowa funkcja do modyfikowania list zadań w danych dniach
        {
            ListOfTasks = newTasks;
            WriteMemoryToFile();
        }

        public override void SortTasksByHours()
        {
            ListOfTasks.Sort(CompareTasksByHour);
        }

        public override void SortTasksByPriority()
        {
            ListOfTasks.Sort(CompareTasksByPriority);
        }

        private string ReturnDayNameFromNumber(int number)
            // Istnieje tylko na potrzeby stworzenia nazwy pliku do zapisu
            // zadań na dany dzień
        {
            switch (number) 
            {
                case 0:
                    return "Poniedziałek";
                case 1:
                    return "Wtorek";
                case 2:
                    return "Środa";
                case 3:
                    return "Czwartek";
                case 4:
                    return "Piątek";
                case 5:
                    return "Sobota";
                case 6:
                    return "Niedziela";
                default:
                    return null;
            }
        }

        private void ReadMemoryFromFile()
            // Wczytanie zadań z pliku
        {
            

            using (var readStream = File.OpenText(dayFileName))
            {
                var line = readStream.ReadLine();
                if (line == "poprawnie zapisany plik")
                {
                    while (true)
                    {
                        var description = readStream.ReadLine();
                        var hour = readStream.ReadLine();
                        var priority = readStream.ReadLine();

                        if (description == null)
                            break;

                        var loadedTask = new TaskInShedule(description, int.Parse(hour), int.Parse(priority));
                        ListOfTasks.Add(loadedTask);
                    }
                }
            }
        }

        private void WriteMemoryToFile()
            // Zapis zadań do pliku
        {
            using (var writeStream = new StreamWriter(dayFileName))
            {
                writeStream.WriteLine("poprawnie zapisany plik");
                
                foreach(var taskFromList in ListOfTasks)
                {
                    writeStream.WriteLine(taskFromList.TaskDescription);
                    writeStream.WriteLine(taskFromList.TaskHour);
                    writeStream.WriteLine(taskFromList.TaskPriority);
                }
            }
        }

        // 2 funkcje do porównań zadań (potrzebne do ich sortowania)
        private int CompareTasksByHour(TaskInShedule task1, TaskInShedule task2)
        {
            if (task1.TaskHour == task2.TaskHour)
            {
                return 0;
            }
            else if (task1.TaskHour > task2.TaskHour)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private int CompareTasksByPriority(TaskInShedule task1, TaskInShedule task2)
        {
            if (task1.TaskPriority == task2.TaskPriority)
            {
                return 0;
            }
            else if (task1.TaskPriority > task2.TaskPriority)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
