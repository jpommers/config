using System;
using System.Collections.Generic;
using System.Text;

namespace Config.Net
{
   /// <summary>
   /// cryption interface
   /// </summary>
   public interface ICrypter
   {
      /// <summary>
      /// encryption method
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
      string Encrypt(string input);

      /// <summary>
      /// decryption method
      /// </summary>
      /// <param name="input"></param>
      /// <returns></returns>
      string Decrypt(string input);
   }
}
