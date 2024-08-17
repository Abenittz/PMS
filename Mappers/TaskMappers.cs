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
        public static TasksDto TasksDto(this Tasks tasksModel){
            return new TasksDto {
                Title = tasksModel.Title,
                Description = tasksModel.Description,
                CreatedDate = tasksModel.CreatedDate,
                DueDate = tasksModel.DueDate,
            };
        }
    }
}