using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectInput;

namespace HLSM
{
    [Serializable()]
    public class Sound
    {
        public string Filename;
        public List<Key> Bind;

        public Sound()
        {

        }

        public Sound(string Filename, List<Key> Bind)
        {
            this.Filename = Filename;
            this.Bind = Bind;
            if (this.Bind == null)
                this.Bind = new List<Key>();
        }

        public string BindToString()
        {
            string data = "";
            foreach (Key key in Bind)
            {
                data += key.ToString() + "+";
            }
            if (data.Length > 0)
                data = data.Substring(0, data.Length - 1);
            else
                data = "N/A";

            return data;
        }
    }
}
