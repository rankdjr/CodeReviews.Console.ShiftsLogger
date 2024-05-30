using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApi.Data;
using ShiftsLoggerApi.Models;

namespace ShiftsLoggerApi.Services;

public class ShiftService
{
    private readonly AppDbContext _context;

    public ShiftService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Shift>> GetShiftsAsync()
    {
        return await _context.Shifts.Include(s => s.Worker).ToListAsync();
    }

    public async Task<Shift> GetShiftByIdAsync(int id)
    {
        return await _context.Shifts.Include(s => s.Worker).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddShiftAsync(Shift shift)
    {
        _context.Shifts.Add(shift);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateShiftAsync(Shift shift)
    {
        _context.Shifts.Update(shift);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteShiftAsync(int id)
    {
        var shift = await _context.Shifts.FindAsync(id);
        if (shift == null) return false;
        _context.Shifts.Remove(shift);
        await _context.SaveChangesAsync();
        return true;
    }
}
