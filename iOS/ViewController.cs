using System;

using UIKit;
using ImageIO;

namespace HelloGeoff.iOS
{
	public partial class ViewController : UIViewController, Viewable
	{
		
		GeoffPresenter presenter;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Code to start the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
#endif

			presenter = new GeoffPresenter(this);

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				Console.WriteLine("You clicked the button");
				presenter.AskGeoff();
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public void DoMagic()
		{
			Console.WriteLine("-> ChangeImage()");
			//var fileImage = (UIImage.FromFile("Resources.geoff.png"));
			//GeoffImage.Image = fileImage;
		}

		public void SelectYes()
		{
			throw new NotImplementedException();
		}

		public void SelectNo()
		{
			throw new NotImplementedException();
		}

		public void Reset()
		{
			throw new NotImplementedException();
		}
	}
}
