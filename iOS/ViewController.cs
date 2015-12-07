using System;
		
using UIKit;

namespace XamarinPlayground.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController (IntPtr handle) : base (handle)
        {		
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += async delegate
            {                
                Button.SetTitle ("Fetching...", UIControlState.Normal);

                var featureFetcher = new FeatureFetcher();
                await featureFetcher.Fetch();

                TitleField.Text = featureFetcher.Title;
                UrlField.Text = featureFetcher.Url;

                Button.SetTitle("Fetch #1 HackerNews Article", UIControlState.Normal);
            };
        }
    }
}
