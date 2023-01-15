using System.ComponentModel.DataAnnotations;

namespace LightPi.Shared
{
    /// <summary>
    /// Representation of a Ligth, and its configuration.
    /// </summary>
    /// <remarks>will add a LightState representation once i've got some shelly and played around with them and checked their mqtt compatibility</remarks>
    public class Light
    {
        [Key]
        public int LightID { get; set; }
        [Required]
        public string Route { get; set; } //TODO consider building the Route/Topic from groups or rooms which have to be defined in another table
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsRGB { get; set; }
        public bool IsCCT { get; set; }
        public int? MinColorTemp { get; set; }
        public int? MaxColorTemp { get; set; }
        public bool IsDimmable { get; set; }
        public int? MinBrightness { get; set; }
        public int? MaxBrightness { get; set; }


        public Light Update(Light updateFrom)
        {
            this.Route = updateFrom.Route;
            this.Name = updateFrom.Name;
            this.Description = updateFrom.Description;
            this.IsRGB = updateFrom.IsRGB;
            this.IsCCT = updateFrom.IsCCT;
            this.MinColorTemp = updateFrom.MinColorTemp;
            this.MaxColorTemp = updateFrom.MaxColorTemp;
            this.IsDimmable = updateFrom.IsDimmable;
            this.MinBrightness = updateFrom.MinBrightness;
            this.MaxBrightness = updateFrom.MaxBrightness;

            return this;
        }
    }
}