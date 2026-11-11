using System;

namespace forester.Domain.Entities;

public class LogType
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public ICollection<Log> Logs { get; set; } = new List<Log>();
}
