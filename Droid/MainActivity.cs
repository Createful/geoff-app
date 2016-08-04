using Android.App;
using Android.Widget;
using Android.Graphics;
using Android.OS;
using System;
using HelloGeoff;

namespace HelloGeoff.Droid
{
	[Activity(Label = "Hello Geoff", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, GeoffViewable
	{
		static int fullColorRange = 256;

		ImageView imageView;

		GeoffPresenter presenter;

		TextView yes;

		TextView no;

		Random random;

		Color highlightedColor = new Color(255, 200, 0);

		Color neutralColor = new Color(0, 0, 100, 0);

		Color highlightedTextColor = new Color(0,0,0);

		Color neutralTextColor = new Color(230,230,230);

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);


			SetContentView(Resource.Layout.Main);

			presenter = new GeoffPresenter(this);

			random = new Random();

			Button button = FindViewById<Button>(Resource.Id.myButton);

			imageView = FindViewById<ImageView>(Resource.Id.geoff_image_view);
			yes = FindViewById<TextView>(Resource.Id.yes);
			no = FindViewById<TextView>(Resource.Id.no);


			button.Click += delegate 
			{ 
				presenter.AskGeoff();
			};

			Reset();
		}

		public void DoMagic()
		{
			//TODO Animated Geoff doing magic here

			for (int i = 0; i < 10; i++)
			{
				imageView.PostDelayed(ChangeGeoffColor, i*100);
			}


			imageView.PostDelayed(presenter.OnMagicFinished, 1200);

		}

		public void SelectYes()
		{
			yes.PostDelayed(ShowYes, 1200);
		}

		public void ShowYes() 
		{
			ResetGeoffColor();
			yes.SetTextColor(highlightedTextColor);
			yes.SetBackgroundColor(highlightedColor);
			imageView.SetImageResource(Resource.Drawable.left_point);
		}

		public void SelectNo()
		{
			no.PostDelayed(ShowNo, 1200);
		}

		public void ShowNo() 
		{
			ResetGeoffColor();
			no.SetTextColor(highlightedTextColor);
			no.SetBackgroundColor(highlightedColor);
			imageView.SetImageResource(Resource.Drawable.right_point);
		}

		public void Reset() 
		{
			imageView.SetImageResource(Resource.Drawable.resting);
			imageView.SetBackgroundColor(neutralColor);
			yes.SetBackgroundColor(neutralColor);
			no.SetBackgroundColor(neutralColor);
			yes.SetTextColor(neutralTextColor);
			no.SetTextColor(neutralTextColor);
		}

		public void ChangeGeoffColor() 
		{ 
			imageView.SetBackgroundColor(new Android.Graphics.Color(
				random.Next(fullColorRange), 
				random.Next(fullColorRange), 
				random.Next(fullColorRange)
			));

		}

		public void ResetGeoffColor()
		{
			imageView.SetBackgroundColor(neutralColor);
		}
	}
}


