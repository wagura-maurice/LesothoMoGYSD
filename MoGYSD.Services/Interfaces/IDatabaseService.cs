namespace MoGYSD.Services.Interfaces
{
    public interface IDatabaseService : IDisposable
    {
        string GetComputerName(string clientIP);

        string GetExternalIP();
    }
}