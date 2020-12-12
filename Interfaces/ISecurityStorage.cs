using System.Threading.Tasks;

namespace PinCode.Interfaces
{
    public interface ISecurityStorage
    {
        Task SetPIN(string pin);
        Task<string>GetPIN();
    }
}