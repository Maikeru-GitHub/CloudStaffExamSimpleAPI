using AutoMapper;
using CloudStaffExamSimpleAPI.Models.Domain;
using CloudStaffExamSimpleAPI.Models.DTO;

namespace CloudStaffExamSimpleAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from AddPersonDto to Person domain model
            CreateMap<AddPersonDto, Person>();
            // Mapping from UpdatePersonDto to Person domain model
            CreateMap<UpdatePersonDto, Person>();
            // Mapping from Person to Person, ensuring non-null values are copied
            CreateMap<Person, Person>()
              .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
