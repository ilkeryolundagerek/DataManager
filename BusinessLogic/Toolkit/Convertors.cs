using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Toolkit
{
    public static class Convertors
    {
        public static string ByteArrayToBase64(byte[] bytes)
        {
            return "data:image/png;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}
