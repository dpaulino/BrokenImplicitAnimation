using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FullScreenBrokenAnimation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetupImplicitShowAnimations(AnimatedText);
        }

        public static void SetupImplicitShowAnimations(UIElement target)
        {
            Compositor compositor = ElementCompositionPreview.GetElementVisual(target).Compositor;
            CompositionAnimationGroup animations = compositor.CreateAnimationGroup();

            ScalarKeyFrameAnimation scalarAnimation = compositor.CreateScalarKeyFrameAnimation();
            scalarAnimation.InsertKeyFrame(0.0f, 0f);
            scalarAnimation.InsertKeyFrame(1.0f, 1f);
            scalarAnimation.Duration = TimeSpan.FromSeconds(3);
            scalarAnimation.Target = nameof(Visual.Opacity);

            animations.Add(scalarAnimation);

            ElementCompositionPreview.SetImplicitShowAnimation(target, animations);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
            App.AppFrame.Navigate(typeof(FullScreenPage));
        }
    }
}
