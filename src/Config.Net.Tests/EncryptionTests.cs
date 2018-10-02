using System;
using System.Collections.Generic;
using System.Text;
using Config.Net.Stores;
using Xunit;

namespace Config.Net.Tests
{
   public class EncryptionTests
   {
      
      [Fact]
      public void Reverse_string_encryption_value_match()
      {
         ICryptedConfig config = new ConfigurationBuilder<ICryptedConfig>()
         .UseConfigStore(new InMemoryConfigStore())
         .UseCrypter(new ReverseStringCrypter())
         .Build();

         string testValue = "123";
         config.CryptedValue = testValue;
         Assert.Equal(testValue,config.CryptedValue);
      }

      [Fact]
      public void Reverse_string_encryption_check()
      {
         var store = new TestConfigStore();

         ICryptedConfig config = new ConfigurationBuilder<ICryptedConfig>()
         .UseConfigStore(store)
         .UseCrypter(new ReverseStringCrypter())
         .Build();

         string testValue = "123";
         string encryptedTestValue = "321";

         config.CryptedValue = testValue;

         Assert.Equal(encryptedTestValue, store.singleTestValue);
      }

      [Fact]
      public void Encryption_no_encryptor_provided()
      {
         ICryptedConfig config = new ConfigurationBuilder<ICryptedConfig>()
         .UseConfigStore(new InMemoryConfigStore())
         .Build();

         string testValue = "123";

         Assert.Throws<InvalidOperationException>(() => config.CryptedValue = testValue);
      }
   }

   public interface ICryptedConfig
   {
      [Encrypt]
      string CryptedValue { get; set; }
      string NonCryptedValue { get; set; }
   }

   class ReverseStringCrypter : ICrypter
   {
      public string Decrypt(string input)
      {
         return Reverse(input);
      }

      public string Encrypt(string input)
      {
         return Reverse(input);
      }

      private string Reverse(string input)
      {
         char[] output = input.ToCharArray();
         Array.Reverse(output);
         return new string(output);
      }
   }

   class TestConfigStore : IConfigStore
   {
      public bool CanRead => true;

      public bool CanWrite => true;

      public string singleTestValue;

      public void Dispose()
      {
      }

      public string Read(string key)
      {
         return singleTestValue;
      }

      public void Write(string key, string value)
      {
         singleTestValue = value;
      }
   }
}
