using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoCore.Business.Dto;

namespace ToDoCore.Business.Interfaces
{
    public interface IToDoRepository
    {
        ToDoDto Create(ToDoDto dto);
        ToDoDto Read(int id);
        IList<ToDoDto> List();
        IList<ToDoMainDto> ListForMain(string keyword);
        void Update(ToDoDto dto);
        void Delete(ToDoDto dto);
    }
}
