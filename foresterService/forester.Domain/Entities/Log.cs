using System;

namespace forester.Domain.Entities;

public class Log
{
    public int Id { get; set; }
    public string Text { get; set; } = String.Empty;
    public int LogTypeID { get; set; }
    public LogType? LogType { get; set; }
    public string UserUsername { get; set; } = String.Empty;
    public DateTime Time { get; set; } = DateTime.Now;
}
