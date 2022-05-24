using AutoMapper;
using System.Collections.Generic;

namespace Starter.CORE.MapperProfiles
{
    public class EntityProfile: Profile
    {
        public EntityProfile()
        {
            CreateMap<Models.AttributeDataType, Entities.AttributeDataType>().ReverseMap();

            CreateMap<Models.EntityValue, Entities.EntityValue>().ReverseMap();
            CreateMap<Models.EntityCulturalName, Entities.EntityCulturalName>().ReverseMap();
            CreateMap<Models.Entity, Entities.Entity>().ReverseMap();
        }

        #region From Data Transfer Object To Models

        #endregion

        #region From Models to Data Transfer Object

        #endregion
    }
}
