using System.Text.Json;
using DeviceConsoleAPP;

namespace APBD_5.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/devices")]
public class DeviceController : ControllerBase
{
    // I use this just to initialize the list with some data, don't bully me for violating SOLID principles please 😭
    private static DeviceRepository _deviceRepo = new DeviceRepository();
    private DeviceFileParser _deviceFileParser = new DeviceFileParser("input.txt", _deviceRepo);
    private static List<Device> _devices = _deviceRepo.GetDevices();

    public DeviceController() { }

    [HttpGet(Name = "GetDevices")]
    public IEnumerable<Device> GetDevices()
    {
        return _deviceRepo.GetDevices();
    }

    [HttpGet("{id}")]
    public Device? GetDeviceById(string id)
    {
        return _deviceRepo.GetDeviceById(id);

    }

    [HttpGet("pc/{id}")]
    public ActionResult<PersonalComputer> GetPC(string id)
    {
        var pc = _deviceRepo.GetPersonalComputerById(id);
        return pc is null ? NotFound($"No PersonalComputer with ID {id}") : Ok(pc);
    }

    [HttpGet("smartwatch/{id}")]
    public ActionResult<Smartwatch> GetSmartwatch(string id)
    {
        var sw = _deviceRepo.GetSmartwatchById(id);
        return sw is null ? NotFound($"No Smartwatch with ID {id}") : Ok(sw);
    }

    [HttpGet("embedded/{id}")]
    public ActionResult<Embedded> GetEmbedded(string id)
    {
        var ed = _deviceRepo.GetEmbeddedById(id);
        return ed is null ? NotFound($"No Embedded with ID {id}") : Ok(ed);
    }
    
    

    [HttpPost("pc")]
    public IActionResult PostPC([FromBody] PersonalComputer pc)
    {
        try
        {
            _deviceRepo.AddDevice(pc);
            return CreatedAtAction(nameof(GetDevices), new { id = pc.Id }, pc);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Something went wrong: {e.Message}");
        }
    }

    [HttpPost("smartwatch")]
    public IActionResult PostSmartwatch([FromBody] Smartwatch sw)
    {
        try
        {
            _deviceRepo.AddDevice(sw);
            return CreatedAtAction(nameof(GetDevices), new { id = sw.Id }, sw);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Something went wrong: {e.Message}");
        }
    }
    
    [HttpPost("embedded")]
    
    public IActionResult PostEmbedded([FromBody] Embedded ed)
    {
        try
        {
            _deviceRepo.AddDevice(ed);
            return CreatedAtAction(nameof(GetDevices), new { id = ed.Id }, ed);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Something went wrong: {e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        try
        {
            _deviceRepo.RemoveDeviceById(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong: {ex.Message}");
        }
    }


    [HttpPut("pc")]
    public IActionResult PutPC([FromBody] PersonalComputer updatedPC)
    {
        try
        {
            _deviceRepo.EditDevice(updatedPC);
            return Ok(updatedPC);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong: {ex.Message}");
        }
    }
    
    [HttpPut("smartwatch")]
    public IActionResult PutSmartwatch([FromBody] Smartwatch updatedSmartwatch)
    {
        try
        {
            _deviceRepo.EditDevice(updatedSmartwatch);
            return Ok(updatedSmartwatch);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong: {ex.Message}");
        }
    }
    
    [HttpPut("embedded")]
    
    public IActionResult PutEmbedded([FromBody] Embedded updatedEmbedded)
    {
        try
        {
            _deviceRepo.EditDevice(updatedEmbedded);
            return Ok(updatedEmbedded);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong: {ex.Message}");
        }
    }
}