using AutoMapper;
using TodoList.Applications.Dtos;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<TodoTask, TodoTaskDto>().ReverseMap();
        }
    }
}
