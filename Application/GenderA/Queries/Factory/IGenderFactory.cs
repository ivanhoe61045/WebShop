using Business.Module.BusinessEntyties;
using System.Collections.Generic;

namespace Application.GenderA.Queries.Factory
{
    public interface IGenderFactory
    {
        IEnumerable<Gender> CreateListGenderBO(IEnumerable<Persistence.Data.WebShopModel.Gender> listGender);
        Business.Module.BusinessEntyties.Gender CreateGenderBO(Persistence.Data.WebShopModel.Gender genderData);
        Persistence.Data.WebShopModel.Gender CreateGenderData(Business.Module.BusinessEntyties.Gender gender);
    }
}
