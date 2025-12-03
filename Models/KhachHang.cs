using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace webapi.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string? Ten { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    // có danh sách đơn hàng
    // liên kết với đơn hàng
    // 1 khách hàng có nhiều đơn hàng

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
