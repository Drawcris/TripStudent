using AutoMapper;
using TripStudent.Models;
using TripStudent.ViewModel;

namespace TripStudent.AutoMapper
{
    public class TripAutoMapper : Profile
    {

        public TripAutoMapper()
        {
            CreateMap<TripViewModel, Trip>()
                .ForMember(x => x.Destination, opt => opt.MapFrom(src => src.Destination.ToUpperInvariant()))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.StartDate, opt => opt.MapFrom(src => src.StartDate.ToUniversalTime()))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(src => src.EndDate.ToUniversalTime()))
                .ReverseMap();
            CreateMap<StudentViewModel, Student>()
                .ForMember(x => x.name, opt => opt.MapFrom(src => src.name.ToUpperInvariant()))
                .ForMember(x => x.lastname, opt => opt.MapFrom(src => src.lastname.ToUpperInvariant()))
                .ForMember(x => x.email, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ReservationViewModel, Reservation>()
               .ForMember(x => x.reservation_date, opt => opt.MapFrom(src => src.reservation_date.ToUniversalTime()))
               .ForMember(x => x.status, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
