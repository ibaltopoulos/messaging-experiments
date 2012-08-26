using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("messaging")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("messaging")]
[assembly: AssemblyCopyright("Copyright ©  2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("6f91b41a-729a-4c3f-a418-bdfe3f37c59f")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace messaging.Properties {
    public static class AssemblyInfo {
        public static string Author = "Ioannis Baltopoulos";
        public static string Email = "ioannis.baltopoulos@gmail.com";
        public static string Title { get { return Get<AssemblyTitleAttribute>(at => at.Title); } }
        public static string Company { get { return Get<AssemblyCompanyAttribute>(at => at.Company); } }
        public static string Copyright { get { return Get<AssemblyCopyrightAttribute>(at => at.Copyright); } }
        public static string Version { get { return Get<AssemblyVersionAttribute>(at => at.Version); } }

        private static string Get<T>(Func<T, string> getProperty) where T : Attribute {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), true);
            if (attributes.Length <= 0) return string.Empty;
            var attr = (T) attributes.First();
            return getProperty(attr);
        }
    }
}