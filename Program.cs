//cấu hình biuld và host cho webapi
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using webapi.Data;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);

//map các controller có gắn [Router] vào hệ thống
//tự động tìm các controller trong project
builder.Services.AddControllers();

//đăng ký service để sử dụng swagger
// tạo ra document dựa trên các apiController
// đường dẫn mặc định: /swagger/v1/swagger.json
builder.Services.AddSwaggerGen();

//cấu hình kết nối db
//thêm Entity FrameWork
// builder.Services.AddDbContext<DataContext>(options =>
// {
//     //lấy chuỗi kết nối từ appsetting.json
//     var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//     options.UseSqlServer(ConnectionString);
// });

// thêm dbcontext của project QuanLyBanHang
// để tương tác với db QuanLyBanHang
builder.Services.AddDbContext<QuanLyBanHangContext>(options =>
{
    //lấy chuỗi kết nối từ appsetting.json
    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(ConnectionString);
});

var app = builder.Build();
//phân biệt môi trường dev(local) và prod (deploy lên host)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers(); //map controller vào hệ thống

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.Run();
