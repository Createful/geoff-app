using System;
using HelloGeoff;

namespace HelloGeoff
{
	public class GeoffPresenter
	{

		Viewable view;
		Random random;
		int result;

		public GeoffPresenter(Viewable view)
		{
			this.view = view;

			Console.WriteLine("Presenter created");

			random = new Random();

			result = random.Next(0, 1);

		}

		internal void AskGeoff()
		{
			view.Reset();

			result = random.Next(0, 2);

			Console.WriteLine("Random Number is {0}", result);
			//view.ChangeImage();

			view.DoMagic();

			switch (result) {
				case 0:
					view.SelectNo();
					break;
				case 1:
					view.SelectYes();
					break;
			}
		}
	}
}

