using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerApi.Models;
using ShiftsLoggerApi.Services;

namespace ShiftsLoggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : ControllerBase
{
    private readonly ShiftService _shiftService;

    public ShiftsController(ShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet]
    public async Task<IActionResult> GetShifts()
    {
        var shifts = await _shiftService.GetShiftsAsync();
        return Ok(shifts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShiftById(int id)
    {
        var shift = await _shiftService.GetShiftByIdAsync(id);
        if (shift == null) return NotFound();
        return Ok(shift);
    }

    [HttpPost]
    public async Task<IActionResult> AddShift([FromBody] Shift shift)
    {
        await _shiftService.AddShiftAsync(shift);
        return CreatedAtAction(nameof(GetShiftById), new { id = shift.Id }, shift);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShift(int id, [FromBody] Shift shift)
    {
        if (id != shift.Id) return BadRequest("ID mismatch");
        await _shiftService.UpdateShiftAsync(shift);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShift(int id)
    {
        if (!await _shiftService.DeleteShiftAsync(id)) return NotFound();
        return NoContent();
    }
}
