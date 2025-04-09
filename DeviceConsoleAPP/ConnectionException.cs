namespace DeviceConsoleAPP;
class ConnectionException : Exception
{
    public ConnectionException() : base("Wrong netowrk name.") { }
}