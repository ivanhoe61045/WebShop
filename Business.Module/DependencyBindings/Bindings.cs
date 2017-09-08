using Persistence.Data.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module.DependencyBindings
{
    public class Bindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitofWork>().To<UnitofWork>();
        }
    }
}
