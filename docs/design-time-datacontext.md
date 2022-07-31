[Home](https://github.com/binarycow/Resources)

* [Option 1](#option1): Have your `Control` or `Window` create the `DataContext` instance itself, at both compile time and runtime.
* [Option 2](#option2): Specify the type only - the WPF designer will not create the type for you.
* [Option 3](#option3): Let the WPF designer create a `DataContext` instance for you, at design-time only.  At compile time, you must create and set the `DataContext`.
* [Option 4](#option4): Use a design-time static factory


Provides compile-time type safety in XAML for your `DataContext`

<a name="option1" />

## Option 1: Have your `Control` or `Window` create the `DataContext` instance itself, at both compile time and runtime.

This is the easiest option, but it only works if the type you're using as the `DataContext` has a parameterless constructor and can be constructed entirely from XAML...

Example:
```XAML
<Window x:Class="Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:demo="clr-namespace:Demo">
    <Window.DataContext>
        <demo:AppViewModel />
    </Window.DataContext>
</Window>
```

<a name="option2" />

## Option 2: Specify the type only - the WPF designer will not create the type for you.

The Expression Blend namespace (`http://schemas.microsoft.com/expression/blend/2008`), which is usually associated with the prefix `d` for `designer` is used to indicate that XAML constructions should be processed.

The `d:DesignInstance` type has a property `IsDesignTimeCreatable`.  If this is set to `False`, the WPF designer will use the type for XAML validation, but it will not be able to show you any data (since it is not design time creatable)

Example:
```XAML
<Window x:Class="Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:demo="clr-namespace:Demo"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance demo:AppViewModel, IsDesignTimeCreatable=False}"
        >
</Window>
```

(See also: [d:DesignInstance in Depth](http://jack.ukleja.com/ddesigninstance-in-depth/))


<a name="option3" />

## Option 3: Let the WPF designer create a `DataContext` instance for you, at design-time only.

At compile time, you must create and set the `DataContext`.

This is the same as Option #2 ☝, except we set the `IsDesignTimeCreatable` property to `True`.  The WPF designer will create an instance at runtime, using the parameterless constructor. If this constructor contains the necessary property initializers, your designer will show populated controls.

Example:
```XAML
<Window x:Class="Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:demo="clr-namespace:Demo"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance demo:AppViewModel, IsDesignTimeCreatable=True}"
        >
</Window>
```

(See also: [d:DesignInstance in Depth](http://jack.ukleja.com/ddesigninstance-in-depth/))

<a name="option4" />

## Option 4: Use a design-time static factory

Here, we're using a static factory class `DesignTimeViewModels` that contains design-time view models that can be used throughout the application.  If you prefer, you can use a static property on the view model class itself - the principle is the same.

Example:

```C#
namespace Demo
{
    public static class DesignTimeViewModels
    {
        public static AppViewModel AppViewModel { get; } = new ()
        {
            ApplicationName = "Demo Application",
        };
    }
}
```

```XAML
<Window x:Class="Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:demo="clr-namespace:Demo"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DataContext="{x:Static demo:DesignTimeViewModels.AppViewModel}"
        >
</Window>
```

