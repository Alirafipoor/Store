﻿using Store.Domain.Entites.Commons;

namespace Store.Domain.Entites.Products
{
    public class ProductImages : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }
}
