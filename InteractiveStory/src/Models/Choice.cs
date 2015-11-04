using System;

namespace InteractiveStory
{
	public class Choice
	{
		private int mNextPageId;
		private string mText;

		public Choice (string text, int nextPage)
		{
			mText = text;
			mNextPageId = nextPage;
		}

		public int getNextPageId() {
			return mNextPageId;
		}

		public void setNextPageId(int id) {
			this.mNextPageId = id;
		}

		public string getText() {
			return mText;
		}

		public void setText(string text) {
			this.mText = text;
		}
	}
}

