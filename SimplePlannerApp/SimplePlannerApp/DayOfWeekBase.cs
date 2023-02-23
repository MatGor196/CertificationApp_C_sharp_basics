namespace SimplePlannerApp
{
    public abstract class DayOfWeekBase : IDayOfWeekBase
    {
        public abstract void ModifyDay(List<TaskInShedule> newTasks);
        public abstract void SortTasksByHours();
        public abstract void SortTasksByPriority();
    }
}
