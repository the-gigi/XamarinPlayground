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
                var title = string.Format ("{0} clicks!", count++);

                // Button.SetTitle (title, UIControlState.Normal);

                Button.SetTitle ("Fetching...", UIControlState.Normal);

                var featureFetcher = new FeatureFetcher();
                await featureFetcher.Fetch();

                var titleView = FindViewById<TextView> (Resource.Id.textViewTitle);
                var urlView = FindViewById<TextView> (Resource.Id.textViewUrl);

                TitleField.SetText(featureFetcher.Title);
                UrlField.SetText(featureFetcher.Url);

                Button.SetTitle("Fetch #1 HackerNews Article");
            };
        }

        public override void DidReceiveMemoryWarning ()
        {		
            base.DidReceiveMemoryWarning ();		
            // Release any cached data, images, etc that aren't in use.		
        }

        partial void Button_TouchUpInside (UIButton sender)
        {
            throw new NotImplementedException ();
        }
    }
}
