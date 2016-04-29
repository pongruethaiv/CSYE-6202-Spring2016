using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using G = System.Configuration;

namespace AirlineReservationSystem.Domain
{
    public static class SerializeHelper
    {
        public static byte[] SerializeToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            else
            {
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(streamMemory, obj);
                return streamMemory.GetBuffer();
            }
        }

        public static T Deserialize<T>(byte[] byteArray) where T : class
        {
            if (byteArray == null)
            {
                return null;
            }
            else
            {
                if (byteArray.Length == 0)
                {
                    return null;
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(byteArray);
                    return (T)formatter.Deserialize(ms);
                }
            }
        }

        

    }
}
