using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoCore.Business.Dto;
using ToDoCore.Business.Interfaces;

namespace ToDoCore.Web.Controllers
{
    public class ToDoController : Controller
    {
        IToDoRepository toDoRepository;
        ITaskRepository taskRepository;
        IReminderRepository reminderRepository;
        public ToDoController(IToDoRepository _toDorepository, ITaskRepository _taskRepository, IReminderRepository _reminderRepository)
        {
            toDoRepository = _toDorepository;
            taskRepository = _taskRepository;
            reminderRepository = _reminderRepository;
        }

        public IActionResult Index()
        {
            return View(toDoRepository.ListForMain(string.Empty));
        }

        public PartialViewResult Search(string keyword)
        {
            return PartialView("_ToDoList", toDoRepository.ListForMain(keyword));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ToDoDto());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = toDoRepository.Read(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = toDoRepository.Read(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ToDoDto toDoItem)
        {
            toDoRepository.Update(toDoItem);
            return View(toDoItem);
        }

        [HttpPost]
        public JsonResult Create(ToDoDto toDoItem)
        {
            toDoItem = toDoRepository.Create(toDoItem);
            return Json(toDoItem);
        }

        [HttpGet]
        public IActionResult TaskModal(int id, int todoid)
        {
            TaskDto taskDto;
            if (id > 0)
                taskDto = taskRepository.Read(id);
            else
                taskDto = new TaskDto { ToDoId = todoid };

            return PartialView("_TaskModal", taskDto);
        }

        [HttpPost]
        public JsonResult SaveTask(TaskDto taskItem)
        {
            if (taskItem.Id > 0)
                taskRepository.Update(taskItem);
            else
                taskItem = taskRepository.Create(taskItem);

            return Json(taskItem);
        }

        [HttpGet]
        public IActionResult ReminderModal(int id, int taskid)
        {
            ReminderDto reminderDto;
            if (id > 0)
                reminderDto = reminderRepository.Read(id);
            else
                reminderDto = new ReminderDto { TaskId = taskid, RemindTo = DateTime.Now };

            return PartialView("_ReminderModal", reminderDto);
        }

        [HttpPost]
        public JsonResult SaveReminder(ReminderDto reminderItem)
        {
            if (reminderItem.Id > 0)
                reminderRepository.Update(reminderItem);
            else
                reminderItem = reminderRepository.Create(reminderItem);

            return Json(reminderItem);
        }
    }
}