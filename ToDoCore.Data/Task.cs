using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoCore.Data
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [MaxLength(500, ErrorMessage = "En çok 500 karakter")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [MaxLength(1000, ErrorMessage = "En çok 1000 karakter")]
        public string Description { get; set; }

        public int ToDoId { get; set; }
        public virtual ToDo ToDo { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
