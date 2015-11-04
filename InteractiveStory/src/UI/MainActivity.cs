using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace InteractiveStory
{
	[Activity (Label = "Interactive Story", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		EditText nameText;
		Button startButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			nameText = FindViewById<EditText> (Resource.Id.nameText);
			startButton = FindViewById<Button> (Resource.Id.startButton);

			startButton.Click += delegate(object sender, EventArgs e) {
				if(!String.IsNullOrWhiteSpace(nameText.Text)){
					startStory(nameText.Text);
				}
				else {
					Toast.MakeText(this, "Enter your name please!", ToastLength.Long).Show();
				}
			};
		}
			
		protected override void OnResume() {
			base.OnResume();
			nameText.Text = "";
		}

		private void startStory(string name){
			var intent = new Intent (this, typeof(StoryActivity));
			intent.PutExtra ("name", name);
			StartActivity (intent);
		}
	}
}


