using StockMarketComponent;

namespace FinancialTradingPlatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFastLocalOperation_Click(object sender, EventArgs e)
        {
            AddListItem($"Fast Local Operation Completed - ThreadId - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async void btnCPUBoundOperation_Click(object sender, EventArgs e)
        {
            StockMarketDataAnalysis stockMarketDataAnalysis = new StockMarketDataAnalysis("data");

            List<Task<string>> tasks = new List<Task<string>>();

            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateFastMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateSlowMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateStockastics()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateBollingerbands()));

            //Task.WaitAll(tasks.ToArray());
            await Task.WhenAll(tasks.ToArray());

            AddListItem(tasks[0].Result);
            AddListItem(tasks[1].Result);
            AddListItem(tasks[2].Result);
            AddListItem(tasks[3].Result);

            DisplayIndicatorsOnChart(tasks[0].Result, tasks[1].Result, tasks[2].Result, tasks[3].Result);

        }

        private void DisplayIndicatorsOnChart(string data1, string data2, string data3, string data4)
        {
            //Code goes here to display indicator data on chart
        }
    }
}