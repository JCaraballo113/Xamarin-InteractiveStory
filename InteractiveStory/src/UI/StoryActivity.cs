
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;

namespace InteractiveStory
{
	[Activity (Label = "Story Activity")]			
	public class StoryActivity : Activity
	{
		private string name;
		private Story mStory = new Story();
		private ImageView storyImage;
		private TextView storyText;
		private Button choice1;
		private Button choice2;
		private Page mCurrentPage;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Story_Activity);
			name = Intent.GetStringExtra ("name");
			storyImage = FindViewById<ImageView> (Resource.Id.mainImage);
			storyText = FindViewById<TextView> (Resource.Id.storyText);
			choice1 = FindViewById<Button> (Resource.Id.choice1Btn);
			choice2 = FindViewById<Button> (Resource.Id.choice2Btn);

			loadPage (0);
		}

		public void loadPage(int pageId) {
			mCurrentPage = mStory.getPage (pageId);
			Drawable drawable = Resources.GetDrawable (mCurrentPage.getPageImageId ());
			storyImage.SetImageDrawable (drawable);
			string text = String.Format (mCurrentPage.getStoryText (), name);
			storyText.Text = text;

			if (mCurrentPage.isFinal()) {
				Console.WriteLine ("Nade it");
				choice1.Visibility = ViewStates.Invisible;
				choice2.Click += delegate {
					Finish ();
				};

			} else {
				choice1.Text = mCurrentPage.getChoice1 ().getText ();
				choice2.Text = mCurrentPage.getChoice2 ().getText ();

				if (!choice1.HasOnClickListeners && !choice2.HasOnClickListeners) {
					choice1.Click += delegate {
						int nextPageId = mCurrentPage.getChoice1 ().getNextPageId ();
						loadPage (nextPageId);
					};
				
					choice2.Click += delegate {
						int nextPageId = mCurrentPage.getChoice2().getNextPageId();
						loadPage(nextPageId);
					};
				}
			}
		}
	}
}

