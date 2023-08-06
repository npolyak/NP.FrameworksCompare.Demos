using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Reflection;

namespace NP.Demo.StaticMarkupExtensionSample.Views
{
    public static class CallMethodBehavior
    {
        #region MethodName Attached Avalonia Property
        public static string GetMethodName(Control obj)
        {
            return obj.GetValue(MethodNameProperty);
        }

        public static void SetMethodName(Control obj, string value)
        {
            obj.SetValue(MethodNameProperty, value);
        }

        public static readonly AttachedProperty<string> MethodNameProperty =
            AvaloniaProperty.RegisterAttached<Control, Control, string>
            (
                "MethodName"
            );
        #endregion MethodName Attached Avalonia Property


        static CallMethodBehavior()
        {
            TheRoutedEventProperty.Changed.Subscribe(OnTheRoutedEventChanged);
        }

        private static void OnTheRoutedEventChanged(AvaloniaPropertyChangedEventArgs<RoutedEvent> args)
        {
            Control control = (Control)args.Sender;

            if (args.OldValue.Value is RoutedEvent oldRoutedEvent)
            {
                control.RemoveHandler(oldRoutedEvent, HandleRoutedEvent);
            }

            if (args.NewValue.Value is RoutedEvent newRoutedEvent)
            {
                control.AddHandler(newRoutedEvent, HandleRoutedEvent, RoutingStrategies.Direct | RoutingStrategies.Bubble);
            }
        }

        private static void HandleRoutedEvent(object sender, RoutedEventArgs e) 
        { 
            Control control = (Control)sender;

            string methodName = GetMethodName(control);
            if (methodName == null)
                return;

            object? targetObject = GetTargetObject(control) ?? control.DataContext;

            if (targetObject == null) 
                return;

            MethodInfo? methodInfo = targetObject.GetType().GetMethod(methodName);

            if (methodInfo == null)
                return;

            methodInfo.Invoke(targetObject, null);
        }

        #region TheRoutedEvent Attached Avalonia Property
        public static RoutedEvent GetTheRoutedEvent(Control obj)
        {
            return obj.GetValue(TheRoutedEventProperty);
        }

        public static void SetTheRoutedEvent(Control obj, RoutedEvent value)
        {
            obj.SetValue(TheRoutedEventProperty, value);
        }

        public static readonly AttachedProperty<RoutedEvent> TheRoutedEventProperty =
            AvaloniaProperty.RegisterAttached<Control, Control, RoutedEvent>
            (
                "TheRoutedEvent"
            );
        #endregion TheRoutedEvent Attached Avalonia Property


        #region TargetObject Attached Avalonia Property
        public static object GetTargetObject(Control obj)
        {
            return obj.GetValue(TargetObjectProperty);
        }

        public static void SetTargetObject(Control obj, object value)
        {
            obj.SetValue(TargetObjectProperty, value);
        }

        public static readonly AttachedProperty<object> TargetObjectProperty =
            AvaloniaProperty.RegisterAttached<Control, Control, object>
            (
                "TargetObject"
            );
        #endregion TargetObject Attached Avalonia Property
    }
}
