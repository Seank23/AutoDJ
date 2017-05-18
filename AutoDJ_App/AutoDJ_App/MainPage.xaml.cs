using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoDJ_App
{
	public partial class MainPage : ContentPage
	{
        private RequestProcessor processor;

		public MainPage()
		{
			InitializeComponent();

            processor = new RequestProcessor(this);
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            processor.RequestSong();
        }

        public void ResetRequest()
        {
            processor.ClearProcessData();

            txtName.Text = "";
            //SetRequestStatus("Ready!");
            //pgbStatusBar.Style = ProgressBarStyle.Blocks;
            GC.Collect();
        }

        public string GetSearchInput() { return txtName.Text; }

        public void SetSongName(string name) { lblSong.Text = name; }
    }
}
