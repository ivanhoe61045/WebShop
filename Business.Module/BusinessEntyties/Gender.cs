using AutoMapper;
using Ninject;
using Persistence.Data.UnitofWork;
using System.Collections.Generic;
using Transversal.Module.CustomException;

namespace Business.Module.BusinessEntyties
{
    public class Gender
    {
        #region properties
        public short IdGender { get; set; }
        public string GenderName { get; set; }
        private IUnitofWork unitofwork;
        #endregion

        #region constructor 
        public Gender(Gender gender)
        {
            this.GenderName = gender.GenderName;
            this.IdGender = gender.IdGender;
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();

                unitofwork = kernel.Get<IUnitofWork>();
            }
        }
        public Gender()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>()
                      .To<UnitofWork>();

                unitofwork = kernel.Get<IUnitofWork>();
            }
        }
        #endregion

        #region Methods
        public IEnumerable<Gender> GetAllGender()
        {
            List<Gender> ListGenderEntity = new List<Gender>();

            IEnumerable<Persistence.Data.WebShopModel.Gender> ListGender = new List<Persistence.Data.WebShopModel.Gender>();
            ListGender = unitofwork.GenderRepository.GetAll();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Gender,Gender>();
            });

            if (((List<Persistence.Data.WebShopModel.Gender>)ListGender).Count == 0)
                return ListGenderEntity;

            ListGenderEntity = Mapper.Map<IEnumerable<Persistence.Data.WebShopModel.Gender>, List<Gender>>(ListGender);

            return ListGenderEntity;
        }

        public void AddGender()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Gender, Persistence.Data.WebShopModel.Gender>();
            });
            var genderData = Mapper.Map<Gender, Persistence.Data.WebShopModel.Gender>(this);
            if (genderData != null)
            {
                unitofwork.GenderRepository.Add(genderData);
                unitofwork.Complete();
            }
            else
                throw new MappingFailedException("The Gender was not mapped");
        }

        public Gender GetGenderById(int ID)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Persistence.Data.WebShopModel.Gender, Gender>();
            });
            
            var genderData = unitofwork.GenderRepository.Get(ID); 
            var gender = Mapper.Map<Persistence.Data.WebShopModel.Gender, Gender>(genderData);
            return gender;
        }

        #endregion

    }
}
