using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace C샵_Tesseract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "Car1.png"; //Car1.png 는 사진의 이름 이므로, 자신의 자신의 이름을 적어 놓으면 된다.
        }

        public Bitmap Image2D(Bitmap img, int value)
        {
            int mean;

            Color color;

            for (int i = 0; i < img.Width; i++)

            {
                for (int z = 0; z < img.Height; z++)

                {
                    color = img.GetPixel(i, z);

                    mean = (color.R + color.G + color.B) / 3;

                    if (mean < value)

                    {
                        img.SetPixel(i, z, Color.Black);
                    }
                    else

                    {
                        img.SetPixel(i, z, Color.White);
                    }
                }
            }

            return img;
        }

        private void Button1_Click(object sender, System.EventArgs e)  //Button을 통한 차량번호인식을 한글로 나타내준다.
        {
            pictureBox1.Image = Image2D(new Bitmap(pictureBox1.Image), 50);

            var ocr = new TesseractEngine("./tessdata", "kor", EngineMode.Default);
            var texts = ocr.Process(new Bitmap(pictureBox1.Image));
            MessageBox.Show(texts.GetText());
        }
    }
}