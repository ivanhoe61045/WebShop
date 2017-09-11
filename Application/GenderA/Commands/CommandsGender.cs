using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Module.BusinessEntyties;
using Persistence.Data.UnitofWork;
using Application.GenderA.Queries.Factory;
using Ninject;
using Transversal.Module.CustomException;

namespace Application.GenderA.Commands
{
    public class CommandsGender : ICommandsGender
    {
        private IUnitofWork _unitofwork;
        private IGenderFactory _genderFactory;

        public CommandsGender()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IUnitofWork>().To<UnitofWork>();
                kernel.Bind<IGenderFactory>().To<GenderFactory>();

                _unitofwork = kernel.Get<IUnitofWork>();
                _genderFactory = kernel.Get<IGenderFactory>();
            }
            
        }
        public void AddGender(Gender gender)
        {           
            var genderData = _genderFactory.CreateGenderData(gender);
            if (genderData != null)
            {
                _unitofwork.GenderRepository.Add(genderData);
                _unitofwork.Complete();
            }
            else
                throw new MappingFailedException("The Gender was not mapped");
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
