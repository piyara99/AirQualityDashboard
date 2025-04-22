using System.ComponentModel.DataAnnotations;

public class AlertThresholdViewModel
{
    public int Id { get; set; }

    [Required]
    public required string AQICategory { get; set; }

    [Required]
    [Display(Name = "Minimum AQI")]
    public int MinValue { get; set; }

    [Required]
    [Display(Name = "Maximum AQI")]
    public int MaxValue { get; set; }

    [Required]
    public required string ColorCode { get; set; }
}
