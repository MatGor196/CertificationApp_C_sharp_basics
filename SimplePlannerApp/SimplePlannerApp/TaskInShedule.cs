namespace SimplePlannerApp
{
    public class TaskInShedule
        // Klasa model danych
    {
        public string TaskDescription { get; private set; }
        public int TaskHour { get; private set; }
        public int TaskPriority { get; private set; }

        public TaskInShedule(string taskDescription, int taskHour, int taskPriority)
        {
            this.TaskDescription = taskDescription;
            this.TaskHour = taskHour;
            this.TaskPriority = taskPriority;
        }
    }
}
