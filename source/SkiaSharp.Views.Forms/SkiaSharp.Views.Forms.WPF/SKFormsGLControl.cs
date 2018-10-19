using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using OpenTK.Graphics;
using SkiaSharp.Views.Desktop;

namespace SkiaSharp.Views.Forms
{
	public class SKFormsGLControl : WindowsFormsHost
	{
		public SKFormsGLControl()
		{
			Initialize(new SKGLControl(new GraphicsMode(new ColorFormat(8, 8, 8, 8), 24, 8)));
		}

		public SKFormsGLControl(GraphicsMode mode)
		{
			Initialize(new SKGLControl(mode));
		}

		public SKFormsGLControl(GraphicsMode mode, int major, int minor, GraphicsContextFlags flags)
		{
			Initialize(new SKGLControl(mode, major, minor, flags));
		}

		public void Initialize(SKGLControl control)
		{
			GLControl = control;
			GLControl.MakeCurrent();
			GLControl.Dock = DockStyle.Fill;

			Child = GLControl;
		}

		public SKGLControl GLControl { get; private set; }

		public GRContext GRContext => GLControl.GRContext;

		public SKSize CanvasSize => GLControl.CanvasSize;

		public event EventHandler<Desktop.SKPaintGLSurfaceEventArgs> PaintSurface
		{
			add => GLControl.PaintSurface += value;
			remove => GLControl.PaintSurface -= value;
		}

		public void Invalidate()
		{
			GLControl.Invalidate();
		}
	}
}
