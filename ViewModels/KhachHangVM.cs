// có danh sách đơn hàng
// liên kết với đơn hàng
// 1 khách hàng có nhiều đơn hàng
using System.ComponentModel.DataAnnotations;

public class KhachHangVM
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    public string? Ten { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [RegularExpression(
        @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,5}$",
        ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    public string? Sdt { get; set; }
}
