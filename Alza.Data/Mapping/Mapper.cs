using Alza.Common.Entities;
using AutoMapper;
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
