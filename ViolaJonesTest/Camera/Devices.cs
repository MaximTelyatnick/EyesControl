using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolaJonesTest.Camera
{
    struct Devices
    {
        public string DeviceName;
        public int DeviceId;
        public Guid Identifier;

        public Devices(int DeviceId, string DeviceName, Guid Identifier = new Guid())
        {
            this.DeviceId = DeviceId;
            this.DeviceName = DeviceName;
            this.Identifier = Identifier;
        }

        public override string ToString()
        {
            return String.Format("[{0}] {1}: {2}", DeviceId, DeviceName, Identifier);
        }
    }
}
