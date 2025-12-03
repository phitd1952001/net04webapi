// using Microsoft.EntityFrameworkCore;
// using WebApi.ModelsDemo;


// namespace webapi.DataDemo
// {
//     public class DataContext : DbContext
//     {
//         public DataContext(DbContextOptions<DataContext> options) : base(options) { }

//         //thêm dbset cho các entity vào đây
//         //muốn làm việc với table NhanVien trong db
//         public DbSet<NhanVien> NhanVien { get; set; }

//         // khai báo các bảng trong db
//         //bảng sản phẩm
//         public DbSet<SanPham> sanPham {get;set;}

//         //cấu hình các ràng buộc, khóa ngoại, tên bảng, tên cột...
//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             base.OnModelCreating(modelBuilder);

//             //cấu hình cho bảng NhanVien

//             //cấu hình cho bảng SanPham
//         }
//     }
// };