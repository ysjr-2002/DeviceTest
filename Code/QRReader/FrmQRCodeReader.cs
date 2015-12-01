﻿
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QRReader
{
    public partial class FrmQRCodeReader : FrmBase
    {
        SerialPort serial = null;
        string sourceByte = "02 5D 51 31 68 74 74 70 3A 2F 2F 77 77 77 2E 63 68 69 6E 61 62 65 73 6F 2E 63 6F 6D 2F 03";
        public FrmQRCodeReader()
        {
            InitializeComponent();

            var c = Encoding.UTF8.GetBytes("/");
        }

        private void FrmQRCodeReader_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbPorts.DataSource = ports;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cmbPorts.Items.Count == 0)
            {
                MessageBox.Show("计算机未发现串口！");
            }
            serial = new SerialPort(cmbPorts.Text, 9600, Parity.None, 8, StopBits.One);
            try
            {
                serial.Open();
                ThreadPool.QueueUserWorkItem(ReadComm);
                btnOpen.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadComm(object obj)
        {
            while (true)
            {
                var pos = 0;
                byte[] buffer = new byte[128];
                var stx = (byte)serial.ReadByte();
                if (stx != 0x02)
                    continue;

                buffer[pos] = stx;
                pos++;
                byte b = 0;
                while ((b = (byte)serial.ReadByte()) != 0x03)
                {
                    buffer[pos] = b;
                    pos++;
                }
                ShowCode(buffer, pos);
            }
        }

        private void ShowCode(byte[] buffer, int pos)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < pos; i++)
            {
                sb.Append(buffer[i] + " ");
                if (i == (pos - 1))
                    sb.AppendLine(buffer[i].ToString());
            }
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText(sb.ToString());
                var codeStr = Encoding.UTF8.GetString(buffer, 4, pos - 4);
                richTextBox1.AppendText(DateTime.Now + " " + codeStr);
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serial != null)
            {
                if (serial.IsOpen)
                    serial.Close();
            }
            base.OnFormClosing(e);
        }
    }
}
