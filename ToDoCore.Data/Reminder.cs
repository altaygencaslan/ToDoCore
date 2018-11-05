using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoCore.Data
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [MaxLength(500, ErrorMessage = "En çok 500 karakter")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public DateTime RemindTo { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public int RemindType { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
