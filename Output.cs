using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
namespace allstate
{
    class Output
    {
        private bool printerChecked, eagentChecked;
        public void Print(bool printer,bool eagnet) //will print automatically to the default printer. will then give the user the option to reprint it to a printer of their choice. This is done purposely.
        {
            printerChecked = printer;
            eagentChecked = eagnet;
            // Create a WebBrowser instance. 
            WebBrowser webBrowserForPrinting = new WebBrowser();

            // Add an event handler that prints the document after it loads.
            webBrowserForPrinting.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            // Set the Url property to load the document.
            webBrowserForPrinting.Url = new Uri(@"c:\test\aaaa.html");
        }
        private void PrintDocument(object sender,
        WebBrowserDocumentCompletedEventArgs e)
        {
            if (printerChecked)
            {
                ((WebBrowser)sender).Print();
            }
            if (eagentChecked)
            {
                ((WebBrowser)sender).ShowPrintDialog();
            }
            // Dispose the WebBrowser now that the task is complete. 
            ((WebBrowser)sender).Dispose();
        }
    }
}
