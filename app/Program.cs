using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("CPUs: {0}", Environment.ProcessorCount);
          
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxIoThreads);
            ThreadPool.GetAvailableThreads(out int freeWorkerThreads, out int freeIoThreads);
            ThreadPool.GetMinThreads(out int minWorkerThreads, out int minIoThreads);
          
            int busyIoThreads = maxIoThreads - freeIoThreads;
            int busyWorkerThreads = maxWorkerThreads - freeWorkerThreads;

            Console.WriteLine("worker_threads_min: {0}", minWorkerThreads);
            Console.WriteLine("worker_threads_max: {0}", maxWorkerThreads);

            Console.WriteLine("worker_threads_free: {0}", freeWorkerThreads);
            Console.WriteLine("worker_threads_busy: {0}", busyWorkerThreads);

            Console.WriteLine("io_threads_min: {0}", minIoThreads);
            Console.WriteLine("io_threads_max: {0}", maxIoThreads);

            Console.WriteLine("io_threads_free: {0}", freeIoThreads);
            Console.WriteLine("io_threads_busy: {0}", busyIoThreads);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
