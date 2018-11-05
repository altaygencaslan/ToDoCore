using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCore.Business.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public int ToDoId { get; set; }
        public ICollection<ReminderDto> ReminderDtos { get; set; }
    }
}
