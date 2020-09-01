using System;
using System.Collections.Generic;

namespace Chapter04
{
    public static class Lookups
    {
        public class WorkItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

        public class Label
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ConsoleColor BackColor { get; set; }
            public ConsoleColor TextColor { get; set; }
        }

        public class WorkItemLabel
        {
            public int WorkItemId { get; set; }
            public int LabelId { get; set; }
        }

        public static IEnumerable<WorkItem> SampleWorkItems() => new WorkItem[]
        {
            new WorkItem() { Id = 1000, Title = "the first work item" },
            new WorkItem() { Id = 1001, Title = "another work item here" },
            new WorkItem() { Id = 1002, Title = "the third work item" },
            new WorkItem() { Id = 1003, Title = "a work item of distinction" },
            new WorkItem() { Id = 1004, Title = "a work item of great signifigance" },
            new WorkItem() { Id = 1005, Title = "work item without labels" },
            new WorkItem() { Id = 1006, Title = "a final work item" }
        };

        public static IEnumerable<Label> SampleLabels() => new Label[]
        {
            new Label() { Id = 1, Name = "performance", BackColor = ConsoleColor.Blue, TextColor = ConsoleColor.White },
            new Label() { Id = 2, Name = "security", BackColor = ConsoleColor.Magenta, TextColor = ConsoleColor.Blue },
            new Label() { Id = 3, Name = "metrics", BackColor = ConsoleColor.Green, TextColor = ConsoleColor.Black },
            new Label() { Id = 4, Name = "front-end", BackColor = ConsoleColor.Yellow, TextColor = ConsoleColor.Black }
        };

        public static IEnumerable<WorkItemLabel> WorkItemLabels() => new WorkItemLabel[]
        {
            new WorkItemLabel() { WorkItemId = 1000, LabelId = 3 },
            new WorkItemLabel() { WorkItemId = 1000, LabelId = 2 },
            new WorkItemLabel() { WorkItemId = 1001, LabelId = 1 },
            new WorkItemLabel() { WorkItemId = 1002, LabelId = 3 },
            new WorkItemLabel() { WorkItemId = 1003, LabelId = 1 },
            new WorkItemLabel() { WorkItemId = 1003, LabelId = 2 },
            new WorkItemLabel() { WorkItemId = 1003, LabelId = 3 },
            new WorkItemLabel() { WorkItemId = 1004, LabelId = 4 },
            new WorkItemLabel() { WorkItemId = 1004, LabelId = 1 },
            new WorkItemLabel() { WorkItemId = 1006, LabelId = 1 }
        };
    }
}
