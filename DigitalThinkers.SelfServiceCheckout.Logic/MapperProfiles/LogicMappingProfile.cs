using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = DigitalThinkers.SelfServiceCheckout.Data.Entities;
using Models = DigitalThinkers.SelfServiceCheckout.Logic.Models;

namespace DigitalThinkers.SelfServiceCheckout.Logic.MapperProfiles
{
    public class LogicMappingProfile : Profile
    {
        public LogicMappingProfile()
        {
            CreateMap<Entities.Banknote, Models.Banknote>().ReverseMap();
            
        }
    }
}
