// using library;
using System.Reflection;
using Animals;

// загружаем нашу сборку
Assembly theAssembly = Assembly.Load(new AssemblyName("Animals"));

// добавляем текст в файл
void AppendXML(string output)
{
    File.AppendAllText("/Users/oldmash/RiderProjects/labsC#/C-_lab07/Program/AssemblyInfo.xml", output + "\n");
}

// очищаем файл и начинаем заполнять
File.Delete("/Users/oldmash/RiderProjects/labsC#/C-_lab07/Program/AssemblyInfo.xml");
AppendXML("<Lab07>");
AppendXML(theAssembly.FullName);



// для каждого типа в сборке
foreach (Type definedType in theAssembly.ExportedTypes)
{
    // если это клас
    if (definedType.GetTypeInfo().IsClass)
    {
        // записываем имя класс и его предка
        AppendXML($"\n<class> {definedType.Name} : {definedType.BaseType}");
        // получаем его атрибуты
        IEnumerable<CommentAttribute> attributes = definedType.GetTypeInfo().GetCustomAttributes().OfType<CommentAttribute>().ToArray();
        // если они есть то пишем комментарий
        if (attributes.Count() > 0)
        {
            foreach (CommentAttribute attribute in attributes)
            {
                AppendXML($"<comment>{attribute.Comment}</comment>");
            }
        }
        // выводим информацию о методах
        foreach (MethodInfo method in definedType.GetMethods())
        {
            AppendXML($"<method>{(method.IsStatic ? "static " : "")}{(method.IsVirtual ? "virtual " : "")}{method.ReturnType.Name} {method.Name} ()</method>");
        }
        AppendXML("</class>");//завершаем запись класса
    }
}

AppendXML("</Lab07>");//завершаем запись проекта