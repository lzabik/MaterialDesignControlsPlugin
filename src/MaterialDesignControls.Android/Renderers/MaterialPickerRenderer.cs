﻿using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Android.Utils;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(Plugin.MaterialDesignControls.Android.MaterialPickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialPickerRenderer : PickerRenderer
    {
        public static void Init() { }

        public MaterialPickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(4, 0, 0, 0);

                if (this.Element is CustomPicker customPicker)
                {
                    this.Control.Gravity = TextAlignmentHelper.ConvertToGravityFlags(customPicker.HorizontalTextAlignment);

                    if (customPicker.SelectedItem == null && !string.IsNullOrEmpty(customPicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = customPicker.Placeholder;
                        this.Control.SetHintTextColor(customPicker.PlaceholderColor.ToAndroid());
                    }
                }
            }
        }
    }
}
