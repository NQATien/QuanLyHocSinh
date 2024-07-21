using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QuanLyHocSinh.Models
{
    public class DBHelper
    {
        StudentDbContext _db;
        public DBHelper(StudentDbContext db)
        {
            _db = db;
        }
        // học sinh
        public List<HocSinh> GetHocSinh()
        {
            return _db.HocSinhs.ToList();
        }
        public HocSinh GetHocSinhByID(int id)
        {
            return _db.HocSinhs.First(x => x.HocSinhID == id);
        }
        public void InsertHocSinh(HocSinh hocsinh)
        {
            _db.HocSinhs.Add(hocsinh);
            _db.SaveChanges();
        }

        public void EditHocSinh(HocSinh newHocsinh)
        {
            _db.HocSinhs.Update(newHocsinh);
            _db.SaveChanges();
        }

        public void DeleteHocSinh(int id)
        {
            HocSinh hocsinh = GetHocSinhByID(id);
            _db.HocSinhs.Remove(hocsinh );
            _db.SaveChanges();
        }
        // giáo viên
        public List<GiaoVien> GetGiaoVien()
        {
            return _db.GiaoViens.ToList();
        }
        public GiaoVien GetGiaoVienByID(int id)
        {
            return _db.GiaoViens.First(x => x.GiaoVienID == id);
        }
        public GiaoVien GetGiaoVienByName(string name)
        {
            return _db.GiaoViens.First(x => x.GiaoVienName == name);
        }
        public void InsertGiaoVien(GiaoVien giaovien)
        {
            _db.GiaoViens.Add(giaovien);
            _db.SaveChanges();
        }

        public void EditGiaoVien(GiaoVien newGiaovien)
        {
            _db.GiaoViens.Update(newGiaovien);
            _db.SaveChanges();
        }

        public void DeleteGiaoVien(int id)
        {
            GiaoVien giaovien = GetGiaoVienByID(id);
            _db.GiaoViens.Remove(giaovien);
            _db.SaveChanges();
        }

        //lớp
        public List<Lop> GetLop()
        {
            return _db.Lops.ToList();
        }
        public Lop GetLopByID(int id)
        {
            return _db.Lops.First(x => x.LopID == id);
        }
        public Lop GetLopByName(string name)
        {
            return _db.Lops.First(x => x.LopName == name);
        }
        public void InsertLop(Lop lop)
        {
            _db.Lops.Add(lop);
            _db.SaveChanges();
        }

        public void EditLop(Lop newLop)
        {
            _db.Lops.Update(newLop);
            _db.SaveChanges();
        }

        public void DeleteLop(int id)
        {
            Lop lop = GetLopByID(id);
            _db.Lops.Remove(lop);
            _db.SaveChanges();
        }

        // khối
        public List<Khoi> Getkhoi()
        {
            return _db.Khois.ToList();
        }
        public Khoi GetkhoiByID(int id)
        {
            return _db.Khois.First(x => x.KhoiID == id);
        }
        public Khoi GetkhoiByName(string name)
        {
            return _db.Khois.First(x => x.KhoiName == name);
        }
        public void Insertkhoi(Khoi khoi)
        {
            _db.Khois.Add(khoi);
            _db.SaveChanges();
        }

        public void Editkhoi(Khoi newKhoi)
        {
            _db.Khois.Update(newKhoi);
            _db.SaveChanges();
        }

        public void Deletekhoi(int id)
        {
            Khoi khoi = GetkhoiByID(id);
            _db.Khois.Remove(khoi);
            _db.SaveChanges();
        }

        // điểm
        public List<Diem> Getdiem()
        {
            return _db.Diems.ToList();
        }
        public Diem GetdiemByID(int id)
        {
            return _db.Diems.First(x => x.DiemID == id);
        }
        public Diem GetdiemByName(string name)
        {
            return (Diem) _db.Diems.Where(x => x.DiemHK1 == name || x.DiemHK2 == name || x.DiemHK3 == name);
        }
       
        public void Insertdiem(Diem diem)
        {
            _db.Diems.Add(diem);
            _db.SaveChanges();
        }

        public void Editdiem(Diem newDiem)
        {
            _db.Diems.Update(newDiem);
            _db.SaveChanges();
        }

        public void Deletediem(int id)
        {
            Diem diem = GetdiemByID(id);
            _db.Diems.Remove(diem);
            _db.SaveChanges();
        }
        // năm học
        public List<NamHoc> Getnamhoc()
        {
            return _db.NamHocs.ToList();
        }
        public NamHoc GetnamhocByID(int id)
        {
            return _db.NamHocs.First(x => x.NamHocID == id);
        }
        public NamHoc GetnamhocByName(string name)
        {
            return _db.NamHocs.First(x => x.NamHocName == name);
        }
        public void Insertnamhoc(NamHoc namhoc)
        {
            _db.NamHocs.Add(namhoc);
            _db.SaveChanges();
        }

        public void Editnamhoc(NamHoc newNamhoc)
        {
            _db.NamHocs.Update(newNamhoc);
            _db.SaveChanges();
        }

        public void Deletenamhoc(int id)
        {
            NamHoc namhoc = GetnamhocByID(id);
            _db.NamHocs.Remove(namhoc);
            _db.SaveChanges();
        }
        // Học Kỳ
        public List<HocKy> Gethk()
        {
            return _db.HocKys.ToList();
        }
        public HocKy GethkByID(int id)
        {
            return _db.HocKys.First(x => x.HocKyID == id);
        }
        public HocKy GethkByName(string name)
        {
            return _db.HocKys.First(x => x.HocKyName == name);
        }
        public void Inserthk(HocKy hocky)
        {
            _db.HocKys.Add(hocky);
            _db.SaveChanges();
        }

        public void Edithk(HocKy newHocky)
        {
            _db.HocKys.Update(newHocky);
            _db.SaveChanges();
        }

        public void Deletehk(int id)
        {
            HocKy hocky = GethkByID(id);
            _db.HocKys.Remove(hocky);
            _db.SaveChanges();
        }
        // bộ môn
        public List<BoMon> Getbm()
        {
            return _db.BoMons.ToList();
        }
        public BoMon GetbmByID(int id)
        {
            return _db.BoMons.First(x => x.BoMonID == id);
        }
        public BoMon GetbmByName(string name)
        {
            return _db.BoMons.First(x => x.BoMonName == name);
        }
        public void Insertbm(BoMon bomon)
        {
            _db.BoMons.Add(bomon);
            _db.SaveChanges();
        }

        public void Editbm(BoMon newBomon)
        {
            _db.BoMons.Update(newBomon);
            _db.SaveChanges();
        }

        public void Deletebm(int id)
        {
            BoMon bomon = GetbmByID(id);
            _db.BoMons.Remove(bomon);
            _db.SaveChanges();
        }
        // Môn
        public List<Mon> Getm()
        {
            return _db.Mons.ToList();
        }
        public Mon GetmByID(int id)
        {
            return _db.Mons.First(x => x.MonID == id);
        }
        public Mon GetmByName(string name)
        {
            return _db.Mons.First(x => x.MonName == name);
        }
        public void Insertm(Mon mon)
        {
            _db.Mons.Add(mon);
            _db.SaveChanges();
        }

        public void Editm(Mon newMon)
        {
            _db.Mons.Update(newMon);
            _db.SaveChanges();
        }

        public void Deletem(int id)
        {
            Mon mon = GetmByID(id);
            _db.Mons.Remove(mon);
            _db.SaveChanges();
        }
        public List<HocSinh> SearchProduct(string Name)
        {
            return _db.HocSinhs.Where(p => p.HocSinhName.Contains(Name)).ToList();
        }

        public List<HocSinh> LocKhoiHocSinh(int idlop)
        {
        var locHS = _db.HocSinhs
        .Join(
          _db.Lops,
          hs => hs.LopID,
          lop => lop.LopID,
          (hs, lop) => new {
              HocSinhID = hs.HocSinhID,
              HocSinhName = hs.HocSinhName,
              LopName = hs.Lop.LopName,
              ImagePath = hs.ImagePath,
              KhoiID = lop.KhoiID,
              Lop = hs.Lop
          })
        .Where(HocSinhs => HocSinhs.KhoiID == idlop)
        .Select(HocSinhs => new HocSinh
        {
            HocSinhID = HocSinhs.HocSinhID,
            HocSinhName = HocSinhs.HocSinhName,
            LopName = HocSinhs.Lop.LopName,
            ImagePath = HocSinhs.ImagePath
        })
        .ToList();

    return locHS;
}

        public List<Lop> LocKhoiLop(int idlopk)
        {
            var locLop = _db.Lops
                .Where(Lops => Lops.KhoiID == idlopk)
                .Select(Lops => new Lop
                {
                    LopID = Lops.LopID,
                    LopName = Lops.LopName,
                    KhoiName = Lops.Khoi.KhoiName,
                })
               .ToList();
            return locLop;
        }

        // Thời khoá biểu
        public List<ThoiKhoaBieu> GetThoiKhoaBieu()
        {
            return _db.ThoiKhoaBieus.ToList();
        }
        public ThoiKhoaBieu GetThoiKhoaBieuByID(int id)
        {
            return _db.ThoiKhoaBieus.First(x => x.ThoiKhoaBieuID == id);
        }
        public void InsertThoiKhoaBieu(ThoiKhoaBieu thoikhoabieu)
        {
            _db.ThoiKhoaBieus.Add(thoikhoabieu);
            _db.SaveChanges();
        }

        public void EditThoiKhoaBieu(ThoiKhoaBieu newThoiKhoaBieu)
        {
            _db.ThoiKhoaBieus.Update(newThoiKhoaBieu);
            _db.SaveChanges();
        }

        public void DeleteThoiKhoaBieu(int id)
        {
            ThoiKhoaBieu thoikhoabieu = GetThoiKhoaBieuByID(id);
            _db.ThoiKhoaBieus.Remove(thoikhoabieu);
            _db.SaveChanges();
        }

        // Thông Báo
        public List<ThongBao> GetThongBao()
        {
            return _db.ThongBaos.ToList();
        }
        public ThongBao GetThongBaoByID(int id)
        {
            return _db.ThongBaos.First(x => x.ThongBaoID == id);
        }
        public void InsertThongBao(ThongBao thongbao)
        {
            _db.ThongBaos.Add(thongbao);
            _db.SaveChanges();
        }

        public void EditThongBao(ThongBao newThongBao)
        {
            _db.ThongBaos.Update(newThongBao);
            _db.SaveChanges();
        }

        public void DeleteThongBao(int id)
        {
            ThongBao thongbao = GetThongBaoByID(id);
            _db.ThongBaos.Remove(thongbao);
            _db.SaveChanges();
        }

        // Điểm Danh
        public List<DiemDanh> GetDiemDanh()
        {
            return _db.DiemDanhs.ToList();
        }
        public DiemDanh GetDiemDanhByID(int id)
        {
            return _db.DiemDanhs.First(x => x.DiemDanhID == id);
        }
        public void InsertDiemDanh(DiemDanh diemdanh)
        {
            _db.DiemDanhs.Add(diemdanh);
            _db.SaveChanges();
        }

        public void EditDiemDanh(DiemDanh newDiemDanh)
        {
            _db.DiemDanhs.Update(newDiemDanh);
            _db.SaveChanges();
        }

        public void DeleteDiemDanh(int id)
        {
            DiemDanh diemdanh = GetDiemDanhByID(id);
            _db.DiemDanhs.Remove(diemdanh);
            _db.SaveChanges();
        }
    }
}
