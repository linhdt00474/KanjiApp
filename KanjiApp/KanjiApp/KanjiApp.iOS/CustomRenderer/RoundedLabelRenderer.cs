using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using KanjiApp.CustomControls;
using KanjiApp.iOS;
[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]

namespace KanjiApp.iOS
{
	public class RoundedLabelRenderer : LabelRenderer
	{
		public RoundedLabelRenderer()
		{
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == RoundedLabel.BackgroundColorProperty.PropertyName)
			{
				SetNeedsLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.BorderColorProperty.PropertyName)
			{
				SetNeedsLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.BorderWidthProperty.PropertyName)
			{
				SetNeedsLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.CornerRadiusProperty.PropertyName)
			{
				SetNeedsLayout();
				return;
			}
			if (e.PropertyName == RoundedLabel.HiddenValueProperty.PropertyName)
			{
				SetNeedsLayout();
				return;
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var label = Element as RoundedLabel;

			Layer.BorderWidth = label.BorderWidth;
			Layer.CornerRadius = label.CornerRadius;
			Layer.BackgroundColor = label.BackgroundColor.ToCGColor();
			Layer.BorderColor = label.BorderColor.ToCGColor();
		}
	}
}