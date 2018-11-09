using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText InputBillAmountText;
        Button CalculateTipButton;
        TextView OutputTipText;
        TextView OutputTotalText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Main" layout resource (Resources/Main.axml)
            SetContentView(Resource.Layout.Main);

            // Retrieve references to resources
            InputBillAmountText = FindViewById<EditText>(Resource.Id.inputBillAmountText);
            CalculateTipButton = FindViewById<Button>(Resource.Id.calculateTipButton);
            OutputTipText = FindViewById<TextView>(Resource.Id.outputTipText);
            OutputTotalText = FindViewById<TextView>(Resource.Id.outputTotalText);

            // Subscribe to click events
            CalculateTipButton.Click += OnCalculateClick;
        }

        void OnCalculateClick(object sender, EventArgs e)
        {
            OutputTipText.Text = string.Empty;
            OutputTotalText.Text = string.Empty;

            double billAmount;
            if (!double.TryParse(InputBillAmountText.Text, out billAmount))
                return;

            double tipAmount = billAmount * 0.15;
            double totalAmount = billAmount + tipAmount;

            // Assign values to appropriate text views
            OutputTipText.Text = tipAmount.ToString("c2");
            OutputTotalText.Text = totalAmount.ToString("c2");
        }
    }
}