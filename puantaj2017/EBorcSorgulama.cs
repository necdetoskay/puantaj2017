using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.WcfLinq.Helpers;
using mshtml;
using puantaj2017.DAL;


namespace puantaj2017
{
    public partial class EBorcSorgulama : Form
    {
        public EBorcSorgulama()
        {
            InitializeComponent();
        }

        private void EBorcSorgulama_Load(object sender, EventArgs e)
        {
            //SirketCBItem
            comboBox1.DataSource = new SirketCBItem[]
            {
                new SirketCBItem
                {
                    ŞirketAdı = "KENTKONUT MERKEZ",
                    YeniŞubeKod = "01",
                    EskiŞubeKod = "01",
                    SıraNo = "0081575",
                    İlKodu = "041",
                    AracıNumarası = "000"
                },
                new SirketCBItem
                {
                    ŞirketAdı = "KENTKONUT HAFRİYAT",
                    YeniŞubeKod = "01",
                    EskiŞubeKod = "01",
                    SıraNo = "1145396",
                    İlKodu = "041",
                    AracıNumarası = "000"
                }
            };
            comboBox1.SelectedIndex = -1;
            comboBox1.DisplayMember = "ŞirketAdı";
        }
        public Rectangle GetAbsoluteRectangle(HtmlElement element)
        {
            //get initial rectangle
            Rectangle rect = element.OffsetRectangle;

            //update with all parents' positions
            HtmlElement currParent = element.OffsetParent;
            while (currParent != null)
            {
                rect.Offset(currParent.OffsetRectangle.Left, currParent.OffsetRectangle.Top);
                currParent = currParent.OffsetParent;
            }

            return rect;
        }




        //private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        //{
        //    webBrowser1.Navigated-=webBrowser1_Navigated;
        //    HtmlElement elem;
        //    //elem = webBrowser1.Document.GetElementById("resimyazi");
        //    Timer timer = new Timer();
        //    EventHandler handler = (s, es) =>
        //    {
        //        elem = webBrowser1.Document.GetElementById("resimyazi");
        //        if (elem != null)
        //        {
        //            timer.Stop();
        //            Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
        //            webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
        //            webBrowser1.Size));
        //            var pos = GetAbsoluteRectangle(elem);
        //            pictureBox1.Image = CropBitmap(bitmap, pos.X, pos.Y, pos.Width, pos.Height);
        //            //pictureBox1.Image = CropBitmap(bitmap, 13, 248,160, 62);
        //            timer.Dispose();
        //        }
        //    };
           
        //    timer.Tick += handler;
        //    timer.Interval = 1000;
        //    timer.Start();




        //}


        public HtmlElement Getelement(string tag, string attribute,string deger)
        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName(tag);
            HtmlElement wanted;

            foreach (HtmlElement item in col)
            {
                if (item.GetAttribute(attribute) == deger)
                {
                    return item;
                  
                }
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var elem = webBrowser1.Document.GetElementById("j_username");
            if (elem == null) return;
            elem.InnerText = "60127446662";

            elem = webBrowser1.Document.GetElementById("j_password");
            if (elem == null) return;
            elem.InnerText = "27446662";

            
           
            //if (string.IsNullOrEmpty(textBox1.Text)) return;

            //elem = Getelement("input", "name", "Captcha");
            //elem.InnerText = textBox1.Text;

            
            elem = Getelement("input", "value", "giriş yap");
            if(elem==null) return;
            //webBrowser1.Navigated += BorcSayfası;
            elem.InvokeMember("click");



        }

        private void BorcSayfası(object sender, WebBrowserNavigatedEventArgs e)
        {
            webBrowser1.Navigated -= BorcSayfası;
            HtmlElement elem;
            //elem = webBrowser1.Document.GetElementById("resimyazi");
            Timer timer = new Timer();
            EventHandler handler = (s, es) =>
            {
                elem = Getelement("input", "value", "Asgari Ücret Destek tutarı sorgulama");
                if (elem != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    webBrowser1.Navigated += DestekTutarSorgula;
                    elem.InvokeMember("click");
                   
                }
            };

            timer.Tick += handler;
            timer.Interval = 1000;
            timer.Start();
        }

