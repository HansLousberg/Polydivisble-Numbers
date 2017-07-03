using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace uwptest4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //enum word hier slechts gebruikt als een proof of concept.
        enum getallensystemen
        {
            nul,
            een,
            twee,
            drie,
            vier,
            vijf,
            zes,
            zeven,
            acht,
            negen,
            tien,
            elf,
            twaalf,
            dertien,
            veertien
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int getallensysteem = 0;
                char[] text = textBox.Text.ToCharArray();
                foreach(char character in text)
                {
                    //misschien is er een betere methode voor
                    getallensysteem = getallensysteem * 10;
                    if (character == '0')
                        getallensysteem += 0;
                    else if (character == '1')
                        getallensysteem += (int)getallensystemen.een; //enum word hier slechts gebruikt als een proof of concept.
                    else if (character == '2')
                        getallensysteem += 2;
                    else if (character == '3')
                        getallensysteem += 3;
                    else if (character == '4')
                        getallensysteem += 4;
                    else if (character == '5')
                        getallensysteem += 5;
                    else if (character == '6')
                        getallensysteem += 6;
                    else if (character == '7')
                        getallensysteem += 7;
                    else if (character == '8')
                        getallensysteem += 8;
                    else if (character == '9')
                        getallensysteem += 9;
                    
                }
                textBlock.Text = "";

                poly getallencheck = new uwptest4.poly(getallensysteem);
                List<PolyNumber> list = getallencheck.SearchPolyDivisableNumbers();
                textBlock.Text += "er zijn " + list.Count + " oplossingingen \r\n";
                foreach (PolyNumber getal in list)
                {
                    textBlock.Text = textBlock.Text + getal.ToString() + "\r\n";
                }
                
            }
            catch
            {

            }
        }
    }
}
