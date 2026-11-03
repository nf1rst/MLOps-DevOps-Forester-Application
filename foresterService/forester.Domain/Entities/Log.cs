using System;

namespace forester.Domain.Entities;

public class Log
{
    public int Id { get; set; }
    public string Type { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;

}
