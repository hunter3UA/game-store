using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameStore.DAL.Attributes;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.DAL.Entities
{
    [Index("CompanyName", IsUnique = true)]
    [MongoCollection("suppliers")]
    [BsonIgnoreExtraElements]
    public class Publisher : BaseEntity
    {
        [NotMapped]
        public int SupplierID { get; set; }

        [Required, MaxLength(40)]
        public string CompanyName { get; set; }

        [Column(TypeName = "ntext"), MaxLength(1000)]
        public string Description { get; set; }

        [Required, Column(TypeName = "ntext"), MaxLength(400)]
        public string HomePage { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Fax { get; set; }
 
        public string Phone { get; set; }
    
        public string PostalCode { get; set; }

        [NotMapped, BsonDefaultValue(TypeOfBase.Northwind),IgnoreMongoUpdate]
        public TypeOfBase TypeOfBase { get; set; }
    }
}
