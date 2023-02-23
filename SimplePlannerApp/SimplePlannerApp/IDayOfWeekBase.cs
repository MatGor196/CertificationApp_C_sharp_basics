namespace SimplePlannerApp
{
    public interface IDayOfWeekBase
    {
        public void ModifyDay(List<TaskInShedule> newTasks);
        public void SortTasksByHours();
        public void SortTasksByPriority();
    }
}
