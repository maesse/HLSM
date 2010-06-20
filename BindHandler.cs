using System;
using System.Collections.Generic;
using System.Text;

namespace HLSM
{
    public sealed class BindHandler
    {
        public static BindHandler Instance { get { return _Instance; } }
        private static readonly BindHandler _Instance = new BindHandler();

        BindHandler()
        {
        }


    }
}
