[Home](https://github.com/binarycow/Resources)

Easier way to do data binding for `RadioButton` (or other types of `ToggleButton`) for enum values (technically, you can use any type of value... 🤷‍♂️).

Example:

```xaml
<StackPanel>
    <RadioButton IsChecked="{markupExtensions:EnumIsChecked Dock, Value={x:Static Dock.Left}, AlsoSetContent=True}" />
    <RadioButton IsChecked="{markupExtensions:EnumIsChecked Dock, Value={x:Static Dock.Right}, AlsoSetContent=True}" />
    <RadioButton Content="TOP!" 
                 IsChecked="{markupExtensions:EnumIsChecked Dock, Value={x:Static Dock.Top}}" />
    <RadioButton Content="BOTTOM!" 
                 IsChecked="{markupExtensions:EnumIsChecked Dock, Value={x:Static Dock.Bottom}}" />
    <TextBlock Text="{Binding Dock}" />
</StackPanel>
```

Note, the `AlsoSetContent` property can be used to set the content of the `ToggleButton` to `ToString()` value of the enum.  If not set to true, you'll need to set the content yourself.

[Source Code](https://github.com/binarycow/Resources/blob/master/WpfApp1/MarkupExtensions/EnumIsCheckedExtension.cs)
Also Needed: [EqualConverter](https://github.com/binarycow/Resources/blob/master/WpfApp1/Converters/EqualConverter.cs)
