using LeadFlow.Api.DTOs;
using LeadFlow.Api.Models;

namespace LeadFlow.Api.LeadMappers;

public static class LeadMapper
{
    public static Lead ToEntity(this CreateLeadRequest request)
    {
        return new Lead
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Email = request.Email,
            Source = request.Source
        };
    }

    public static LeadResponse ToResponse(this Lead response)
    {
        return new LeadResponse
        {
            Id = response.Id,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Phone = response.Phone,
            Email = response.Email,
            Source = response.Source,
            Status = response.Status,
            CreatedAt = response.CreatedAt,
            UpdatedAt = response.UpdatedAt
        };
    }

    public static void ApplyTo(this UpdateLeadRequest request, Lead lead)
    {
        lead.FirstName = request.FirstName;
        lead.LastName = request.LastName;
        lead.Phone = request.Phone;
        lead.Email = request.Email;
        lead.Status = request.Status;
    }
}
