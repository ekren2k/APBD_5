using DeviceConsoleAPP;

namespace APBD_5.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class DeviceController : ControllerBase
{
    private static DeviceRepository _deviceRepo;
    private DeviceFileParser _deviceFileParser;

    public DeviceController()
    {
        _deviceRepo = new DeviceRepository();
        _deviceFileParser = new DeviceFileParser("input.txt", _deviceRepo);
        PersonalComputer pc1 = new PersonalComputer("P-3", "Monster", true, "Arch Linux");
        PersonalComputer pc2 = new PersonalComputer("P-2", "Macintosh", true, "Mac OS X");
        _deviceRepo.AddDevice(pc1);
        _deviceRepo.AddDevice(pc2);
        
    }

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

}