        private void DestekTutarSorgula(object sender, WebBrowserNavigatedEventArgs e)
        {
            //webBrowser1.Navigated += DestekTutarSorgula;

            //HtmlElement elem;
            ////elem = webBrowser1.Document.GetElementById("resimyazi");
            //Timer timer = new Timer();
            //EventHandler handler = (s, es) =>
            //{
            //    elem = webBrowser1.Document.GetElementById("resimyazi");
            //    if (elem != null)
            //    {
            //        timer.Stop();
            //        Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
            //        webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
            //        webBrowser1.Size));
            //        var pos = GetAbsoluteRectangle(elem);
            //        pictureBox1.Image = CropBitmap(bitmap, pos.X, pos.Y, pos.Width, pos.Height);
            //        //pictureBox1.Image = CropBitmap(bitmap, 13, 248,160, 62);
            //        timer.Dispose();

            //        elem = webBrowser1.Document.GetElementById("bs_yenisubekod");
            //        //elem.InnerText=







            //    }
            //};

            //timer.Tick += handler;
            //timer.Interval = 1000;
            //timer.Start();






            //Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
            //webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
            //webBrowser1.Size));
            //var pos = GetAbsoluteRectangle(elem);
            //pictureBox1.Image = CropBitmap(bitmap, pos.X, pos.Y, pos.Width, pos.Height);
            ////pictureBox1.Image = CropBitmap(bitmap, 13, 248,160, 62);





            //MessageBox.Show("destek sorgulama sayfası");
        }

        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.DocumentCompleted -= webBrowser1_DocumentCompleted;


            Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
            webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
            webBrowser1.Size));
           // pictureBox1.Image = CropBitmap(bitmap, 13, 248,160, 62);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var elem = Getelement("input", "value", "Asgari Ücret Destek tutarı sorgulama");
            if (elem == null) return;
            webBrowser1.Navigated += DestekTutarSorgula;
            elem.InvokeMember("click");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HtmlElement elem;
            Timer timer = new Timer();
            EventHandler handler = (s, es) =>
            {
                elem = Getelement("name", "value", "Yenile");
                if (elem != null)
                {


                    //timer.Stop();
                    //Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
                    //webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
                    //webBrowser1.Size));
                    //var pos = GetAbsoluteRectangle(elem);
                    //pictureBox1.Image = CropBitmap(bitmap, pos.X, pos.Y, pos.Width, pos.Height);
                    ////pictureBox1.Image = CropBitmap(bitmap, 13, 248,160, 62);
                    //timer.Dispose();
                }
               
                
            };

            timer.Tick += handler;
            timer.Interval = 1000;
            timer.Start();









            //var elem = Getelement("name", "value", "Yenile");
            //if (elem == null) return;
            //webBrowser1.Navigated += (se, es) =>
            //{
            //    Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height);
            //    webBrowser1.DrawToBitmap(bitmap, new Rectangle(new Point(),
            //    webBrowser1.Size));
            //    var pos = GetAbsoluteRectangle(elem);
            //    pictureBox1.Image = CropBitmap(bitmap, pos.X, pos.Y, pos.Width, pos.Height);
            //};
            //elem.InvokeMember("click");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SirketCBItem sirket = (SirketCBItem)comboBox1.SelectedItem;
            var elem = webBrowser1.Document.GetElementById("bs_yenisubekod");
            if(elem==null) return;
            elem.InnerText = sirket.YeniŞubeKod;

            elem = webBrowser1.Document.GetElementById("bs_eskisubekod");
            if (elem == null) return;
            elem.InnerText = sirket.EskiŞubeKod;

            elem = webBrowser1.Document.GetElementById("bs_sirano");
            if (elem == null) return;elem.InnerText = sirket.SıraNo;

            elem = webBrowser1.Document.GetElementById("bs_ilkod");
            if (elem == null) return;
            elem.InnerText = sirket.İlKodu;

            elem = webBrowser1.Document.GetElementById("bs_aracino");
            if (elem == null) return;elem.InnerText = sirket.AracıNumarası;

            elem = webBrowser1.Document.GetElementById("Captcha");
            if (elem == null) return;
            if(elem.GetAttribute("value")=="") return;

            //HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("input");
            //HtmlElement wanted;

            //foreach (HtmlElement item in col)
            //{
            //    if (item.GetAttribute("value") == "Agari Ücret Destek Göster")
            //    {
            //        wanted = item;
            //        break;
            //    }
            //}
            var elements = Getelement("input", "value", "Agari Ücret Destek Göster");
            elements.InvokeMember("click");

        }
    }
}
