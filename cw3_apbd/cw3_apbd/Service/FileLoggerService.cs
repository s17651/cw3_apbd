using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public class FileLoggerService : IRequestLogService
    {
        private readonly string LOG_FILE = "logFile.txt";

        public async void save(HttpRequest request)
        {
            request.EnableBuffering();
            string path = request.Path;
            string method = request.Method;
            string queryString = request.QueryString.ToString();
            string bodyStr = "";

            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }
            if (!File.Exists(LOG_FILE))
            {
                File.CreateText(LOG_FILE);
            }

            FileStream fileStream = new FileStream(LOG_FILE, FileMode.Append, FileAccess.Write);
            try
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine(DateTime.Now);
                writer.WriteLine("Path: " + path);
                writer.WriteLine("Method: " + method);
                writer.WriteLine("Query: " + queryString);
                writer.WriteLine("Body: " + bodyStr);
                writer.WriteLine();
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
