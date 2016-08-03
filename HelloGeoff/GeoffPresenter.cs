using System;
using System.Threading.Tasks;

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
		}

		internal void AskGeoff()
		{
			view.Reset();

			result = random.Next(0, 2);

			Console.WriteLine("Random Number is {0}", result);

			view.DoMagic();

			switch (result) {
				case 0:
					view.SelectNo();
					break;
				case 1:
					view.SelectYes();
					break;
			}

			WaitAndReset();
		}

		async void WaitAndReset()
		{
			await Task.Delay(10*1000);
			view.Reset();
		}
	}
}

