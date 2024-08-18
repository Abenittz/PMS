using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using yapms.Dtos.Tasks;
using yapms.Migrations;
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
                ProjectsID = tasksModel.ProjectsID
            };
        }

        public static Tasks ToTaskFromTaskDto(this CreateTasksDto taskDto, int projectId)
        {
            return new Tasks
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                ProjectsID = projectId
            };
        }

    }
}