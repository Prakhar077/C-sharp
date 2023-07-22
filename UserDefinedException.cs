using System;
using System.IO;

namespace ExcpSample
{
  public class CustomException : Exception
  {
    public CustomException() {}
    public CustomException(string message) : base(message) {}
    public CustomException(string message, Exception inner) : base(message, inner) {}
  }
}
