using System.Collections.Generic;

namespace TodoList.API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
