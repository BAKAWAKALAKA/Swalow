using Swalow.Model;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Swalow
{
    public class Generator
    {
        public static void Do(string path)
        {
            var builder = new StringBuilder();
            path = @"C:\Users\Gamers\source\repos\Swalow\SwalowTest\SwalowTest.xml";
            var localPath = @"C:\Users\Gamers\source\repos\Swalow\doc";
            var serializer =new XmlSerializer(typeof(doc));
            doc doc;
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                // in doc class maybe we can devide members in diferent arrays(aka feature and methos) 
                // by "name=F:" and "name=M:" attributes
                // see https://docs.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes
                doc = (doc)serializer.Deserialize(reader);
            }
            if (doc == null) return;

            // assembly can be more than just one and can have iearhery structure so 
            // in futere we need consider it
            foreach (var assembly in doc.assembly)
            {
                //generate assembly forder(and other needed staff) if isn't exisist
                if (!Directory.Exists(localPath + assembly.name))
                {
                    Directory.CreateDirectory(localPath + "\\" + assembly.name);
                }
                // create .md file for each class
                // as i can understand T: prefix considering type entinity(like class or struct)
                // M: - method
                // F: - member (varible or feature)
                // so I need join member named T:assembly.myclass with same F:assembly.myclass.myfeature and M:assembly.myclass.my.methosd
                // i realy dont like that xml dont have more information about assembly and maybe I need read CLRviaC# 
                // and using reflection and roslyn but its just sceth of my idea for now
                // and for string mathing maybe i need use regex

                // first we execute class name with our assembly name
                // for that we need this string pattern ^T:OUR_ASSEMBLY.[^.]*\z
                foreach (var Class in doc.members.Where(q => q.IsAssemblyClass(assembly.name)))
                {
                    builder.Clear();
                    // for summary and somthing other 
                    var className = Class.name.Replace("T:"+assembly.name+".","");

                    builder.AppendLine("---");
                    builder.AppendLine("title: About");
                    builder.AppendLine("layout: default");
                    builder.AppendLine("---");
                    builder.AppendLine($"# Class {className}");
                    builder.AppendLine($"See the [{assembly.name}](https://github.com/BAKAWAKALAKA/bakawakalaka.github.io)");

                    builder.AppendLine("h2 Summary:");
                    builder.AppendLine("============");

                    builder.AppendLine(Class.summary);

                    builder.AppendLine("h2 Varibles:");
                    builder.AppendLine("------------");

                    // get all features and varibles of current class
                    foreach (var features in doc.members.Where(q => q.IsClassFeature( assembly.name+"."+ className)))
                    {
                        builder.AppendLine($"### {features.name.Replace("F:"+assembly.name + "." + className +".", "")} ###");
                        builder.AppendLine(features.summary);
                    }

                    builder.AppendLine("------------");
                    builder.AppendLine("h2 Methods:");
                    // get all methods of current class
                    foreach (var methods in doc.members.Where(q => q.IsClassMethod(assembly.name + "." + className)))
                    {
                        builder.AppendLine($"### {methods.name.Replace("M:" + className + ".", "")} ###");
                        builder.AppendLine(methods.summary);
                        builder.AppendLine(" ");

                        builder.AppendLine($"#### Параметры ####");
                        builder.AppendLine("Name        Type        Summary");
                        builder.AppendLine("---------- ----------  -----------");
                        foreach (var param in methods.param)
                        {
                            builder.AppendLine($"{param.name.Replace("M:" + className + ".", "")}   type    {param.content}");
                            builder.AppendLine(" ");
                        }
                        builder.AppendLine("---------- ----------  -----------");
                    }

                    // generate page or md (i'm not decide yet)
                    // well I see two way of generated view file
                    // 1st like there - fill stringbuilder with text and then save it in file
                    // 2nd is create transitial class and then serealize it with custom serializer
                    // into text then save it in file (maybe something like string.fortmat()?)

                    // create viw file
                    var classFile = localPath + "\\" + assembly.name + "\\" + className+".md";
                    File.WriteAllText(classFile, builder.ToString());
                }
            }
        }


    }
}
