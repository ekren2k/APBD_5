using System.Text.Json;
using DeviceConsoleAPP;

namespace APBD_5.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
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

    /*[HttpPost]*/
    
    // don't forget to put "$type": (f.e.) "smartwatch" in your json body request so that it knows what is the type of your device
    // P.S. I forgot to put it there and spent about 2 hours solving a non-existent issue 💀
    /*
    public IActionResult Post([FromBody] Device device)
    {
        try
        {
            _deviceRepo.AddDevice(device);
            return CreatedAtAction(nameof(GetDevices), new { id = device.Id }, device);
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
    */

    [HttpPost(Name = "AddPC")]
    public IActionResult Post([FromBody] PersonalComputer pc)
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

    [HttpPost(Name = "AddSmartwatch")]
    public IActionResult Post([FromBody] Smartwatch sw)
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
    
    [HttpPost(Name = "AddEmbeddedDevice")]
    
    public IActionResult Post([FromBody] Embedded ed)
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

    /*[HttpPut]
    public IActionResult Put([FromBody] Device updatedDevice)
    {
        try
        {
            _deviceRepo.EditDevice(updatedDevice);
            return Ok(updatedDevice);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Something went wrong: {ex.Message}");
        }
    }*/

    [HttpPut(Name = "UpdatePC")]
    public IActionResult Put([FromBody] PersonalComputer updatedPC)
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
    
    [HttpPut(Name = "UpdateSmartwatch")]
    public IActionResult Put([FromBody] Smartwatch updatedSmartwatch)
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
    
    [HttpPut(Name = "UpdateEmbeddedDevice")]
    
    public IActionResult Put([FromBody] Embedded updatedEmbedded)
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