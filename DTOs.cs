namespace RaceDayMVC.Models;

public class LoginRequest { public string Email { get; set; } = string.Empty; public string Password { get; set; } = string.Empty; }
public class LoginResponse { public string Email { get; set; } = string.Empty; public string Role { get; set; } = string.Empty; public string Token { get; set; } = string.Empty; }
public class RegisterRequest { public string Email { get; set; } = string.Empty; public string Password { get; set; } = string.Empty; public string Role { get; set; } = "Participant"; }

public class EventDto 
{ 
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public double Distance { get; set; }
    public string EventType { get; set; } = string.Empty;
    public string BannerImageUrl { get; set; } = string.Empty;
}

public class EnrollmentDto
{
    public int Id { get; set; }
    public string ParticipantEmail { get; set; } = string.Empty;
    public string EventName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Confirmed, Pending
    public string FinishTime { get; set; } = string.Empty;
    public int? FinishingPosition { get; set; }
}
