namespace ShiftsLoggerApi.Models;

public class Worker
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Shift>? Shifts { get; set; }
}