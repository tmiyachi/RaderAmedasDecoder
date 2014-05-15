using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RaderAmedasDecoder
{
    class RAGrib2 
    {
        public DateTime dataDateTime;
                
        public int numberOfDataPoints;        
        public int Ni, Nj;
        public double latitudeOfFirstGridPointInDegrees, longitudeOfFirstGridPointInDegrees;
        public double latitudeOfLastGridPointInDegrees, longitudeOfLastGridPointInDegrees;
        public double iDirectionIncrementInDegrees, jDirectionIncrementInDegrees;
        public int scanningMode;

        public float[] rainData;
        
        public RAGrib2(FileStream fs) 
        {
            int sectionLength, sectionNumber;

            int year, month, day, hour, minute, second;
            int productStatus;

            int sorceOfGridDefinition;
            int gridDefinitionTemplateNumber;

            uint productDefinitionTemplateNumber;

            int numberOfValue;
            int dataRepresentationTemplateNumber;
            int bitsPerValue;
            int maximumValueofData;
            int maximumValeOfLevel;
            int decimalScaleFactor;
            float scaleFactor;



            // 読み込み用バッファ
            byte[] buf2  = new byte[2];
            byte[] buf4  = new byte[4];
            byte[] buf16 = new byte[16];
            byte[] buf21 = new byte[21];
            byte[] buf72 = new byte[72];
            byte[] buf82 = new byte[82];

            ///
            ///  Section 0 < Indicator Section >
            ///
            fs.Read(buf16, 0, 16);
            // Octet 1-4   header
            if (buf16[0] != 'G' || buf16[1] != 'R' || buf16[2] != 'I' || buf16[3] != 'B') {
                throw new GribException("Section 1  Octet 1-4");
            }
            // Octet 5 - 7
            // Octet 8     edition number
            if (buf16[7] != 2) {
                throw new GribException("Section 1  Octet 8");
            }
            // Octet 9-16
            

            ///
            ///  Section 1 < Identification Section >
            ///
            fs.Read(buf21, 0, 21);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf21, 0);            
            if (sectionLength != 21)
            {
                return;
            }
            // Octet 5 section number
            sectionNumber = (int)buf21[4];
            if (sectionNumber != 1) return;
            // Octet 6-12            
            // Octet 13-14  year
            year   = SwapEndian.swap_endianInt16(buf21, 12);
            // Octet 15-19  month, day, hour, minute, second
            month  = (int)buf21[14];
            day    = (int)buf21[15];
            hour   = (int)buf21[16];
            minute = (int)buf21[17];
            second = (int)buf21[18];
            this.dataDateTime = new DateTime(year, month, day, hour, minute, second);
            // Octet 20    product status (0:operational 1:test)
            productStatus = (int)buf21[19];
            if (productStatus != 0)
            {
                return;
            }

            ///
            ///  Section 2 (not use)
            ///


            ///
            ///  Section 3 <Grid Definition Section>
            ///
            fs.Read(buf72, 0, 72);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf72, 0);
            if (sectionLength != 72)
            {
                return;
            }
            // Octet 5 section number
            sectionNumber = (int)buf72[4];
            if (sectionNumber != 3) return;
            // Octet 6    grid defenition (0:lat/lon)
            sorceOfGridDefinition = (int)buf72[5];
            // Octet 7-10 number of data points
            this.numberOfDataPoints = SwapEndian.swap_endianInt32(buf72, 6);
            // Octet 13-14 grid definition template number
            gridDefinitionTemplateNumber = SwapEndian.swap_endianInt16(buf72, 12);
            if (sorceOfGridDefinition != 0 || gridDefinitionTemplateNumber != 0)
            {
                return;
            } 
            // GridDefinition (lat/lon grid, see templatee 3.0)
            this.Ni = SwapEndian.swap_endianInt32(buf72, 30);
            this.Nj = SwapEndian.swap_endianInt32(buf72, 34);
            this.latitudeOfFirstGridPointInDegrees  = (double)SwapEndian.swap_endianInt32(buf72, 46) * 1e-6;
            this.longitudeOfFirstGridPointInDegrees = (double)SwapEndian.swap_endianInt32(buf72, 50) * 1e-6;
            this.latitudeOfLastGridPointInDegrees   = (double)SwapEndian.swap_endianInt32(buf72, 55) * 1e-6;
            this.longitudeOfLastGridPointInDegrees  = (double)SwapEndian.swap_endianInt32(buf72, 59) * 1e-6;
            this.iDirectionIncrementInDegrees       = (double)SwapEndian.swap_endianInt32(buf72, 63) * 1e-6;
            this.jDirectionIncrementInDegrees       = (double)SwapEndian.swap_endianInt32(buf72, 67) * 1e-6;
            this.scanningMode = (int)buf72[71];


            ///
            ///  Section 4 Product Definition Section
            ///  
            fs.Read(buf82, 0, 82);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf82, 0);
            if (sectionLength != 82)
            {
                return;
            }
            // Octet 5 section number
            sectionNumber = (int)buf82[4];
            if (sectionNumber != 4) return;            
            // Octet 8-9   template number
            productDefinitionTemplateNumber = SwapEndian.swap_endianUInt16(buf82, 7);
            if (productDefinitionTemplateNumber != 50008)
            {
                return;
            }


            ///
            /// Section 5  Data Representation Section
            ///           
            fs.Read(buf4, 0, 4);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf4, 0);          
            // Octet 5 section number
            sectionNumber = (int)fs.ReadByte();
            if (sectionNumber != 5) return;     
            // Octet 6-9  number of data points
            fs.Read(buf4, 0, 4);
            numberOfValue = SwapEndian.swap_endianInt32(buf4, 0);            
            // Octet 10-11  data reoresentation template
            fs.Read(buf2, 0, 2);
            dataRepresentationTemplateNumber = SwapEndian.swap_endianInt16(buf2, 0);
            if (dataRepresentationTemplateNumber != 200) return;
            //Octet 12-17  (template 5.200)
            bitsPerValue = (int)fs.ReadByte();
            if (bitsPerValue != 8) return;
            fs.Read(buf2, 0, 2);
            maximumValueofData = (int)SwapEndian.swap_endianInt16(buf2, 0);
            fs.Read(buf2, 0, 2);            
            maximumValeOfLevel = (int)SwapEndian.swap_endianInt16(buf2, 0); // MVL
            decimalScaleFactor = (int)fs.ReadByte();
            scaleFactor = (float)Math.Pow(10, decimalScaleFactor);

            // Octet 16+2xMVL - 17+2xMVL
            // read representative value
            short[] RData = new short[maximumValeOfLevel];
            for (int k = 0; k <= maximumValeOfLevel - 1; k++)
            {
                fs.Read(buf2, 0, 2);
                RData[k] = SwapEndian.swap_endianInt16(buf2, 0);
            }


            ///
            /// Section 6  Bit Map Section
            /// 
            fs.Read(buf4, 0, 4);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf4, 0);
            if (sectionLength != 6)
            {
                throw new GribException("Section6 Octet1-4");
            }
            // Octet 5 section number
            sectionNumber = (int)fs.ReadByte();
            if (sectionNumber != 6) return;
            fs.ReadByte();

            ///
            /// Section 7  data section
            /// 
            fs.Read(buf4, 0, 4);
            // Octet 1-4  length of section           
            sectionLength = SwapEndian.swap_endianInt32(buf4, 0);
            // Octet 5 section number
            sectionNumber = (int)fs.ReadByte();
            if (sectionNumber != 7) {
                throw new GribException("Section7 Octet5");
            }

            rainData = new float[numberOfDataPoints];
            int n1, n2;
            // Octet 6-section7Length  data
            ///
            /// データのデコード　（ランレングス圧縮）
            /// 
            int ij = 0;
            int bufPosition = 0;
            int nn, runLength;

            int a = (int)Math.Pow(2, bitsPerValue) - 1 - maximumValueofData;
            n1 = n2 = (int)fs.ReadByte();
            while (bufPosition < sectionLength - 6)
            {
                //while (bufPosition < 50) {

                n1 = n2;
                n2 = (int)fs.ReadByte();


                if (n2 > maximumValueofData)
                {
                    // run length case
                    runLength = 0;
                    nn = 0;
                    while (n2 > maximumValueofData)
                    {
                        runLength = runLength + (int)Math.Pow(a, nn) * (n2 - maximumValueofData - 1);
                        n2 = (int)fs.ReadByte();
                        nn++;
                    }
                    runLength = runLength + 1;
                    for (int n = 0; n < runLength; n++)
                    {
                        rainData[ij + n] = (float)RData[n1] / scaleFactor;
                    }                    
                    ij = ij + runLength;
                    bufPosition = bufPosition + nn + 1;
                }
                else
                {
                    rainData[ij] = (float)RData[n1] / scaleFactor;
                    ij++;

                    bufPosition = bufPosition + 1;
                }
            }


            ///
            /// Section 8  End Section            
            /// 
            fs.Read(buf4, 0, 4);

          
            











        }



        









    }
}
