using LeadFlow.Api.Models;

namespace LeadFlow.Api.Services;

public interface ILeadService
{
    Task<List<Lead>> GetAllAsync();
    Task<Lead?> GetByIdAsync(int id);
    Task<Lead> CreateAsync(Lead lead);
    Task<Lead?> UpdateAsync(int id, Lead updated);
    Task<Lead?> DeleteAsync(int id);
}