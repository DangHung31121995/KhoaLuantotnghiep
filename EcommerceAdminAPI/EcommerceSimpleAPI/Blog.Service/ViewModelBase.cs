using System.Collections.Generic;
using Ecommerce.Infrastructure.Attribute;
using Ecommerce.Service.Mapping;
namespace Ecommerce.Service
{
    public abstract class ViewModelBase<TM, TMv> where TM : class where TMv : class
    {
        #region Public Properties
        public IList<ResponseMessage> Validations { get; set; }
        #endregion Public Properties

        #region Public Medthods
        public TMv Map(TM item)
        {
            if (item == null) return null;
            return AutoMapperConfig.Config.CreateMapper().Map<TM, TMv>(item);
        }

        public TM Map(TMv item)
        {
            if (item == null) return null;
            return AutoMapperConfig.Config.CreateMapper().Map<TMv, TM>(item);
        }
        
        public IEnumerable<TMv> Map(IEnumerable<TM> items)
        {
            if (items == null) return new List<TMv>();
            return AutoMapperConfig.Config.CreateMapper().Map<IEnumerable<TM>, IEnumerable<TMv>>(items);
        }

        public IEnumerable<TM> Map(IEnumerable<TMv> items)
        {
            if (items == null) return new List<TM>();
            return AutoMapperConfig.Config.CreateMapper().Map<IEnumerable<TMv>, IEnumerable<TM>>(items);
        }

        #endregion Public Medthods

        #region Virtual Methods

        public virtual bool IsValid()
        {
            return true;
        }

        #endregion Abstract Methods
    }
}
