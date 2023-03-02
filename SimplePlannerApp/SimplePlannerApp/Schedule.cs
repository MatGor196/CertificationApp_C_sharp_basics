namespace SimplePlannerApp
{
    public class Schedule : ISchedule
    {
        public List<DayOfWeek> DaysList { get; private set; }
        private bool hoursWereChoosen;

        public Schedule()
        {
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
        {
            DaysList[choosenDay].ModifyDay(newTasks);
            SetDisplay();
        }

        public void SetDisplay()
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
        {
            hoursWereChoosen = userChoose;
            SetDisplay();
        }

        public void ResetDay(int dayIndex)
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