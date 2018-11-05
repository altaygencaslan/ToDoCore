using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCore.Business.Dto
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime RemindTo { get; set; }

        public int TaskId { get; set; }
        //public TaskDto TaskDto { get; set; }
    }
}
