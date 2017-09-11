using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Module.BusinessEntyties;
using Persistence.Data.WebShopModel;
using AutoMapper;

namespace Application.GenderA.Queries.Factory
{
    public class GenderFactory : IGenderFactory
    {
        public IEnumerable<Business.Module.BusinessEntyties.Gender> CreateListGenderBO(IEnumerable<Persistence.Data.WebShopModel.Gender> ListGender)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Gender, Business.Module.BusinessEntyties.Gender>();
            });

            IEnumerable<Business.Module.BusinessEntyties.Gender> ListGenderEntity = null;
            if (((List<Persistence.Data.WebShopModel.Gender>)ListGender).Count == 0)
                return ListGenderEntity;

            ListGenderEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Gender>, List<Business.Module.BusinessEntyties.Gender>>(ListGender);
            return ListGenderEntity;
        }

        public Business.Module.BusinessEntyties.Gender CreateGenderBO(Persistence.Data.WebShopModel.Gender genderData)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Gender, Business.Module.BusinessEntyties.Gender>();
            });
            var gender = Mapper.Map<Persistence.Data.WebShopModel.Gender, Business.Module.BusinessEntyties.Gender>(genderData);
            return gender;
        }

        public Persistence.Data.WebShopModel.Gender CreateGenderData(Business.Module.BusinessEntyties.Gender gender)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Business.Module.BusinessEntyties.Gender, Persistence.Data.WebShopModel.Gender>();
            });
            var genderData = Mapper.Map<Business.Module.BusinessEntyties.Gender, Persistence.Data.WebShopModel.Gender>(gender);
            return genderData;
        }
    }
}
