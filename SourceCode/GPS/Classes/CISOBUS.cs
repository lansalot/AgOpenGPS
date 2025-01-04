using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Collections.Specialized.BitVector32;

namespace AgOpenGPS
{
    public class ISOBUS // ISOBUS (0x70 / 112)
    {

        /// <summary>
        /// PGN - 112 - 0x70
        /// </summary>
        private readonly FormGPS mf;

        public byte[] pgn;
        public int numberOfSections;


        public ISOBUS(FormGPS _f)
        {
            mf = _f;
        }

        /// <summary>
        /// Reset all section widths to 0 within the predefined PGN structure
        /// </summary>
        public void ResetSections(int _numberofSections)
        {
            numberOfSections = _numberofSections;
            pgn = new byte[6 + numberOfSections];
            pgn[0] = 0x80; // standard AIO header
            pgn[1] = 0x81; // PGN header
            pgn[2] = 0x70; // PGN major header
            pgn[3] = 0x00; // PGN minor header
            pgn[4] = (byte)numberOfSections;
            Buffer.BlockCopy(new byte[pgn.Length - 6], 0, pgn, 6, pgn.Length - 6);
        }

        public void MakeCRC() // when is this used? Not so far...
        {
            int crc = 0;
            for (int i = 2; i < pgn.Length - 1; i++) // CRC calculation excludes the last byte
            {
                crc += pgn[i];
            }
            pgn[pgn.Length - 1] = (byte)(crc & 0xFF);
        }
    }

}
