namespace SimplePlannerApp
{
    public interface ISchedule
    {
        public void ChangeDay(int choosenDay, List<TaskInShedule> newTasks);
        public void SetDisplay();
        public void SetDisplayToHours(bool userChoose);
        public void ResetDay(int dayIndex);
        public void ResetWeek();
    }
}
