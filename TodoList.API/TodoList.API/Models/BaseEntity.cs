using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace TodoList.API.Models
{
    public abstract class BaseEntity : TableEntity
    {
        //public string Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
