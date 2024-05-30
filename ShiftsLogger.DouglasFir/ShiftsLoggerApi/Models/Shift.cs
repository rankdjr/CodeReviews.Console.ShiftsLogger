namespace ShiftsLoggerApi.Models;

public class Shift
{
    public int Id { get; set; }
    public int WorkerId { get; set; }
    public Worker? Worker { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}