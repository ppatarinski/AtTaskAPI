using System.Collections.Generic;

namespace AtTaskAPI
{
    public class Task
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string objCode { get; set; }
        public double percentComplete { get; set; }
        public string plannedCompletionDate { get; set; }
        public string plannedStartDate { get; set; }
        public int priority { get; set; }
        public string progressStatus { get; set; }
        public string projectedCompletionDate { get; set; }
        public string projectedStartDate { get; set; }
        public string status { get; set; }
        public int taskNumber { get; set; }
        public string wbs { get; set; }
        public int workRequired { get; set; }
        public string referenceNumber { get; set; }
    }

    public class TaskCollection
    {
        public List<Task> data { get; set; }
    }
}
