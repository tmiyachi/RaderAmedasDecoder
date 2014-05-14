using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaderAmedasDecoder
{
    class SwapEndian
    {
         public static int swap_endianInt16(byte[] byteArray, int startIndex)
        {
            byte[] swapByteArray = new byte[2];
            Array.Copy(byteArray, startIndex, swapByteArray, 0, 2);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(swapByteArray);

            return BitConverter.ToInt16(swapByteArray, 0);
        }

        public static uint swap_endianUInt16(byte[] byteArray, int startIndex)
        {
            byte[] swapByteArray = new byte[2];
            Array.Copy(byteArray, startIndex, swapByteArray, 0, 2);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(swapByteArray);

            return BitConverter.ToUInt16(swapByteArray, 0);
        }

        public static int swap_endianInt32(byte[] byteArray, int startIndex)
        {
            byte[] swapByteArray = new byte[4];
            Array.Copy(byteArray, startIndex, swapByteArray, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(swapByteArray);

            return BitConverter.ToInt32(swapByteArray, 0);
        }

        public static uint swap_endianUInt32(byte[] byteArray, int startIndex)
        {
            byte[] swapByteArray = new byte[4];
            Array.Copy(byteArray, startIndex, swapByteArray, 0, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(swapByteArray);

            return BitConverter.ToUInt32(swapByteArray, 0);
        }
    }


    }
