using AutoMapper;
using TaskManager.Application.Features.Duty.Commands.CreateDuty;
using TaskManager.Application.Features.Duty.Commands.UpdateDuty;
using TaskManager.Application.Features.Duty.Queries.GetAllDuties;
using TaskManager.Application.Features.Duty.Queries.GetAllDutiesByPaging;

namespace TaskManager.Application.Interfaces.AutoMapper.Duty
{
    public class DutyProfile : Profile
    {
        public DutyProfile()
        {
            CreateMap<GetAllDutiesQueryResponse, Domain.Entities.Duty>().ReverseMap();
            CreateMap<CreateDutyCommandRequest, Domain.Entities.Duty>().ReverseMap();
            CreateMap<UpdateDutyCommandRequest, Domain.Entities.Duty>().ReverseMap();
            CreateMap<GetAllDutiesByPagingQueryResponse, Domain.Entities.Duty>().ReverseMap();


        }

    }
}
