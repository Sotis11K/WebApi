using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscribersEntity
{

    [Key]
    public string Email { get; set; } = null!;
    public string? DailyNewsletter { get; set; }
    public string? AdvertisingUpdates { get; set; }
    public string? WeekinReview { get; set; }
    public string? EventUpdates { get; set; }
    public string? StartupsWeekly { get; set; }
    public string? Podcasts { get; set; }
}
