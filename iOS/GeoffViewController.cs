using System;
using UIKit;
using CoreGraphics;
using System.Threading.Tasks;

namespace HelloGeoff.iOS
{
	public class GeoffViewController : UIViewController, GeoffViewable
	{

		GeoffPresenter presenter;
		Random random = new Random();

		UIImageView geoffImageView;
		UIButton button;
		UILabel yes;
		UILabel no;

		UIColor labelHighlight = UIColor.FromRGB(230, 230, 100);
		UIColor labelNeutralColor = UIColor.FromRGB(80, 80, 120);
		UIColor labelTextHighlight = UIColor.FromRGB(0, 0, 0);
		UIColor labelTextNeutralColor = UIColor.FromRGB(230, 230, 230);

		UIImage geoffImage = UIImage.FromBundle("Images/resting");
		UIImage pointLeft = UIImage.FromBundle("Images/left_point");
		UIImage pointRight = UIImage.FromBundle("Images/right_point");

		public override void ViewDidLoad()
		{
			presenter = new GeoffPresenter(this);

			base.ViewDidLoad();
			View.BackgroundColor = UIColor.Black;

			yes = new UILabel() 
			{
				Frame = new CGRect(20, 20, 60, 40),
				BackgroundColor = UIColor.DarkGray,
				Text = "Yes",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};

			no = new UILabel()
			{
				Frame = new CGRect(View.Bounds.Width-80,20,60,40),
				BackgroundColor = UIColor.DarkGray,
				Text = "No",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center
			};

			geoffImageView = new UIImageView()
			{
				Frame = new CGRect(20, 20, View.Bounds.Width-40, 400),
				Image = geoffImage,
				ContentMode = UIViewContentMode.ScaleAspectFit
			};

			button = new UIButton(UIButtonType.Custom)
			{
				Frame = new CGRect(20, View.Bounds.Height-80, View.Bounds.Width - 40, 40),
				BackgroundColor = UIColor.FromRGB(0, 0.5f, 0)             
			};

			button.SetTitle("Ask Geoff", UIControlState.Normal);

			View.AddSubview(geoffImageView);
			View.AddSubviews(yes,no);
			View.AddSubview(button);

			button.TouchUpInside += OnButtonClicked;

			Reset();
		}

		void OnButtonClicked(object sender, EventArgs e) {
			
			Console.WriteLine("You clicked the button");

			presenter.AskGeoff();
		}
	
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing) {
				geoffImage.Dispose();
				geoffImage = null;
			}
		}

		public void DoMagic()
		{
			Magic();
		}

		async void Magic() {
			
			for (int i = 0; i < 10; i++)
			{
				await Task.Delay(100);
				geoffImageView.BackgroundColor = UIColor.FromRGB(random.Next(0,256),random.Next(0, 256),random.Next(0, 256));
			}
		}

		async void Highlight(UILabel label, UIImage point) {
			await Task.Delay(1300);
			label.BackgroundColor = labelHighlight;
			label.TextColor = labelTextHighlight;
			geoffImageView.BackgroundColor = UIColor.Black;
			geoffImageView.Image = point;
		}

		public void SelectYes()
		{
			Highlight(yes, pointLeft);
		}

		public void SelectNo()
		{
			Highlight(no, pointRight);
		}

		public void Reset()
		{
			geoffImageView.Image = geoffImage;
			geoffImageView.BackgroundColor = UIColor.Black;

			yes.BackgroundColor = labelNeutralColor;
			yes.TextColor = labelTextNeutralColor;
			no.BackgroundColor = labelNeutralColor;
			no.TextColor = labelTextNeutralColor;
		}
	}
}

