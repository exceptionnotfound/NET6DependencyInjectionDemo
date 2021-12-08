using DependencyInjectionNET6Demo.Services.Interfaces;

namespace DependencyInjectionNET6Demo.Services
{
    public class CustomLogger : ICustomLogger
    {
        public void Log(Exception ex)
        {
            //Implementation details left to user. What do YOU think this should do?
            throw new NotImplementedException();
        }
    }
}
