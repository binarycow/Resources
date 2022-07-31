using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace WpfApp1;

public static class DependencyObjectExtensions
{
    public static T? GetValue<T>(
        this DependencyObject dependencyObject,
        DependencyProperty property
    ) => dependencyObject.GetValue(property) is T typed ? typed : default;
    
    [return: NotNullIfNotNull("value")]
    public static T? SetValue<T>(
        this DependencyObject dependencyObject,
        DependencyProperty property,
        T? value
    )
    {
        dependencyObject.SetValue(property, value!);
        return value;
    }
}