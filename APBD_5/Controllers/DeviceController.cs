using DeviceConsoleAPP;

namespace APBD_5;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class DeviceController : ControllerBase
{
    private static DeviceRepository _deviceRepo;

    public DeviceController()
    {
        _deviceRepo = new DeviceRepository();
    }

    [HttpGet(Name = "GetDevices")]
    public List<Device> GetDevices()
    {
        return _deviceRepo.GetDevices();
    }
    
}