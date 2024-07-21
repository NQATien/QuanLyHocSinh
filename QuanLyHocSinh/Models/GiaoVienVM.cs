using System.Transactions;

namespace QuanLyHocSinh.Models
{
    public class GiaoVienVM
    {
        public int GiaoVienId { get; set; }
        public string GiaoVienName { get; set; }
        public string GioiTinh { get; set; }
        public int LopId { get; set; }
        public string LopName { get; set; }
    }
}
