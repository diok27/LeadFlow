using Microsoft.AspNetCore.Mvc;
using LeadFlow.Api.Models;

namespace LeadFlow.Api.Controllers;

[ApiController]
[Route("api/leads")]
public class LeadsController : ControllerBase
{
    private static readonly List<Lead> _leads = new()
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

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_leads);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

        if (existingLead == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(existingLead);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Lead lead)
    {
        lead.Id = _nextId++;
        lead.CreatedAt = DateTime.UtcNow;

         _leads.Add(lead);

         return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Lead updated)
    {
       Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

       if (existingLead == null)
       {
           return NotFound();
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
           return NoContent();
       }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Lead? existingLead = _leads.FirstOrDefault(lead => lead.Id == id);

        if (existingLead == null)
        {
            return NotFound();
        }
        else
        {
            _leads.Remove(existingLead);
            return NoContent();
        }
    }


}



