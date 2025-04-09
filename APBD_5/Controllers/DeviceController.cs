using System.Text.Json;
using DeviceConsoleAPP;

namespace APBD_5.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class DeviceController : ControllerBase
{
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

    [HttpPost]
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

    [HttpPut]
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
    }
}