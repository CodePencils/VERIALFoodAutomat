using Otomat.Data.JsonSettings;
using System.IO;

namespace Otomat.Data.Operations
{
    public class OPayments : IPayments
    {  
        public string Payments()
        {
            using (StreamReader r = new StreamReader(JsonFile.FileDirectory + "Payments.json"))
            {
                return r.ReadToEnd();
            }
        }
    }
}
