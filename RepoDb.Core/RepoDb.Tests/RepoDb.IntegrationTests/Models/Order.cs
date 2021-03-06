﻿using System;
using RepoDb.Attributes;
using RepoDb.Enumerations;
using System.Collections.Generic;

namespace RepoDb.IntegrationTests.Models
{
    [Map("[dbo].[Order]")]
    public class Order : DataEntity
    {
        [Identity(), Map("Id")]
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public DateTime OrderDateUtc { get; set; }
        public long CustomerId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Freight { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
        [Attributes.Ignore(Command.Update)]
        public DateTime DateInsertedUtc { get; set; }
        public string LastUserId { get; set; }
    }
}