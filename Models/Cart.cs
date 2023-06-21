using Microsoft.EntityFrameworkCore;
using NetCRUD2.Components;

namespace NetCRUD2.Models
{
    public class CartLine
    {

        public int CartLineID { get; set; }
        public SanPham SanPham { get; set; } = new();
        public int Soluong { get; set; }
    }

    [Keyless]
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(SanPham sanPham, int soluong)
        {
            CartLine? line = Lines.Where(p => p.SanPham.ID == sanPham.ID).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    SanPham = sanPham,
                    Soluong = soluong
                });
            }
            else
            {
                line.Soluong += soluong;
            }
        }
        public void RemoveItem(SanPham sanPham) => Lines.RemoveAll(l => l.SanPham.ID == sanPham.ID);
        public decimal ComputeTotalValue() => Lines.Sum(e => e.SanPham.Giatien * e.Soluong);
        public void Clear() => Lines.Clear();
    }


}