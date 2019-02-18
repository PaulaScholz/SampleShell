# SampleShell Sample Container UWP Application

## Windows - Developer Incubation and Learning - Paula Scholz

This is `SampleShell`, the UWP shell application used to host samples from Windows Developer Incubation and Learning.  SampleShell consists of a `MainPage`, which contains the shell, and `SamplePage`, which is a placeholder page for your own sample content.  

Currently, `SamplePage` contains four buttons that call the `MainPage.NotifyUser` method to display status, warning, and error messages to the user, in the Status area beneath the sample content. You may modify SampleShell however you like for your own particular needs.

`SampleShell` looks like this:

![Sample Shell](/SampleShell_3/docimages/SampleShell_3.png "Sample Shell")


`MainPage` has a method we will call a number of times through our globally-scoped static `MainPage.Current` reference, `NotifyUser` sends messages to the `MainPage` status area and looks like this:

```c#
        #region NotifyUser code
        /// <summary>
        /// Display a message to the user in the MainPage Status area.
        /// This method may be called from any thread.
        /// </summary>
        /// <param name="strMessage">The string message to display.</param>
        /// <param name="type">NotifyType.StatusMessage or NotifyType.ErrorMessage</param>
        public void NotifyUser(string strMessage, NotifyType type)
        {
            // If called from the UI thread, then update immediately.
            // Otherwise, schedule a task on the UI thread to perform the update.
            if (Dispatcher.HasThreadAccess)
            {
                UpdateStatus(strMessage, type);
            }
            else
            {
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => UpdateStatus(strMessage, type));
            }
        }
```

The `NotifyType` is an enumeration for the type of notification we want:

```c#
    /// <summary>
    /// The XAML will display a green background for a Status message, and a red background for an ErrorMessage,
    /// blue/violet for a warning message.  ClearMessage type clears the Status box and sets it to green.
    /// </summary>
    public enum NotifyType
    {
        StatusMessage,
        WarningMessage,
        ErrorMessage,
        ClearMessage
    };
```

You will see this code used many times throughout our samples to communicate status, warning, and error messages to the user, similar to how you see it used in SamplePage code-behind, like this:

```c#
 private void Button_Normal(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.StatusMessage", NotifyType.StatusMessage);
        }

        private void Button_Warning(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.WarningMessage", NotifyType.WarningMessage);
        }

        private void Button_Error(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.ErrorMessage", NotifyType.ErrorMessage);
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            MainPage.Current?.NotifyUser("NotifyType.ClearMessage", NotifyType.ClearMessage);
        }
```