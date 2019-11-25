using AutoMapper;
using HumanResources.Entities;
using HumanResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Profiles
{
    public class HumanResourceProfile : Profile
    {
        public HumanResourceProfile()
        {
            this.CreateMap<Employees, GetEmployeeResponse>()                
                .ReverseMap();
            this.CreateMap<Employees, AddEmployeeRequest>()
                .ReverseMap();
        }
         
    }
}
