using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Word
{
    /// <summary>
    /// Helpers for <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringExtender
    {
        /// <summary>
        /// Unsecures a secure string
        /// </summary>
        /// <param name="secureString">Secure string</param>
        /// <returns>Unsecured string</returns>
        public static string Unsecure(this SecureString secureString)
        {
            // If null, return
            if (secureString == null)
            {
                Console.WriteLine("Passed secure string can be null after all. see: SecureStringExtender.Unsecure");
                return String.Empty;
            }

            // Get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Cleans up the memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
