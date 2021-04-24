using MongoDB.Bson.Serialization;
using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Persistence.Configurations
{
    public class ProductConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Name).SetIsRequired(true);
                map.MapMember(x => x.Barcode).SetIsRequired(true);
                map.MapMember(x => x.BuyingPrice).SetIsRequired(true);
                map.MapMember(x => x.ExpireDate).SetIsRequired(true);
                map.MapMember(x => x.Description).SetIsRequired(true);
            });
        }
    }
}