using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCore.Business.Dto
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<TaskDto> TaskDtos { get; set; }
    }
}
