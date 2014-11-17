﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestCapiNet.UI
{
    public partial class LogBox : UserControl
    {
        public LogBox()
        {
            InitializeComponent();
        }

        public void LogException(Exception exception)
        {
            if (exception == null)
                LogError("Unknown Error!");
            else
                LogError(exception.ToString());
        }

        public void LogError(string error)
        {
            var saved = rtb.ForeColor;
            rtb.ForeColor = Color.Red;

            rtb.AppendText(error + "\r\n");
            rtb.ScrollToCaret();

            rtb.ForeColor = saved;
        }

        public void LogMessage(string message)
        {
            var saved = rtb.ForeColor;
            rtb.ForeColor = Color.Black;

            rtb.AppendText(message + "\r\n");
            rtb.ScrollToCaret();

            rtb.ForeColor = saved;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtb.Clear();
            rtb.ScrollToCaret();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtb.Text);
        }
    }
}
