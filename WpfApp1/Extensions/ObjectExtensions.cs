using System.Diagnostics.CodeAnalysis;

namespace WpfApp1;

public static class ObjectExtensions
{
    public static bool Is<T>(this object? value, [MaybeNullWhen(false)] out T result)
    {
        result = default;
        if (value is not T typed) 
            return false;
        result = typed;
        return true;
    }
    
    [return: NotNullIfNotNull("specifiedDefault")]
    public static T? As<T>(this object? value, T? specifiedDefault = default) 
        => value is T typed ? typed : specifiedDefault;
}