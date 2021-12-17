namespace DependencyInjectionNET6Demo.Services.Interfaces;

public interface ICustomLogger
{
    void Log(Exception ex);
    void Log(string info);
}