using System.Security;

namespace Word
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}