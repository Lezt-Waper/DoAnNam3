﻿using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Model;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : Controller
{
    private readonly IClientData _db;

    public ClientController(IClientData db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _db.Get();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _db.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        try
        {
            await _db.Create(client);

            var result = await _db.Get(client.ClientId);

            return Ok();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
