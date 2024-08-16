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
        public static ProjectsDto ToProjectDto(this Projects projects)
        {
            return new ProjectsDto
            {
                ID = projects.ID,
                Name = projects.Name,
                Description = projects.Description,
                StartDate = projects.StartDate,
                EndDate = projects.EndDate,
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