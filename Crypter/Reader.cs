using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;

namespace Crypter
{
	class Reader
	{

		public static byte[] ReadFile(string inputFile)
		{
			byte[] payload_buffer = File.ReadAllBytes(inputFile);
			string payload_string = Convert.ToBase64String(payload_buffer);
	

			return payload_buffer;
		}

	}
}