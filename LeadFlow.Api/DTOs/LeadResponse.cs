using LeadFlow.Api.Models;

namespace LeadFlow.Api.DTOs;

public class LeadResponse
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public LeadStatus Status { get; set; }
    public LeadSource Source { get; set; }
}