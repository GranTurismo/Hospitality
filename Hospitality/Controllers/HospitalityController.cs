using HospitalityShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Controllers;

public class HospitalityController:Controller
{
    private readonly IkaMedContext _dbContext;

    public HospitalityController(IkaMedContext dbContext) => _dbContext = dbContext;

    public IActionResult Index()
    {
        return Ok();
    }
}