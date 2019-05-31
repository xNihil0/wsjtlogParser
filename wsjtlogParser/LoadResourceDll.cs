using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace wsjtlogParser
{
    public static class LoadResoureDll
    {
        /// <summary> 已加载DLL
        /// </summary>
        private static Dictionary<string, Assembly> LoadedDlls = new Dictionary<string, Assembly>();
        /// <summary> 已处理程序集
        /// </summary>
        private static Dictionary<string, object> Assemblies = new Dictionary<string, object>();
        /// <summary> 在对程序集解释失败时触发
        /// </summary>
        /// <param name="sender">AppDomain</param>
        /// <param name="args">事件参数</param>
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                Assembly ass;
                var assName = new AssemblyName(args.Name).FullName;
                if (LoadedDlls.TryGetValue(assName, out ass) && ass != null)
                {
                    LoadedDlls[assName] = null;
                    return ass;
                }
                else
                {
                    throw new DllNotFoundException(assName);
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary> 注册资源中的dll
        /// </summary>
        /// <param name="pattern">*表示连续的未知字符,_表示单个未知字符,如*.dll</param>
        public static void RegistDLL(string pattern = "*.dll")
        {
            System.IO.Directory.GetFiles("", "");
            var ass = new StackTrace(0).GetFrame(1).GetMethod().Module.Assembly;
            if (Assemblies.ContainsKey(ass.FullName))
            {
                return;
            }
            Assemblies.Add(ass.FullName, null);
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
            var res = ass.GetManifestResourceNames();
            var regex = new Regex("^" + pattern.Replace(".", "\\.").Replace("*", ".*").Replace("_", ".") + "$", RegexOptions.IgnoreCase);
            foreach (var r in res)
            {
                if (regex.IsMatch(r))
                {
                    try
                    {
                        var s = ass.GetManifestResourceStream(r);
                        var bts = new byte[s.Length];
                        s.Read(bts, 0, (int)s.Length);
                        var da = Assembly.Load(bts);
                        if (LoadedDlls.ContainsKey(da.FullName))
                        {
                            continue;
                        }
                        LoadedDlls[da.FullName] = da;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Loading DLL failed.\nProcedure: RegistDLL()\nDescription: " + ex.Message);
                    }
                }
            }
        }
    }
}
