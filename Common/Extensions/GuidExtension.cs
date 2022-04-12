using System.Security.Cryptography;
using System.Text;

namespace Common.Extensions;

public static class GuidExtension
{
    public static string FromString(string name)
    {
        using MD5 md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(name));
        return new Guid(hash).ToString();
    }
}
