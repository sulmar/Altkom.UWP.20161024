using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Windows.Input;

namespace Altkom.Bicycle.UWPClient.Behaviors
{
    public class EventToCommandBehavior : DependencyObject, IBehavior
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommandBehavior), new PropertyMetadata(0));



        public DependencyObject AssociatedObject
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Attach(DependencyObject associatedObject)
        {
            var button = (Button)associatedObject;

             // button.Click += Button_Click;

            button.PointerMoved += Button_PointerMoved;
        }

        private void Button_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Command.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            Command.Execute(null);
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }
    }
}
