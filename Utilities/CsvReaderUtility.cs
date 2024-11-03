using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PayProConsoleApp.Utilities
{
    public static class CsvReaderUtility
    {
        public static async Task<IEnumerable<string>> ReadFileAsync(string filePath)
        {
            var lines = new List<string>();
            using var reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                lines.Add(await reader.ReadLineAsync());
            }

            return lines;
        }
    }
}
