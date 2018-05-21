using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;

namespace helloWorld
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        /*
         * Android Activity Lifecycle

            When a user navigates through an Android App, a series of events occurs. For example, when a user launches an app, e.g., the Facebook App, it starts and becomes visible on the foreground to the user, onCreate() → onStart() → onResume().

            If another activity starts, e.g., a phone call comes in, then the Facebook app will go to the background and the call comes to the foreground. We now have two processes running.

            onPause()  --- > onStop()
            When the phone call ends, the Facebook app returns to the foreground. Three methods are called.

            onRestart() --- > onStart() --- > onResume()

            There are 7 lifecycle processes in an Android activity. They include −

            onCreate − It is called when the activity is first created.

            onStart − It is called when the activity starts and becomes visible to the user.

            onResume − It is called when the activity starts interacting with the user. User input takes place at this stage.

            onPause − It is called when the activity runs in the background but has not yet been killed.

            onStop − It is called when the activity is no longer visible to the user.

            onRestart − It is called after the activity has stopped, before starting again. It is normally called when a user goes back to a previous activity that had been stopped.

            onDestroy − This is the final call before the activity is removed from the memory.

        */

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = "Hello world I am your first App"; };

            Button secondButton = FindViewById<Button>(Resource.Id.MySecondButton);
            secondButton.Click += delegate { secondButton.Text = "You clicked me"; };

            CheckBox checkMe = FindViewById<CheckBox>(Resource.Id.checkBox1);
            checkMe.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
                CheckBox check = (CheckBox)sender;
                check.Text = check.Checked ? "Checkbox has been checked": "Checkbox has not been checked";
            };

            ProgressBar pb = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            pb.Progress = 35;


            RadioButton radio_Ferrari = FindViewById<RadioButton>(Resource.Id.radioFerrari);
            RadioButton radio_Mercedes = FindViewById<RadioButton>(Resource.Id.radioMercedes);
            RadioButton radio_Lambo = FindViewById<RadioButton>(Resource.Id.radioLamborghini);
            RadioButton radio_Audi = FindViewById<RadioButton>(Resource.Id.radioAudi);
            radio_Ferrari.Click += onClickRadioButton;
            radio_Mercedes.Click += onClickRadioButton;
            radio_Lambo.Click += onClickRadioButton;
            radio_Audi.Click += onClickRadioButton;


            ToggleButton togglebutton = FindViewById<ToggleButton>(Resource.Id.togglebutton);
            togglebutton.Click += (o, e) => {
                Toast.MakeText(this, togglebutton.Checked ? "Torch is ON" : "Torch is OFF", ToastLength.Short).Show();
            };


            var autoComplete1 = FindViewById<AutoCompleteTextView>(Resource.Id.autoComplete1);
            var btn_Submit = FindViewById<Button>(Resource.Id.btn_Submit);
            var names = new string[] { "John", "Peter", "Jane", "Britney" };
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, names);
            autoComplete1.Adapter = adapter;
            btn_Submit.Click += ClickedBtnSubmit;
        }

        private void onClickRadioButton(object sender, EventArgs e)
        {
            RadioButton cars = (RadioButton)sender;
            Toast.MakeText(this, cars.Text, ToastLength.Short).Show();
        }

        protected void ClickedBtnSubmit(object sender, System.EventArgs e)
        {
            var autoComplete1 = FindViewById<AutoCompleteTextView>(Resource.Id.autoComplete1);
            if (autoComplete1.Text != "")
            {
                Toast.MakeText(this, "The Name Entered ="
                   + autoComplete1.Text, ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Enter a Name!", ToastLength.Short).Show();
            }
        }

    }
}

