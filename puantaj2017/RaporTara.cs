using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using puantaj2017.DAL;

namespace puantaj2017
{
    public partial class RaporTara : Form
    {
        public RaporTara()
        {
            InitializeComponent();
            using (var ik=new ikEntities())
            {
                comboBox1.DataSource = ik.Personels.Select(c => new
                {
                    id = c.pdksid,
                    Adsoyad = c.adsoyad
                }).ToList();
                comboBox1.DisplayMember = "Adsoyad";
                comboBox1.ValueMember = "id";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    var filename = System.IO.Path.GetTempPath() + Guid.NewGuid() + ".jpg";
        //    Result result = new AspriseImaging().Scan(new Request()
        //        .SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB)
        //        .SetPromptScanMore(false) // prompt to scan more pages
        //        .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG)
        //          .SetSavePath(filename)), // Environment variables in path will be expanded
        //      "select", true, true); // "select" prompts device selection dialog.
        //    var files = result.GetImageFiles();
        //    if (files.Any()){

        //        Image image = Image.FromFile(files[0]);
        //        CropImage(image.Width, image.Height - 100, filename, filename.Replace(".jpg", "-1.jpg"));
        //        image.Dispose();
        //        pictureBox1.ImageLocation = filename.Replace(".jpg", "-1.jpg");
              
              
        //    }
        }

        private void CropImage(int Width, int Height, string sourceFilePath, string saveFilePath)
        {// variable for percentage resize 
            float percentageResize = 0;
            float percentageResizeW = 0;
            float percentageResizeH = 0;

            // variables for the dimension of source and cropped image 
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;// Create a bitmap object file from source file 
            Bitmap sourceImage = new Bitmap(sourceFilePath);

            // Set the source dimension to the variables 
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            // Calculate the percentage resize 
            percentageResizeW = ((float)Width / (float)sourceWidth);
            percentageResizeH = ((float)Height / (float)sourceHeight);

            // Checking the resize percentage 
            if (percentageResizeH < percentageResizeW)
            {
                percentageResize = percentageResizeW;
                destY = System.Convert.ToInt16((Height - (sourceHeight * percentageResize)) / 2);
            }
            else
            {
                percentageResize = percentageResizeH;
                destX = System.Convert.ToInt16((Width - (sourceWidth * percentageResize)) / 2);
            }

            // Set the new cropped percentage image
            int destWidth = (int)Math.Round(sourceWidth * percentageResize);
            int destHeight = (int)Math.Round(sourceHeight * percentageResize);

            // Create the image object 
            using (Bitmap objBitmap = new Bitmap(Width, Height))
            {
                objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    // Set the graphic format for better result cropping 
                    objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    objGraphics.DrawImage(sourceImage, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

                    // Save the file path, note we use png format to support png file 
                    objBitmap.Save(saveFilePath, ImageFormat.Png);
                    objGraphics.Dispose();
                    objBitmap.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                using (SmtpClient client = new SmtpClient("owa.kentkonut.com.tr", 25))
                {
                    client.Credentials = new System.Net.NetworkCredential("noskay", "25951697");
                    client.EnableSsl = true;
                    using (MailMessage message = new MailMessage()
                    {
                       From = new MailAddress("noskay@kentkonut.com.tr"),
                       To= {new MailAddress("noskay@kentkonut.com.tr")}
                    })
                    {
                        message.Subject = "Raporlu Personel Hakkında (" + comboBox1.Text + ")";
                        message.IsBodyHtml = true;
                        message.Body = string.Format("{0} {1} raporludur.",
                            comboBox1.Text,
                            dateTimePicker1.Value.Date == dateTimePicker2.Value.Date
                                ? dateTimePicker1.Value.Date.ToShortDateString() + " tarihinde"
                                : String.Format("{0}-{1} tarihleri arasında",
                                dateTimePicker1.Value.Date.ToShortDateString(),
                                dateTimePicker2.Value.Date.ToShortDateString()));
                        ;

                        if(File.Exists(pictureBox1.ImageLocation))
                            message.Attachments.Add(new Attachment(pictureBox1.ImageLocation));

                        //foreach (var s in new string[] { "noskay@kentkonut.com.tr" }) { message.To.Add(s); }
                        client.Send(message);
                        MessageBox.Show("Mail Gönderildi");
                    }
                }}
            catch (Exception exxxx)
            {

                throw;
            }
        }

        private void pdksSistemineKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Rapor Kaydı Sisteme girilsinmi","Rapor Ekle", MessageBoxButtons.YesNo)!= DialogResult.Yes) return;

            var id = comboBox1.SelectedValue;
            var tatil_id = 7;
            var saat = "00:00:00";
            var saatlik = 0;
            var aciklama = textBox1.Text;
            var tarih1 = dateTimePicker1.Value.Date;
            var tarih2 = dateTimePicker2.Value.Date;
            if(aciklama==String.Empty) return;


            using (var con =
                    new MySqlConnection(
                        "Server=172.41.40.85;Database=perkotek;Uid=root;Pwd=max;AllowZeroDateTime=True;Charset=latin5"))
            {
               var com=new MySqlCommand("",con);
                com.CommandText = string.Format("select id from personel_izin where tarih='{0}' and personel_id={1}",
                    tarih1.ToString("yyyy-MM-dd"),
                    id);
                con.Open();
                var result=com.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Belirtilen Güne ait Rapor sistemde kayıtlı");
                    con.Close();
                    return;
                }
                var kayit = 0;
                for (var t1 = dateTimePicker1.Value; t1 <= dateTimePicker2.Value; t1=t1.AddDays(1))
                {
                    com.CommandText =
                        string.Format(
                            "insert into personel_izin (personel_id,tatil_id,tarih,gidis_saat,gelis_saat,saatlik,aciklama,otoizin) " +
                            "values({0},{1},'{2}','{3}','{4}',{5},'{6}',{7})",
                            id,
                            tatil_id,
                            t1.ToString("yyyy-MM-dd"),
                            saat,
                            saat,
                            saatlik,
                            aciklama,
                            0);
                    com.ExecuteNonQuery();
                    kayit++;
                }


                con.Close();
                MessageBox.Show($"{kayit} adet kayıt girildi");
            }

        //verileri al
            //mysql bağlantısı oluştur
            //kayıt yoksa kaydet varsa uyar
            //kaydet
        }
    }
}
