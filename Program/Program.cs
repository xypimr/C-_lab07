using System.Reflection;

var path = "/Users/oldmash/RiderProjects/labsC#/C-_lab07/Animals/bin/Debug/net6.0/Animals.dll";
Assembly theAssembly = Assembly.LoadFrom(path);

void AppendXML(string output)
{
    File.AppendAllText("/Users/oldmash/RiderProjects/labsC#/C-_lab07/Program/AssemblyInfo.xml", output + "\n");
}

File.Delete("/Users/oldmash/RiderProjects/labsC#/C-_lab07/Program/AssemblyInfo.xml");
AppendXML("<Lab07>");
AppendXML(theAssembly.FullName);


foreach (Type definedType in theAssembly.ExportedTypes)
{
    if (definedType.GetTypeInfo().IsClass)
    {
        AppendXML($"\n<class> {definedType.Name} : {definedType.BaseType}");

        foreach (var attribute in definedType.GetCustomAttributes())
        {
            AppendXML($"<attribute>{attribute}</attriubute>");
        }
        
        foreach (MethodInfo method in definedType.GetMethods())
        {
            AppendXML($"<method>{(method.IsStatic ? "static " : "")}" +
                      $"{(method.IsVirtual ? "virtual " : "")}" +
                      $"{method.ReturnType.Name} {method.Name} ()</method>");
        }

        AppendXML("</class>");
    }
}

AppendXML("</Lab07>");