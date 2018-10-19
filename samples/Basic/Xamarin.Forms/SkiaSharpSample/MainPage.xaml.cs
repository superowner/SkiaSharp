using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpSample
{
	public partial class MainPage : ContentPage
	{
		private SKPoint location;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
		{
			// the the canvas and properties
			var canvas = e.Surface.Canvas;

			var paint = new SKPaint
			{
				Color = SKColors.Black,
				IsAntialias = true,
				Style = SKPaintStyle.Fill,
				TextAlign = SKTextAlign.Center,
				TextSize = 24
			};

			using (new SKAutoCanvasRestore(canvas, true))
			{
				// get the screen density for scaling
				var scale = (float)(e.BackendRenderTarget.Width / skiaView.Width);

				// handle the device screen density
				canvas.Scale(scale);

				// make sure the canvas is blank
				canvas.Clear(SKColors.White);

				// draw some text
				var coord = new SKPoint((float)skiaView.Width / 2, ((float)skiaView.Height + paint.TextSize) / 2);
				canvas.DrawText("SkiaSharp", coord, paint);
			}

			canvas.DrawCircle(location, 25, paint);
		}

		private void OnTouchSurface(object sender, SKTouchEventArgs e)
		{
			location = e.Location;
			e.Handled = true;

			System.Diagnostics.Debug.WriteLine(e);

			(sender as SKGLView).InvalidateSurface();
		}
	}
}
