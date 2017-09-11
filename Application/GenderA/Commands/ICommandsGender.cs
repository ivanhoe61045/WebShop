using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GenderA.Commands
{
    public interface ICommandsGender
    {
         void AddGender(Gender gender);
    }
}
