using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoCore.Business.Dto;
using ToDoCore.Business.Interfaces;
using ToDoCore.Data;

namespace ToDoCore.Business.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private AppContext appContext;
        public ReminderRepository(AppContext context)
        {
            appContext = context;
        }

        public ReminderDto Create(ReminderDto dto)
        {
            Reminder reminder = ConvertToEntity(dto);
            appContext.Reminder.Add(reminder);
            Save();

            return ConverToDto(reminder);
        }

        public void Delete(ReminderDto dto)
        {
            appContext.Reminder.Remove(ConvertToEntity(dto));
            Save();
        }

        public IList<ReminderDto> List()
        {
            return appContext.Reminder
                             .Select(s => new ReminderDto
                             {
                                 Id = s.Id,
                                 Message = s.Message,
                                 RemindTo = s.RemindTo,
                                 TaskId = s.TaskId,
                                 //TaskDto = s.Task
                             })
                             .ToList();

        }

        public ReminderDto Read(int id)
        {
            return appContext.Reminder
                             .Where(w => w.Id == id)
                             .Select(s => new ReminderDto
                             {
                                 Id = s.Id,
                                 Message = s.Message,
                                 RemindTo = s.RemindTo,
                                 TaskId = s.TaskId,
                                 //TaskDto = s.Task
                             })
                             .FirstOrDefault();
        }

        public void Update(ReminderDto dto)
        {
            var remindItem = appContext.Reminder.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (remindItem != null)
            {
                remindItem.Message = dto.Message;
                remindItem.RemindTo = dto.RemindTo;

                Save();
            }
        }

        private Reminder ConvertToEntity(ReminderDto dto)
        {
            return new Reminder
            {
                Id = dto.Id,
                Message = dto.Message,
                RemindTo = dto.RemindTo,
                TaskId = dto.TaskId,
                //Task = dto.TaskDto
            };
        }

        private ReminderDto ConverToDto(Reminder entity)
        {
            return new ReminderDto
            {
                Id = entity.Id,
                Message = entity.Message,
                RemindTo = entity.RemindTo,
                TaskId = entity.TaskId,
                //TaskDto = entity.Task
            };
        }

        public void Save()
        {
            appContext.SaveChanges();
        }
    }
}
