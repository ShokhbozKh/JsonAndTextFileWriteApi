using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Money
    {
        public List<Datum> data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string min_size { get; set; }

        public override string ToString()
        {
            return $"ID:{id}, Name:{name}, Min_size:{min_size}";
        }
    }


}
