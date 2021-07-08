using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat.Data.JsonSettings
{
    public class JsonFile
    {
        public JsonFile()
        {

        }
        /// <summary>
        /// <br></br>
        /// JSON Data yolu
        /// <br></br>
        /// C:\Users\Emre\source\FoodAutomat\Otomat.Data\JsonData\
        /// </summary>
        public static string FileDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))+ @"\VERIALFoodAutomat\Otomat.Data\JsonData\";
    }
}
