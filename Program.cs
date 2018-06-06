using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurnerControl
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        /// <summary>Displays Any String</summary>
        /// <param name="StringToDisplay">Object with Properties to edit</param>
        /// <param name="pDaddy">Parent Form Or Nothing (null)</param>
        /// <param name="strTitle">Window Title</param>
        public static void DisplayABigString(string StringToDisplay, System.Windows.Forms.Control pDaddy, string strTitle = "")
        {
            System.Windows.Forms.Form frmEO = new System.Windows.Forms.Form();
            TextBox T = new TextBox() { Multiline = true, ScrollBars = ScrollBars.Both, Dock = DockStyle.Fill, WordWrap = false };
            frmEO.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            frmEO.Text = strTitle;
            frmEO.Controls.Add(T);
            T.Text = StringToDisplay;
            T.Font = CourierNew();
            T.SelectionStart = 0;
            T.SelectionLength = 0;
            T.KeyDown += TextBox_KeyDown;
            frmEO.Hide();
            frmEO.Height = 640;
            frmEO.Width = 640;
            System.Windows.Forms.Application.DoEvents();
            if (pDaddy == null)
            {
                frmEO.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                frmEO.ShowDialog();
            }
            else
            {
                frmEO.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                frmEO.ShowDialog(pDaddy);
            }
            frmEO.Dispose();
        }
        private static void TextBox_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.A) { ((TextBox)sender).SelectAll(); e.Handled = true; }
            }
        }
        public static bool ViewObject;//= System.Configuration.ConfigurationManager.AppSettings["ViewObject"];
        /// <summary>Creates a new font of Courier New 8pt</summary>
        /// <remarks><example><code>txtSample.Font = CourierNew</code></example></remarks>
        public static System.Drawing.Font CourierNew(float sngSize = 8.25f, System.Drawing.FontStyle eStyle = System.Drawing.FontStyle.Regular) { return new System.Drawing.Font("Courier New", sngSize, eStyle, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0)); }

        /// <summary>Creates a new font of Microsoft Sans Serif New 8pt</summary>
        /// <remarks><example><code>txtSample.Font = Microsoft Sans Serif</code></example></remarks>
        public static System.Drawing.Font MicrosoftSansSerif(float sngSize = 8.25f, System.Drawing.FontStyle eStyle = System.Drawing.FontStyle.Regular) { return new System.Drawing.Font("Courier New", sngSize, eStyle, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0)); }


    }
}
