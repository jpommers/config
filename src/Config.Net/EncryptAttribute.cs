using System;
using System.Collections.Generic;
using System.Text;

namespace Config.Net
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
   public class EncryptAttribute : Attribute
   {
   }
}
