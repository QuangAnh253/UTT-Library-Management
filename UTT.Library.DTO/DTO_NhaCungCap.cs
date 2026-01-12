namespace UTT.Library.DTO
{
    public class DTO_NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }

        public DTO_NhaCungCap() { }

        public DTO_NhaCungCap(string maNCC, string tenNCC, string diaChi, string sDT, string email)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SDT = sDT;
            Email = email;
        }
    }
}
