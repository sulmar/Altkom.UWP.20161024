using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;

namespace Altkom.Bicycle.UWPClient.Triggers
{
    public class ApiInformationTrigger : StateTriggerBase
    {

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(string), typeof(ApiInformationTrigger), 
                new PropertyMetadata(string.Empty, OnTypeChanged));

        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var trigger = (ApiInformationTrigger)d;

            var value = e.NewValue as string;

            var isActive = !string.IsNullOrWhiteSpace(value) && ApiInformation.IsTypePresent(value);

            trigger.SetActive(isActive);

        }

     
    }
}
