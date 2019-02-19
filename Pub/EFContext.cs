using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Pub
{
    public class EFContext:DbContext
    {
        public EFContext() : base("Supervisory_SystemEntities") { }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<TakeGoodsInfo> TakeGoodsInfo { get; set; }
        public virtual DbSet<GoodType> GoodsInfo { get; set; }
        public virtual DbSet<GoodType> GoodType { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<AddressInfo> AddressInfo { get; set; }
    }
}
