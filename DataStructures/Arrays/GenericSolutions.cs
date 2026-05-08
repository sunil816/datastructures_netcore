namespace DataStructures.Arrays;

public class TaskCount
{
    public char Task { get; set; }
    public int Count { get; set; }
}
public class GenericSolutions
{
    //TODO: Need to implement
    public int LeastInterval(char[] tasks, int n)
    {
        Dictionary<char, int> taskIntervalRequired = new Dictionary<char, int>();
        foreach (var taskName in tasks)
        {
            if (!taskIntervalRequired.ContainsKey(taskName))
            {
                taskIntervalRequired.Add(taskName, 0);
            }
            taskIntervalRequired[taskName] = taskIntervalRequired[taskName] + 1;
        }

        List<TaskCount> taskCounts = new List<TaskCount>();

        foreach (var taskName in taskIntervalRequired.Keys)
        {
            var taskCount = new TaskCount()
            {
                Task = taskName,
                Count = taskIntervalRequired[taskName],
            };
            taskCounts.Add(taskCount);
        }
        taskCounts.Sort((t1, t2) => t1.Count.CompareTo(t2.Count));
        
        return -1;
    }
}