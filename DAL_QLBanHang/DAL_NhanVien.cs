using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DAL_INhanVien
    {
        public int CreatePassword(string email, string newPass)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }

        public NhanVien DangNhap(string email, string matkhau)
        {
            if (email == "" || matkhau == "") return null;
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                // Lấy ra nhân viên có email và mật khẩu tương ứng
                return db.NhanViens.FirstOrDefault(n => n.Email == email && n.MatKhau == matkhau);
            }
        }

        public int Delete(NhanVien nhanVien)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                db.NhanViens.Attach(nhanVien);
                if (nhanVien.Hangs.Any() || nhanVien.Khaches.Any())
                    return 0; //Nếu nhân viên đã có hàng hoặc có khách hàng thì ko cho xóa
                db.NhanViens.Remove(nhanVien);
                return db.SaveChanges();

            }
        }

        public NhanVien Get(string maNV)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.Find(maNV);
            }
        }

        public List<NhanVien> GetAll()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.ToList();

            }
        }

        public List<NhanVien> Search(string key)
        {
            if (string.IsNullOrEmpty(key))
                return GetAll();
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.Where(n => n.MaNV == key || n.TenNV.Contains(key)).ToList();
            }
        }

        public NhanVien GetByEmail(string email)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email);
            }
        }

        public int Insert(string maNV, string email, string tenNV, string diachi, byte vaiTro, byte tinhtrang, string matkhau)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                try
                {
                    db.sp_InsertNhanVien(maNV, email, tenNV, diachi, vaiTro, tinhtrang, matkhau);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public int Insert(NhanVien nhanVien)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                try
                {
                    db.NhanViens.Add(nhanVien);
                    return db.SaveChanges();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }


        public int Update(NhanVien nhanVien)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                db.NhanViens.Attach(nhanVien);
                db.Entry(nhanVien).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int UpdatePassword(string email, string oldPass, string newPass)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                if (nv.MatKhau != oldPass) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }

        public int Insert(string maNV, string email, string tenNV, string diachi, string vaiTro, string tinhtrang, string matkhau)
        {
            throw new NotImplementedException();
        }

        public List<NhanVien> GetAllByEmail(string key)
        {
            throw new NotImplementedException();
        }
    }
}
