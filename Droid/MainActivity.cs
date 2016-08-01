using Android.App;
using Android.Widget;
using Android.Graphics;
using Android.OS;
using System;
using HelloGeoff;

namespace HelloGeoff.Droid
{
	[Activity(Label = "Hello Geoff", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, Viewable
	{

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

			// Set our view from the "main" layout resource
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
			//Animated Geoff doing magic here

			for (int i = 0; i < 10; i++)
			{
				imageView.PostDelayed(ChangeGeoffColor, i*100);
			}

			imageView.PostDelayed(ResetGeoffColor, 1100);
		}

		public void SelectYes()
		{
			yes.PostDelayed(ShowYes, 1200);
		}

		public void ShowYes() 
		{ 
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
			no.SetTextColor(highlightedTextColor);
			no.SetBackgroundColor(highlightedColor);
			imageView.SetImageResource(Resource.Drawable.right_point);
		}

		public void Reset() 
		{
			imageView.SetImageResource(Resource.Drawable.geoff);
			imageView.SetBackgroundColor(neutralColor);
			yes.SetBackgroundColor(neutralColor);
			no.SetBackgroundColor(neutralColor);
			yes.SetTextColor(neutralTextColor);
			no.SetTextColor(neutralTextColor);
		}

		public void ChangeGeoffColor() 
		{ 
			imageView.SetBackgroundColor(new Android.Graphics.Color(random.Next(256), random.Next(256), random.Next(256)));
		}

		public void ResetGeoffColor()
		{
			imageView.SetBackgroundColor(neutralColor);
		}
	}
}


