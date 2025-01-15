using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgOpenGPS
{
    public class CISOBUS
    {
        private long timestamp;

        private bool sectionControlEnabled;
        private bool desiredSectionControlEnabled;

        private List<bool> actualSectionStates = new List<bool>();

        public bool IsSectionOn(int section)
        {
            if (section < actualSectionStates.Count)
            {
                return actualSectionStates[section];
            }
            return false;
        }

        public bool IsSectionControlEnabled()
        {
            return sectionControlEnabled;
        }

        public bool IsAlive()
        {
            // Check if the timestamp is not older than 1 second
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - timestamp < 1000;
        }


        private static bool ReadBit(byte[] data, int bitIndex)
        {
            int byteIndex = bitIndex / 8; // Find the byte
            if (data.Length <= byteIndex)
            {
                return false;
            }
            int bitPosition = bitIndex % 8; // Find the bit within the byte
            return (data[byteIndex] & (1 << bitPosition)) != 0;
        }

        private static void WriteBit(ref byte[] data, int bitIndex, bool value)
        {
            int byteIndex = bitIndex / 8; // Find the byte
            if (data.Length <= byteIndex)
            {
                Array.Resize(ref data, byteIndex + 1);
            }
            int bitPosition = bitIndex % 8; // Find the bit within the byte
            if (value)
            {
                data[byteIndex] |= (byte)(1 << bitPosition);
            }
            else
            {
                data[byteIndex] &= (byte)~(1 << bitPosition);
            }
        }


        public bool DeserializeHeartbeat(byte[] data)
        {
            if (data.Length < 2)
            {
                // Make sure we can read at least the first bitmask and the number of sections
                return false;
            }

            this.sectionControlEnabled = ReadBit(data, 0);
            int numberOfSections = data[1];

            if (data.Length != 2 + Math.Ceiling(numberOfSections / 8.0))
            {
                // Make sure we have enough data to read all the section states
                return false;
            }

            for (int i = 0; i < numberOfSections; i++)
            {
                bool sectionState = ReadBit(data, 16 + i);
                if (this.actualSectionStates.Count <= i)
                    this.actualSectionStates.Add(sectionState);
                else
                    this.actualSectionStates[i] = sectionState;
            }

            // Truncate the list if there are more elements than needed
            if (this.actualSectionStates.Count > numberOfSections)
            {
                this.actualSectionStates.RemoveRange(numberOfSections, this.actualSectionStates.Count - numberOfSections);
            }
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return true;
        }
    }
}
