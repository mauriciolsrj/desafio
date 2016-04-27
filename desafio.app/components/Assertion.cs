using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace desafio.app
{
    public class Assertion
    {
       public static void IsTrue(bool exp, string message)
       {
            if(!exp)
                throw new PreConditionException(message);
       }
       
       public static void IsFalse(bool exp, string message)
       {
            if(exp)
                throw new PreConditionException(message);
       }
    }
}