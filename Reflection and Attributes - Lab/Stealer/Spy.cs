using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string typeName, params string[] requestedFields)
    {
        var classType = Type.GetType(typeName);

        var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.NonPublic | BindingFlags.Public);

        var builder = new StringBuilder();

        var classInstance = Activator.CreateInstance(classType, new object[] { });

        builder.AppendLine($"Class under investigation: {typeName}");

        foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string typeName)
    {
        var output = new StringBuilder();

        var classType = Type.GetType(typeName);

        var fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        var getters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(p => p.Name.StartsWith("get"));
        var setters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(p => p.Name.StartsWith("set"));

        foreach (var field in fields)
        {
            output.AppendLine($"{field.Name} must be private!");
        }
        foreach (var getter in getters)
        {
            if (getter.IsPrivate)
            {
                output.AppendLine($"{getter.Name} have to be public!");
            }
        }
        foreach (var setter in setters)
        {
            if (setter.IsPublic)
            {
                output.AppendLine($"{setter.Name} have to be private!");
            }
        }

        return output.ToString().Trim();
    }

    public string RevealPrivateMethods(string typeName)
    {
        var classType = Type.GetType(typeName);
        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {typeName}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in methods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().Trim();
    }

    public string CollectGettersAndSetters(string typeName)
    {
        var classType = Type.GetType(typeName);
        var getters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get"));
        var setters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("set"));

        var result = new StringBuilder();

        foreach (var getter in getters)
        {
            result.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }
        foreach (var setter in setters)
        {
            result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return result.ToString().Trim();
    }
}
