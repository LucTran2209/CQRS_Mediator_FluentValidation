﻿using T.Domain.Abstractions;

namespace T.Domain.Entities
{
    public class Product : EntityAuditBase<Guid>
    {
        public string? ProductName { get; set;}
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
