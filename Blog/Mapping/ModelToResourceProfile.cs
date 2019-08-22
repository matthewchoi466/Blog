using System;
using AutoMapper;
using Blog.Domain.Models;
using Blog.Resources;

namespace Blog.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Article, ArticleSummaryResource>()
                .ForMember(dest => dest.AuthorName,
                opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.PublishedDateTime,
                opt => opt.MapFrom(src => setPublishedUTCDateTimeString(src.PublishedDateTime)));

            CreateMap<Article, ArticleContentResource>()
               .ForMember(dest => dest.AuthorName,
               opt => opt.MapFrom(src => src.Author.Name))
             .ForMember(dest => dest.PublishedDateTime,
                opt => opt.MapFrom(src => setPublishedUTCDateTimeString(src.PublishedDateTime)));

            CreateMap<User, AuthorResource>()
                .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.AuthorUserID,
                opt => opt.MapFrom(src => src.Id));

        }

        string setPublishedUTCDateTimeString (DateTime publishedDateTime)
        {
            return publishedDateTime.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }
    }
}
