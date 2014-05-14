using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RaderAmedasDecoder
{
    class FilePathFuctory
    {
        public String baseDirPath;

        // constructer
        public FilePathFuctory(String baseDirPath)
        { 
            this.baseDirPath = baseDirPath;
        }

        public String getRaFilePath(DateTime date) 
        {
            String filePath = baseDirPath;

            filePath = Path.Combine(filePath, "ra");
            filePath = Path.Combine(filePath, date.ToString("yyyy"));
            filePath = Path.Combine(filePath, date.ToString("MM"));
            filePath = Path.Combine(filePath, date.ToString("dd"));
            filePath = Path.Combine(filePath, "Z__C_RJTD_" + date.ToString("yyyyMMddHHmm") + "00_SRF_GPV_Ggis1km_Prr60lv_ANAL_grib2.bin");
            return filePath;
        }

    }
}
