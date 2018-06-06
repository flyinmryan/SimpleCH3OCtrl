using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BurnerControl
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent(); // Don't Touch this method
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Form Load (first thing that happens when form is loaded
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Open();
                serialPort.WriteLine("A");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                serialPort.Close();
            }

        }
    }
}
