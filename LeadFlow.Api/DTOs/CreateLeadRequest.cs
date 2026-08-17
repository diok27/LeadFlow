using System.ComponentModel.DataAnnotations;
using LeadFlow.Api.Models;

namespace LeadFlow.Api.DTOs;

public class CreateLeadRequest : IValidatableObject
{
    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string FirstName { get; set; } = "";

    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string LastName { get; set; } = "";

    [Phone] public string? Phone { get; set; }

    [EmailAddress] public string? Email { get; set; }

    [Required] public LeadSource Source { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Phone) && string.IsNullOrWhiteSpace(Email))
        {
            yield return new ValidationResult("Phone or Email is required", new[] {nameof(Phone), nameof(Email)});
        }
    }

}