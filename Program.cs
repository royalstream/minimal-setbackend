using System;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace MinimalSetBackend
{
    class Program
    {
        const int AF_BACKEND_DEFAULT = 0;
        const int AF_BACKEND_CPU     = 1;
        const int AF_BACKEND_CUDA    = 2;
        const int AF_BACKEND_OPENCL  = 3;

        const string DLLNAME = "af";

        [DllImport(DLLNAME, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        static extern int af_set_backend(int backend);

        [DllImport(DLLNAME, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
        static extern int af_info();

        static void VERIFY(int result)
        {
            Console.WriteLine(result == 0 ? "Operation succeded" : "Operation failed");
        }

        static void Main(string[] args)
        {
            VERIFY(af_set_backend(AF_BACKEND_OPENCL));
            VERIFY(af_info());
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
