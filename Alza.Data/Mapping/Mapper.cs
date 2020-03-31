using Alza.Common.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Data.Mapping
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Product, Common.Models.Product>();
            CreateMap<Common.Models.Product, Product>();
        }
    }
}
