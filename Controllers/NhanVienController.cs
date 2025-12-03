using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Base;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly QuanLyBanHangContext _context;

        public NhanVienController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: api/NhanVien
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _context.NhanViens.ToListAsync();
            return Ok(new ResponseEntity(200, res, "Lấy danh sách nhân viên thành công"));
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nv = await _context.NhanViens.FindAsync(id);

            if (nv == null)
            {
                return NotFound(new ResponseEntity(404, null, "Không tìm thấy nhân viên"));
            }

            return Ok(new ResponseEntity(200, nv, "Lấy thông tin nhân viên thành công"));
        }

        // POST: api/NhanVien/addnew
        [HttpPost("addnew")]
        public async Task<IActionResult> Create([FromBody] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseEntity(400, ModelState, "Dữ liệu không hợp lệ"));
            }

            // Cho EF tự set Id (identity)
            var nV = new NhanVien
            {
                Ten      = nhanVien.Ten,
                Email    = nhanVien.Email,
                Sdt      = nhanVien.Sdt,
                Luong    = nhanVien.Luong,
                MaQuanLy = nhanVien.MaQuanLy
            };

            _context.NhanViens.Add(nV);
            await _context.SaveChangesAsync();

            return Ok(new ResponseEntity(200, nV, "Thêm mới nhân viên thành công"));
        }

        // PUT: api/NhanVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseEntity(400, ModelState, "Dữ liệu không hợp lệ"));
            }

            if (id != nhanVien.Id)
            {
                return BadRequest(new ResponseEntity(400, null, "Id không trùng khớp"));
            }

            // 1. Tìm nhân viên trong DB
            var existing = await _context.NhanViens.FindAsync(id);

            if (existing == null)
            {
                return NotFound(new ResponseEntity(404, null, "Không tìm thấy nhân viên"));
            }

            // 2. Cập nhật field
            existing.Ten      = nhanVien.Ten;
            existing.Email    = nhanVien.Email;
            existing.Sdt      = nhanVien.Sdt;
            existing.Luong    = nhanVien.Luong;
            existing.MaQuanLy = nhanVien.MaQuanLy;

            // 3. Lưu thay đổi
            await _context.SaveChangesAsync();

            // 4. Trả về entity sạch
            return Ok(new ResponseEntity(200, existing, "Cập nhật thành công"));
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseEntity(400, ModelState, "Dữ liệu không hợp lệ"));
            }

            var existing = await _context.NhanViens.FindAsync(id);

            if (existing == null)
            {
                return NotFound(new ResponseEntity(404, null, "Không tìm thấy nhân viên"));
            }

            _context.NhanViens.Remove(existing);
            var res = await _context.SaveChangesAsync();

            return Ok(new ResponseEntity(200, res, "Xóa thành công"));
        }
    }
}
