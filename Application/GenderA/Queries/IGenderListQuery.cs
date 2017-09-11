using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GenderA.Queries
{
    public interface IGenderListQuery
    {
        IEnumerable<Gender> GetAllGender();
        Gender GetGenderById(int ID);
    }
}
