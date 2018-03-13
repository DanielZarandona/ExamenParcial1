using System;
using Foundation;
using UIKit;

namespace ExamenP1
{
    public partial class ViewController : UIViewController
    {

        NSUserDefaults userDefaults = NSUserDefaults.StandardUserDefaults;
        NSObject didChangeNotificationToken;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            View.BackgroundColor = UIColor.Clear;
            var isNightMode = userDefaults.BoolForKey("night-mode");
            Console.WriteLine(isNightMode);

            sldshido.ValueChanged += SldCalc_ValueChanged;
            sldshido.MinimumTrackTintColor = UIColor.DarkGray;
            sldshido.MaximumTrackTintColor = UIColor.DarkGray;

            btnCalc.TouchUpInside += BtnCalc_TouchUpInside;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            didChangeNotificationToken = NSNotificationCenter.DefaultCenter.AddObserver(NSUserDefaults.DidChangeNotification, SettingsChanged);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NSNotificationCenter.DefaultCenter.RemoveObserver(didChangeNotificationToken);
            didChangeNotificationToken.Dispose();
            didChangeNotificationToken = null;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void SettingsChanged(NSNotification obj){
            var isNightMode = userDefaults.BoolForKey("night-mode");
            if (isNightMode)
            {
                View.BackgroundColor = UIColor.DarkGray;
                txtN1.BackgroundColor = UIColor.White;
                txtN2.BackgroundColor = UIColor.White;
                lblN1.TextColor = UIColor.White;
                lblN2.TextColor = UIColor.White;
                lblSum.TextColor = UIColor.White;
                lblResultado.TextColor = UIColor.White;
                lblResta.TextColor = UIColor.White;
                lblMult.TextColor = UIColor.White;
                lblDiv.TextColor = UIColor.White;
                lblAmount.TextColor = UIColor.White;
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
            }
            else
            {
                View.BackgroundColor = UIColor.White;
                txtN1.BackgroundColor = UIColor.Black;
                txtN2.BackgroundColor = UIColor.Black;
                lblN1.TextColor = UIColor.Black;
                lblN2.TextColor = UIColor.Black;
                lblSum.TextColor = UIColor.Black;
                lblResultado.TextColor = UIColor.Black;
                lblResta.TextColor = UIColor.Black;
                lblMult.TextColor = UIColor.Black;
                lblDiv.TextColor = UIColor.Black;
                lblAmount.TextColor = UIColor.Black;
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.Default;
            }
            Console.WriteLine(isNightMode);
        }

        void SldCalc_ValueChanged(object sender, EventArgs e)
        {
            float val = (float)Math.Round(sldshido.Value);
            sldshido.SetValue(val, true);
        }

        void BtnCalc_TouchUpInside(object sender, EventArgs e)
        {
            
            if ((int)sldshido.Value == 0)
            {

                if (double.TryParse(txtNum1.Text, out double resultado1) && double.TryParse(txtNum2.Text, out double resultado2))
                {
                    Operaciones o = new Operaciones();
                    lblResultado.Text = o.Suma(double.Parse(txtNum1.Text), double.Parse(txtNum2.Text)).ToString();
                }
                else lblResultado.Text = "Datos invalidos";

            }
            else if ((int)sldshido.Value == 1)
            {
                if (double.TryParse(txtNum1.Text, out double resultado1) && double.TryParse(txtNum2.Text, out double resultado2))
                {
                    Operaciones o = new Operaciones();
                    lblResultado.Text = o.Resta(double.Parse(txtNum1.Text), double.Parse(txtNum2.Text)).ToString();
                }
                else lblResultado.Text = "Datos invalidos";

            }
            else if ((int)sldshido.Value == 2)
            {
                if (double.TryParse(txtNum1.Text, out double resultado1) && double.TryParse(txtNum2.Text, out double resultado2))
                {
                    Operaciones o = new Operaciones();
                    lblResultado.Text = o.Multi(double.Parse(txtNum1.Text), double.Parse(txtNum2.Text)).ToString();
                }
                else lblResultado.Text = "Datos invalidos";

            }
            else if ((int)sldshido.Value == 3)
            {
                if (double.TryParse(txtNum1.Text, out double resultado1) && double.TryParse(txtNum2.Text, out double resultado2))
                {
                    Operaciones o = new Operaciones();
                    lblResultado.Text = o.Divi(double.Parse(txtNum1.Text), double.Parse(txtNum2.Text)).ToString();
                }
                else lblResultado.Text = "Datos invalidos";

            }
        }
    }
}
