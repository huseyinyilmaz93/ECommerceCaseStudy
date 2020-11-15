using System;
using System.IO;
using ECommerce.Web.Helpers.HelperInterfaces;

namespace ECommerce.Web.Helpers
{
    public class FileReader : IReader
    {
        public string[] Read(string accessor)
        {
            return File.ReadAllLines(accessor);
        }
    }
}
