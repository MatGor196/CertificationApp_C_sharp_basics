namespace SimplePlannerApp.Tests
{
    public class Tests
    {
        [Test]
        public void SheduleResetWeekTest()
        {
            var shedule = new Schedule();
            var emptyTasksList = new List<TaskInShedule>();

            shedule.ResetWeek();

            for (int i = 0; i <= 6; i++)
            {
                TasksListsEquality(shedule.DaysList[i].ListOfTasks, emptyTasksList);
            }
        }

        [Test]
        public void Shedule_ChangeDayTest()
        {
            var emptyTasksList = new List<TaskInShedule>();
            var shedule = new Schedule();

            shedule.ResetWeek();

            var listToAdd = new List<TaskInShedule>();

            listToAdd.Add(new TaskInShedule("", 10, 1));
            listToAdd.Add(new TaskInShedule("", 11, 2));
            listToAdd.Add(new TaskInShedule("", 12, 3));

            shedule.ChangeDay(3, listToAdd);

            for (int i = 0; i <= 6; i++)
            {
                if (i != 3)
                {
                    TasksListsEquality(shedule.DaysList[i].ListOfTasks, emptyTasksList);
                }
            }

            TasksListsEquality(shedule.DaysList[3].ListOfTasks, listToAdd);
        }

        [Test]
        public void Shedule_SetDisplayTest_ForTrue()
        {
            var shedule = new Schedule();
            shedule.ResetWeek();

            var listToAdd = new List<TaskInShedule>();
            listToAdd.Add(new TaskInShedule("", 12, 3));
            listToAdd.Add(new TaskInShedule("", 10, 1));
            listToAdd.Add(new TaskInShedule("", 13, 4));
            listToAdd.Add(new TaskInShedule("", 11, 2));
            shedule.ChangeDay(3, listToAdd);

            var listToCompare = new List<TaskInShedule>();
            listToCompare.Add(new TaskInShedule("", 10, 1));
            listToCompare.Add(new TaskInShedule("", 11, 2));
            listToCompare.Add(new TaskInShedule("", 12, 3));
            listToCompare.Add(new TaskInShedule("", 13, 4));

            shedule.SetDisplayToHours(true);

            TasksListsEquality(shedule.DaysList[3].ListOfTasks, listToCompare);
        }

        [Test]
        public void Shedule_SetDisplayTest_ForFalse()
        {
            var shedule = new Schedule();
            shedule.ResetWeek();

            var listToAdd = new List<TaskInShedule>();
            listToAdd.Add(new TaskInShedule("", 12, 3));
            listToAdd.Add(new TaskInShedule("", 10, 1));
            listToAdd.Add(new TaskInShedule("", 13, 4));
            listToAdd.Add(new TaskInShedule("", 11, 2));
            shedule.ChangeDay(3, listToAdd);

            var listToCompare = new List<TaskInShedule>();
            listToCompare.Add(new TaskInShedule("", 13, 4));
            listToCompare.Add(new TaskInShedule("", 12, 3));
            listToCompare.Add(new TaskInShedule("", 11, 2));
            listToCompare.Add(new TaskInShedule("", 10, 1));

            shedule.SetDisplayToHours(false);

            TasksListsEquality(shedule.DaysList[3].ListOfTasks, listToCompare);
        }

        public void TasksListsEquality(List<TaskInShedule> list1, List<TaskInShedule> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            if(list1.Count == list2.Count)
            {
                for(int i = 0; i < list1.Count; i++)
                {
                    Assert.AreEqual(list1[i].TaskDescription, list2[i].TaskDescription);
                    Assert.AreEqual(list1[i].TaskHour, list2[i].TaskHour);
                    Assert.AreEqual(list1[i].TaskPriority, list2[i].TaskPriority);
                }
            }
        }
    }
}