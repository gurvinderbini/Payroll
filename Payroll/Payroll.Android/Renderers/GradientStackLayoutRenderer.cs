﻿using System;
using Payroll.CustomControls;
using Payroll.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientStackLayout), typeof(GradientStackLayoutRenderer))]

namespace Payroll.Droid.Renderers
{
    public class GradientStackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
      

        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        protected override void DispatchDraw(
            global::Android.Graphics.Canvas canvas)
        {
            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
                this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                if (!(e.NewElement is GradientStackLayout stack)) return;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}