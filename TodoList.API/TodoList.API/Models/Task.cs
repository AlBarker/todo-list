using System;

namespace TodoList.API.Models
{
    public class Task : BaseEntity
    {
        public Task() { }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }
    }
}
