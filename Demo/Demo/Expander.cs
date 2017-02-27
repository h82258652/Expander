using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace Demo
{
    [TemplateVisualState(GroupName = ExpandDirectionStateGroupName, Name = ExpandDownStateName)]
    [TemplateVisualState(GroupName = ExpandDirectionStateGroupName, Name = ExpandUpStateName)]
    [TemplateVisualState(GroupName = ExpandDirectionStateGroupName, Name = ExpandLeftStateName)]
    [TemplateVisualState(GroupName = ExpandDirectionStateGroupName, Name = ExpandRightStateName)]
    [TemplateVisualState(GroupName = ExpansionStateGroupName, Name = CollapsedStateName)]
    [TemplateVisualState(GroupName = ExpansionStateGroupName, Name = ExpandedStateName)]
    public class Expander : ContentControl
    {
        public static readonly DependencyProperty ExpandDirectionProperty = DependencyProperty.Register(nameof(ExpandDirection), typeof(ExpandDirection), typeof(Expander), new PropertyMetadata(default(ExpandDirection), OnExpandDirectionChanged));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(Expander), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(Expander), new PropertyMetadata(default(bool), OnIsExpandedChanged));

        private const string CollapsedStateName = "Collapsed";

        private const string ExpandDirectionStateGroupName = "ExpandDirectionStates";

        private const string ExpandDownStateName = "ExpandDown";

        private const string ExpandedStateName = "Expanded";

        private const string ExpandLeftStateName = "ExpandLeft";

        private const string ExpandRightStateName = "ExpandRight";

        private const string ExpandUpStateName = "ExpandUp";

        private const string ExpansionStateGroupName = "ExpansionStates";

        public Expander()
        {
            DefaultStyleKey = typeof(Expander);
        }

        public event EventHandler Collapsed;

        public event EventHandler Expanded;

        public ExpandDirection ExpandDirection
        {
            get
            {
                return (ExpandDirection)GetValue(ExpandDirectionProperty);
            }
            set
            {
                SetValue(ExpandDirectionProperty, value);
            }
        }

        public object Header
        {
            get
            {
                return GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }

        public bool IsExpanded
        {
            get
            {
                return (bool)GetValue(IsExpandedProperty);
            }
            set
            {
                SetValue(IsExpandedProperty, value);
            }
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return base.OnCreateAutomationPeer();

            // TODO
        }

        private static void OnExpandDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (Expander)d;
            var value = (ExpandDirection)e.NewValue;

            switch (value)
            {
                case ExpandDirection.Down:
                    VisualStateManager.GoToState(obj, ExpandDownStateName, true);
                    break;

                case ExpandDirection.Up:
                    VisualStateManager.GoToState(obj, ExpandUpStateName, true);
                    break;

                case ExpandDirection.Left:
                    VisualStateManager.GoToState(obj, ExpandLeftStateName, true);
                    break;

                case ExpandDirection.Right:
                    VisualStateManager.GoToState(obj, ExpandRightStateName, true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(ExpandDirection));
            }
        }

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}