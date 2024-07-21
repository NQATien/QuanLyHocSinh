using Microsoft.EntityFrameworkCore;

namespace QuanLyHocSinh.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<HocSinh> HocSinhs { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoi> Khois { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<NamHoc> NamHocs { get; set; }
        public DbSet<HocKy> HocKys { get; set; }
        public DbSet<BoMon> BoMons{ get; set; }
        public DbSet<Mon> Mons{ get; set; }
        public DbSet<ThoiKhoaBieu> ThoiKhoaBieus { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<DiemDanh> DiemDanhs { get; set; }
    }
}
