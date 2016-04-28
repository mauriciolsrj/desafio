using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.IO;
using System.Net;
using desafio.app.domain;
using Newtonsoft.Json;

namespace desafio.app
{
    public class JsonUtility
    {
        public static T Deserialize<T> (string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString); 
        }
    }
}