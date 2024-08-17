using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using yapms.Dtos.Tasks;
using yapms.Models;

namespace yapms.Mappers
{
    public static class TaskMappers
    {
        public static TasksDto ToTasksDto(this Tasks tasksModel)
        {
            return new TasksDto
            {
                ID = tasksModel.ID,
                Title = tasksModel.Title,
                Description = tasksModel.Description,
                CreatedDate = tasksModel.CreatedDate,
                DueDate = tasksModel.DueDate,
            };
        }

        public static Tasks ToTaskFromTaskDto(this CreateTasksDto tasks)
        {
            return new Tasks
            {
                Title = tasks.Title,
                Description = tasks.Description,
                CreatedDate = tasks.CreatedDate,
                DueDate = tasks.DueDate,
            };
        }

    }
}