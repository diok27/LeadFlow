using System.ComponentModel.DataAnnotations;
using LeadFlow.Api.Models;

namespace LeadFlow.Api.DTOs;

public class UpdateLeadRequest
{
    [Required][MinLength(2)] [MaxLength(25)] public string FirstName { get; set; } = "";
    [Required][MinLength(2)] [MaxLength(25)] public string LastName { get; set; } = "";
    [Phone]
    public string? Phone { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public LeadStatus Status { get; set; }
}