using Demo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PatrickReed.ServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 10);

            ServiceHost folderServiceHost = null;

            try
            {
                folderServiceHost = new ServiceHost(typeof(FolderService));
                folderServiceHost.Open();

                Console.WriteLine("The FolderService is ready and listening.");
                Console.WriteLine("Press enter to close.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            finally
            {
                folderServiceHost.Close();
            }
        }
    }
}
