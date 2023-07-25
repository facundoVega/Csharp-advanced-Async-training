namespace CancelDownloadAsyncOperations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDownloadContent_Click(object sender, EventArgs e)
        {
            try
            {
                await SumPageSizesAsync();
            }
            catch (TaskCanceledException)
            {
                AddListItem("Download opearations Cancelled");
            }
        }

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            s_cts.Cancel();
        }
    }
}