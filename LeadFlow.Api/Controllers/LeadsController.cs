using Microsoft.AspNetCore.Mvc;
using LeadFlow.Api.Models;
using LeadFlow.Api.Services;
using LeadFlow.Api.DTOs;
using LeadFlow.Api.LeadMappers;

namespace LeadFlow.Api.Controllers;

[ApiController]
[Route("api/leads")]
public class LeadsController : ControllerBase
{
    private readonly ILeadService _leadsService;

    public LeadsController(ILeadService leadService)
    {
        _leadsService = leadService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
     var leads = await _leadsService.GetAllAsync();
     var mapped = leads.Select(lead => lead.ToResponse()).ToList();
     return Ok(mapped);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lead = await _leadsService.GetByIdAsync(id);
            return Ok(lead.ToResponse());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLeadRequest request)
    {
        var lead = request.ToEntity();
        var created  = await _leadsService.CreateAsync(lead);

         return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToResponse());
    }

    [HttpPut("{id}")]
    public async Task <IActionResult> Update(int id, UpdateLeadRequest request)
    {
        var lead = new Lead();
        request.ApplyTo(lead);
        var updated = await _leadsService.UpdateAsync(id, lead);
        if (updated == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(updated.ToResponse());
        }
    }

    [HttpDelete("{id}")]
    public async Task <IActionResult> Delete(int id)
    {
        var deletedLead = await _leadsService.DeleteAsync(id);

        if (deletedLead == null)
        {
            return NotFound();
        }
        else
        {
            return NoContent();
        }
    }


}



