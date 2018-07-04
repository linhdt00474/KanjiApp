using System;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using KanjiApp;
using KanjiApp.CustomControls;
using KanjiApp.Droid;
using Android.Graphics;
using Android.Runtime;

[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]

namespace KanjiApp.Droid
{
	public class RoundedLabelRenderer : LabelRenderer
	{
		public RoundedLabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
			{
				return;
			}

			if (Control != null)
			{
				//Control.Invalidate();
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == RoundedLabel.TextProperty.PropertyName)
			{
				Control.Invalidate();
				return;
			}
			if (e.PropertyName == RoundedLabel.BackgroundColorProperty.PropertyName)
			{
				Control.Invalidate();
				UpdateLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.BorderColorProperty.PropertyName)
			{
				Control.Invalidate();
				UpdateLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.BorderWidthProperty.PropertyName)
			{
				Control.Invalidate();
				return;
			}
			if (e.PropertyName == RoundedLabel.CornerRadiusProperty.PropertyName)
			{
				Control.Invalidate();
				return;
			}
			if (e.PropertyName == RoundedLabel.HiddenValueProperty.PropertyName)
			{
				Control.Invalidate();
				return;
			}
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			UpdateLayout();
		}

		private void UpdateLayout()
		{
			var label = Element as RoundedLabel;

			var background = new Android.Graphics.Drawables.GradientDrawable();
			background.SetCornerRadius((int)label.CornerRadius);
			background.SetStroke((int)label.BorderWidth, label.BorderColor.ToAndroid());
			background.SetColor(label.BackgroundColor.ToAndroid());
			SetBackgroundColor(Android.Graphics.Color.Transparent);
			SetBackgroundDrawable(background);
		}
	}
}