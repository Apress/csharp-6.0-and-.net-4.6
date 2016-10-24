using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
  public class MathService : IBasicMath
  {
    public int Add(int x, int y)
    {
      // To simulate a lengthy request. 
      System.Threading.Thread.Sleep(5000);
      return x + y;
    }
  }
}
