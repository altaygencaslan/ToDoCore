using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToDoCore.Business.Dto;
using ToDoCore.Business.Interfaces;
using ToDoCore.Data;

namespace ToDoCore.Business.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private AppContext appContext;
        public ToDoRepository(AppContext context)
        {
            appContext = context;
        }

        public ToDoDto Create(ToDoDto dto)
        {
            ToDo toDo = ConvertToEntity(dto);
            appContext.ToDo.Add(toDo);
            Save();

            return ConverToDto(toDo);
        }

        public void Delete(ToDoDto dto)
        {
            appContext.ToDo.Remove(ConvertToEntity(dto));
            Save();
        }

        public IList<ToDoDto> List()
        {
            return appContext.ToDo
                             .Select(s => new ToDoDto
                             {
                                 Id = s.Id,
                                 Subject = s.Subject,
                                 Description = s.Description,
                                 CreateDate = s.CreateDate,
                                 //TaskDtos = s.Tasks
                             })
                             .ToList();
        }

        public ToDoDto Read(int id)
        {
            return appContext.ToDo
                             .Where(w => w.Id == id)
                             .Select(s => new ToDoDto
                             {
                                 Id = s.Id,
                                 Subject = s.Subject,
                                 Description = s.Description,
                                 CreateDate = s.CreateDate,
                                 TaskDtos = s.Tasks.Select(st => new TaskDto
                                 {
                                     Id = st.Id,
                                     Subject = st.Subject,
                                     Description = st.Description,
                                     ReminderDtos = st.Reminders.Select(sr => new ReminderDto
                                     {
                                         Id = sr.Id,
                                         Message = sr.Message,
                                         RemindTo = sr.RemindTo
                                     }).ToList()
                                 }).ToList()
                             })
                             .FirstOrDefault();
        }

        public void Update(ToDoDto dto)
        {
            var todoItem = appContext.ToDo
                                     .Where(w => w.Id == dto.Id)
                                     .FirstOrDefault();

            if (todoItem != null)
            {
                todoItem.Subject = dto.Subject;
                todoItem.Description = dto.Description;
                todoItem.CreateDate = dto.CreateDate;

                Save();
            }
        }

        private ToDo ConvertToEntity(ToDoDto dto)
        {
            return new ToDo
            {
                Id = dto.Id,
                Subject = dto.Subject,
                Description = dto.Description,
                CreateDate = dto.CreateDate,
                //Tasks = 
            };
        }

        private ToDoDto ConverToDto(ToDo entity)
        {
            return new ToDoDto
            {
                Id = entity.Id,
                Subject = entity.Subject,
                Description = entity.Description,
                CreateDate = entity.CreateDate,
                //TaskDtos = 
            };
        }

        public void Save()
        {
            appContext.SaveChanges();
        }

        public IList<ToDoMainDto> ListForMain(string keyword)
        {
            IQueryable<ToDo> query = appContext.ToDo;
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(w => w.Subject.Contains(keyword) ||
                                w.Description.Contains(keyword));

            IList<ToDoMainDto> dtoList = query.Select(s => new ToDoMainDto
            {
                Id = s.Id,
                Subject = s.Subject.Substring(0, (s.Subject.Length > 20 ? 20 : s.Subject.Length)),
                Description = s.Description.Substring(0, (s.Description.Length > 50 ? 50 : s.Description.Length)),
                CreateDate = s.CreateDate,
                CountTask = s.Tasks.Count,
                CountReminder = s.Tasks.SelectMany(x => x.Reminders).Count()
            })
                                                        .ToList();

            return dtoList;
        }
    }
}
