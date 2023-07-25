using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CancelDownloadAsyncOperations
{
    partial class Form1
    {

        readonly CancellationTokenSource s_cts = new CancellationTokenSource();

        readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        readonly IEnumerable<string> s_urlList = new string[]
        {
            "https://learn.microsoft.com",
            "https://learn.microsoft.com/aspnet/core",
            "https://learn.microsoft.com/azure",
            "https://learn.microsoft.com/azure/devops",
            "https://learn.microsoft.com/dotnet",
            "https://learn.microsoft.com/dynamics365",
            "https://learn.microsoft.com/education",
            "https://learn.microsoft.com/enterprise-mobility-security",
            "https://learn.microsoft.com/gaming",
            "https://learn.microsoft.com/graph",
            "https://learn.microsoft.com/microsoft-365",
            "https://learn.microsoft.com/office",
            "https://learn.microsoft.com/powershell",
            "https://learn.microsoft.com/sql",
            "https://learn.microsoft.com/surface",
            "https://learn.microsoft.com/system-center",
            "https://learn.microsoft.com/visualstudio",
            "https://learn.microsoft.com/windows",
            "https://learn.microsoft.com/xamarin"
        };

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.btnDownloadContent = new System.Windows.Forms.Button();
            this.lvwOutput = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.Location = new System.Drawing.Point(47, 33);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(202, 64);
            this.btnCancelDownload.TabIndex = 0;
            this.btnCancelDownload.Text = "Cancel Download";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // btnDownloadContent
            // 
            this.btnDownloadContent.Location = new System.Drawing.Point(47, 131);
            this.btnDownloadContent.Name = "btnDownloadContent";
            this.btnDownloadContent.Size = new System.Drawing.Size(202, 55);
            this.btnDownloadContent.TabIndex = 1;
            this.btnDownloadContent.Text = "Download Content";
            this.btnDownloadContent.UseVisualStyleBackColor = true;
            this.btnDownloadContent.Click += new System.EventHandler(this.btnDownloadContent_Click);
            // 
            // lvwOutput
            // 
            this.lvwOutput.Location = new System.Drawing.Point(338, 49);
            this.lvwOutput.Name = "lvwOutput";
            this.lvwOutput.Size = new System.Drawing.Size(430, 352);
            this.lvwOutput.TabIndex = 2;
            this.lvwOutput.UseCompatibleStateImageBehavior = false;
            this.lvwOutput.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwOutput);
            this.Controls.Add(this.btnDownloadContent);
            this.Controls.Add(this.btnCancelDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCancelDownload;
        private Button btnDownloadContent;
        private ListView lvwOutput;

        private void AddListItem(string item)
        {
            ListViewItem listViewItem = new ListViewItem(item);
            listViewItem.Text = item;
            lvwOutput.Items.Add(listViewItem);
        }

        private async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (string url in s_urlList)
            {
                int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
                total += contentLength;
            }

            stopwatch.Stop();

            AddListItem($"Total bytes returned:  {total:#,#}");
            Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
        }

        private async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync(token);
            AddListItem($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }

    }
}