using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yapms.Dtos.Project;
using yapms.Models;

namespace yapms.Mappers
{
    public static class ProjectMappers
    {
        public static ProjectsDto ToProjectDto(this Projects projectModel)
        {
            return new ProjectsDto
            {
                ID = projectModel.ID,
                Name = projectModel.Name,
                Description = projectModel.Description,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate,
            };
        }
        public static Projects ToProjectFromProjectDto(this CreateProjectRequestDto projectDto){
            return new Projects{
                Name = projectDto.Name,
                Description = projectDto.Description,   
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate
            };
        }
    }
}