using System;

namespace forester.Domain.Entities;

public class UserInputs
{
    //public int Id { get; set; }
    public int Elevation { get; set; } = 2900;
    public int Aspect { get; set; } = 45;
    public int Slope { get; set; } = 19;
    public int Horizontal_Distance_To_Hydrology { get; set; } = 242;
    public int Vertical_Distance_To_Hydrology { get; set; } = 20;
    public int Horizontal_Distance_To_Roadways { get; set; } = 5199;
    public int Hillshade_9am { get; set; } = 221;
    public int Hillshade_Noon { get; set; } = 195;
    public int Hillshade_3pm { get; set; } = 100;
    public int Horizontal_Distance_To_Fire_Points { get; set; } = 4115;
    public int Wilderness_Area { get; set; } = 1;
    public int Soil_Type { get; set; } = 29;
    //public int CoverType { get; set; }
}
