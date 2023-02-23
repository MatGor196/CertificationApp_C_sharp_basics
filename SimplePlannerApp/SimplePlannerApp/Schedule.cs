namespace SimplePlannerApp
{
    public class Schedule : ISchedule
        // Podstawowa klasa w programie zarządzająca grafikiem
        // (w programie głównym istnieje tylko jeden egzemplarz)
    {
        public List<DayOfWeek> DaysList { get; private set; }
        private bool hoursWereChoosen;

        public Schedule()
        {
            // W konstruktorze po inicjalizacji grafik zawiera listę siedmiu obiektów
            // dni tygodnia i każdy obiekt dnia tygodnia zarządza zadaniami na dany dzień
            DaysList = new List<DayOfWeek>();
            hoursWereChoosen = true;

            for (int i = 0; i <= 6; i++)
            {
                var dayToAdd = new DayOfWeek(i);
                DaysList.Add(dayToAdd);
            }

            SetDisplay();
        }

        public void ChangeDay(int choosenDay, List<TaskInShedule> newTasks)
            // Podstawowa funkcja modyfikująca jakąkolwiek listę. Przyjmuje
            // nową listę zadań dla danego dnia i jego numer, a potem wywołuje
            // funkcję zastępującą starą
        {
            DaysList[choosenDay].ModifyDay(newTasks);
            SetDisplay();
        }

        public void SetDisplay()
        // Funkcja wywoływana za każdym razem gdy nastąpi wewnętrzna zmiana listy
        // zadań któregokolwiek z dni. Jej zadaniem jest takie posegregowanie zadań
        // w wewnętrznych listach zadań danych dni, by były potem po kolei
        // wyświetlane zgodnie z wymaganiami
        {
            if (hoursWereChoosen == true)
            {
                foreach(var day in DaysList)
                {
                    day.SortTasksByHours();
                }
            }
            else
            {
                foreach (var day in DaysList)
                {
                    day.SortTasksByPriority();
                }
            }
        }

        public void SetDisplayToHours(bool userChoose)
            // Umożliwia ustawienie formatu wyświetlana z zewnątz
        {
            hoursWereChoosen = userChoose;
            SetDisplay();
        }

        public void ResetDay(int dayIndex)
            // Reset polega po prostu na zastąpieniu, aktualnej listy zadań
            // z danego dnia listą pustą
        {
            if (0 <= dayIndex && dayIndex <= 6)
            {
                var emptyList = new List<TaskInShedule>();
                this.ChangeDay(dayIndex, emptyList);
            }
        }

        public void ResetWeek()
        {
            for(int i = 0; i <= 6; i++)
            {
                ResetDay(i);
            }
        }
    }
}