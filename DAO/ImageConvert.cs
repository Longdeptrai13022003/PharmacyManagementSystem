using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreManagementSystem.DAO
{
    internal class ImageConvert
    {
        public static byte[] ImageToByte(PictureBox pic)
        {
            MemoryStream mem = new MemoryStream();
            pic.Image.Save(mem,pic.Image.RawFormat);
            return mem.ToArray();
        }    
    }
}
