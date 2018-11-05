using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCore.Business.Dto
{
    public class ToDoMainDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int CountTask { get; set; }
        public int CountReminder { get; set; }
    }
}
