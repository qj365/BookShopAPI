using AutoMapper;
using BookShopAPI.Areas.Admin.Dto;
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
            Mapper.CreateMap<Author, AuthorDto>();
            Mapper.CreateMap<AuthorDto, Author>();

            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Publisher, PublisherDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Voucher, VoucherDto>();
            Mapper.CreateMap<Orders, OrderDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Information, InformationDto>();
            Mapper.CreateMap<State, StateDto>();
            Mapper.CreateMap<Voucher, VoucherDto>();







        }
    }
}