using System;

namespace InteractiveStory
{
	public class Page
	{
		private int mPageImageId;
		private string mStoryText;
		private Choice mChoice1;
		private Choice mChoice2;
		private bool mIsFinal = false;

		public Page (int imageId, string storyText, Choice choice1, Choice choice2)
		{
			mPageImageId = imageId;
			mStoryText = storyText;
			mChoice1 = choice1;
			mChoice2 = choice2;
		}

		public Page(int imageID, string storyText){
			mPageImageId = imageID;
			mStoryText = storyText;
			mChoice1 = null;
			mChoice2 = null;
			mIsFinal = true;
		}

		public int getPageImageId() {
			return this.mPageImageId;
		}

		public void setPageImageId(int Id) {
			this.mPageImageId = Id;
		}

		public string getStoryText(){
			return this.mStoryText;
		}

		public void setStoryText(string text){
			this.mStoryText = text;
		}

		public Choice getChoice1() {
			return this.mChoice1;
		}

		public Choice getChoice2() {
			return this.mChoice2;
		}

		public void setChoice1(Choice choice) {
			this.mChoice1 = choice;
		}

		public void setChoice2(Choice choice) {
			this.mChoice2 = choice;
		}

		public bool isFinal(){
			return mIsFinal;
		}
	}
}

