using LeadFlow.Api.Exceptions;

namespace LeadFlow.Api.Services;
using LeadFlow.Api.Models;

public class LeadService : ILeadService
{
    private readonly List<Lead> _leads = new()
    {
        new Lead
        {
            Id = 1,
            FirstName = "Ali",
            LastName = "Karimov",
            Status = LeadStatus.New,
            Source = LeadSource.Website,
            CreatedAt = DateTime.UtcNow
        },

        new Lead
        {
            Id = 2,
            FirstName = "Diyor",
            LastName = "Tursunov",
            Status = LeadStatus.Contacted,
            Source = LeadSource.ColdCall,
            CreatedAt = DateTime.UtcNow.AddHours(-2)
        },
    };

    private static int _nextId = 3;


    public Task<List<Lead>> GetAllAsync()
    {
        return Task.FromResult(_leads);
    }


    public Task<Lead?> GetByIdAsync(int id)
    {
        Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

        if (existingLead == null)
        {
            throw new NotFoundException($"Lead with id {id} was not found");
        }
        else
        {
            return Task.FromResult<Lead?>(existingLead);
        }
    }


    public  Task<Lead> CreateAsync(Lead lead)
    {
        lead.Id = _nextId++;
        lead.CreatedAt = DateTime.UtcNow;

        _leads.Add(lead);

        return Task.FromResult(lead);
    }


    public Task<Lead?> UpdateAsync(int id, Lead updated)
    {
        Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

        if (existingLead == null)
        {
            return Task.FromResult<Lead?>(null);
        }
        else
        {
            existingLead.FirstName = updated.FirstName;
            existingLead.LastName = updated.LastName;
            existingLead.Phone = updated.Phone;
            existingLead.Email = updated.Email;
            existingLead.UpdatedAt = DateTime.UtcNow;
            existingLead.Status = updated.Status;
            existingLead.Source = updated.Source;
            return Task.FromResult<Lead?>(existingLead);
        }
    }

    public Task<Lead?> DeleteAsync(int id)
    {
        Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

        if (existingLead == null)
        {
            return Task.FromResult<Lead?>(null);
        }
        else
        {
            _leads.Remove(existingLead);
            return Task.FromResult<Lead?>(existingLead);
        }
    }
}