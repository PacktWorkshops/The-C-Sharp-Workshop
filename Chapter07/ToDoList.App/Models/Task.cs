using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.App.Models
{
    public class Task
    {
        public Task()
        {
            Id = Guid.NewGuid();
        }

        public Task(string title, ETaskStatus status)
        {
            Id = Guid.NewGuid();
            Title = title;
            Status = status;
        }

        public Guid Id { get; set; }
        
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Due Date")]
        [Required]
        public DateTime? DueTo { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ETaskStatus Status { get; set; }

    }
}