using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SimpleCrud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string BuyingPrice { get; set; }
        public string ExpireDate { get; set; }
    }
}
