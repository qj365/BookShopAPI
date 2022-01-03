using AutoMapper;
using BookShopAPI.Areas.Admin.ViewModel;
using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Author, Author>();
            Mapper.CreateMap<Book, Book>();
            Mapper.CreateMap<BookViewModel, Book>();


        }
    }
}