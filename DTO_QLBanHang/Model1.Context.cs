﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO_QLBanHang
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLBanHangEntities : DbContext
    {
        public QLBanHangEntities()
            : base("name=QLBanHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public void sp_InsertNhanVien(string maNV, string email, string tenNV, string diachi, byte vaiTro, byte tinhtrang, string matkhau)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<Khach> Khaches { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
    }
}
