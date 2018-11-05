using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCore.Business.Dto;
using ToDoCore.Business.Interfaces;

namespace ToDoCore.Business.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private AppContext appContext;
        public TaskRepository(AppContext context)
        {
            appContext = context;
        }

        public TaskDto Create(TaskDto dto)
        {
            Data.Task task = ConvertToEntity(dto);
            appContext.Task.Add(task);
            Save();

            return ConverToDto(task);
        }

        public void Delete(TaskDto dto)
        {
            appContext.Remove(ConvertToEntity(dto));
            Save();
        }

        public IList<TaskDto> List()
        {
            return appContext.Task
                             .Select(s => new TaskDto
                             {
                                 Id = s.Id,
                                 Subject = s.Subject,
                                 Description = s.Description,
                                 ToDoId = s.ToDoId,
                                 //ReminderDto = s.Reminder
                             })
                             .ToList();
        }

        public TaskDto Read(int id)
        {
            return appContext.Task
                             .Where(w => w.Id == id)
                             .Select(s => new TaskDto
                             {
                                 Id = s.Id,
                                 Subject = s.Subject,
                                 Description = s.Description,
                                 ToDoId = s.ToDoId,
                                 //ReminderDto = s.Reminder
                             })
                             .FirstOrDefault();
        }

        public void Update(TaskDto dto)
        {
            var taskItem = appContext.Task.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (taskItem != null)
            {
                taskItem.Subject = dto.Subject;
                taskItem.Description = dto.Description;

                Save();
            }
        }

        private Data.Task ConvertToEntity(TaskDto dto)
        {
            return new Data.Task
            {
                Id = dto.Id,
                Subject = dto.Subject,
                Description = dto.Description,
                ToDoId = dto.ToDoId,
                //Reminder = dto.ReminderDto
            };
        }

        private TaskDto ConverToDto(Data.Task entity)
        {
            return new TaskDto
            {
                Id = entity.Id,
                Subject = entity.Subject,
                Description = entity.Description,
                ToDoId = entity.ToDoId,
                //TaskDtos = 
            };
        }

        public void Save()
        {
            appContext.SaveChanges();
        }
    }
}
