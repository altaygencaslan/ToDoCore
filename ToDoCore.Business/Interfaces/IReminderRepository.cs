using System;
using System.Collections.Generic;
using System.Text;
using ToDoCore.Business.Dto;

namespace ToDoCore.Business.Interfaces
{
    public interface IReminderRepository
    {
        ReminderDto Create(ReminderDto dto);
        ReminderDto Read(int id);
        IList<ReminderDto> List();
        void Update(ReminderDto dto);
        void Delete(ReminderDto dto);
    }
}
