using System.Linq;
using AutoMapper;
using CuratedList.Models;
using CuratedList.Models.DTO;

namespace CuratedList.Profiles
{
    public class CuratedListProfile : Profile
    {
        public CuratedListProfile()
        {
            CreateMap<ApplicationUser, ApplicationUser>();
            CreateMap<LinkTag, LinkTagResponse>()
                .ReverseMap();
            CreateMap<LinkEntry, LinkEntryResponse>()
                .ForMember(
                    dest=>dest.UserName,
                    opt=>opt.MapFrom(x=>x.User.UserName)
                )
                .ForMember(dest=>dest.HighestTag,
                    opt=>opt.MapFrom(x=>x.Tags.OrderByDescending(tag=>tag.Name).FirstOrDefault().Name))
                .ReverseMap();
        }
    }
}