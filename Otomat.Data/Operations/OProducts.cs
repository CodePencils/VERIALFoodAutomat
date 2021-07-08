using Otomat.Data.JsonSettings;
using System.IO;

namespace Otomat.Data.Operations
{
    public class OProducts : IProducts
    {
        public string Products()
        {
            using (StreamReader r = new StreamReader(JsonFile.FileDirectory+ "Products.json"))
            {
                return r.ReadToEnd();
            } 
        }
    }
}
