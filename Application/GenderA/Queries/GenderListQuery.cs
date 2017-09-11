using Application.Categories.Queries.Factory;
using Application.GenderA.Queries.Factory;
using AutoMapper;
using Business.Module.BusinessEntyties;
using Ninject;
using Persistence.Data.UnitofWork;
using System;
using System.Collections.Generic;

namespace Application.GenderA.Queries
{
    public class GenderListQuery : IGenderListQuery
    {
        private IUnitofWork _unitofwork;
        private IGenderFactory _genderFactory;

        public GenderListQuery()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IGenderFactory>().To<GenderFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _genderFactory = kernel.Get<IGenderFactory>();
            }
            
        }

        public IEnumerable<Gender> GetAllGender()
        {
            IEnumerable<Gender> ListGenderEntity = new List<Gender>();
            IEnumerable<Persistence.Data.WebShopModel.Gender> ListGender = new List<Persistence.Data.WebShopModel.Gender>();
            ListGender = _unitofwork.GenderRepository.GetAll();
            ListGenderEntity = _genderFactory.CreateListGenderBO(ListGender);
            return ListGenderEntity;
        }

        public Gender GetGenderById(int ID)
        {
            var genderData = _unitofwork.GenderRepository.Get(ID);
            var gender = _genderFactory.CreateGenderBO(genderData);
            return gender;
        }
        private void Dependencies()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IGenderFactory>().To<GenderFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _genderFactory = kernel.Get<IGenderFactory>();
            }
        }
    }
}
