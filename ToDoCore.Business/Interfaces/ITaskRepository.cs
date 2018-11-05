using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoCore.Business.Dto;

namespace ToDoCore.Business.Interfaces
{
    public interface ITaskRepository
    {
        TaskDto Create(TaskDto dto);
        TaskDto Read(int id);
        IList<TaskDto> List();
        void Update(TaskDto dto);
        void Delete(TaskDto dto);
    }
}
