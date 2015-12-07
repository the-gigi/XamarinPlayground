using Android.App;
using Android.Widget;
using Android.OS;

namespace XamarinPlayground.Droid
{
    [Activity (Label = "XamarinPlayground", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button> (Resource.Id.myButton);
			
            button.Click += async delegate
            {                
                button.Text = "Fetching...";
                var featureFetcher = new FeatureFetcher();
                await featureFetcher.Fetch();

                var titleView = FindViewById<TextView> (Resource.Id.textViewTitle);
                var urlView = FindViewById<TextView> (Resource.Id.textViewUrl);

                titleView.Text = featureFetcher.Title;
                urlView.Text = featureFetcher.Url;

                button.Text = Resources.GetString(Resource.String.fetch);
            };
        }
    }
}


