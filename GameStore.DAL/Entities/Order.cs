﻿using GameStore.DAL.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GameStore.DAL.Entities
{
    [MongoCollection("orders")]
    [BsonIgnoreExtraElements]
    public class Order : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }

        [Required, BsonSerializer(typeof(CustomDateTimeConverter))]
        public DateTime OrderDate { get; set; }

        [DefaultValue(null)]
        public DateTime? Expiration { get; set; }

        [Required, DefaultValue(OrderStatus.Opened)]
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        public double? Freight { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public string ShipName { get; set; }


        public DateTime? ShippedDate { get; set; }

        public int? ShipPostalCode { get; set; }

        public string ShipRegion { get; set; }

        public int? ShipVia { get; set; }

        public DateTime? RequiredDate { get; set; }

        public Order()
        {
            OrderDate = DateTime.UtcNow;
        }
    }
}
