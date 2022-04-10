using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GameOfTheYear
{
    public partial class Form2 : Form
    {
        int count = 0;
        Random rnd = new Random();
        List<Bitmap> pictures = new List<Bitmap>()
        {
            Properties.Resources.Putin_01,Properties.Resources.Putin_02,Properties.Resources.Putin_03,
            Properties.Resources.Putin_04,Properties.Resources.Putin_05,Properties.Resources.Putin_06,
            Properties.Resources.Putin_07,Properties.Resources.Putin_08,Properties.Resources.Putin_09,
            Properties.Resources.Putin_10,Properties.Resources.Putin_11,Properties.Resources.Putin_12,
            Properties.Resources.Putin_13,Properties.Resources.Putin_14,Properties.Resources.Putin_15,
            Properties.Resources.Putin_16,Properties.Resources.Putin_17,Properties.Resources.Putin_18
        };
        PictureBox firstClick = null;
        PictureBox secondClick = null;
        public Form2()
        {
            InitializeComponent();
            RandomizeImages();
        }

        private void RandomizeImages()
        {
            List<PictureBox> pictureBoxes = panel1.Controls.OfType<PictureBox>().ToList();
            foreach (var pic in pictures)
            {
                int numRnd = rnd.Next(pictureBoxes.Count);
                PictureBox picture1 = pictureBoxes[numRnd];                
                picture1.BackgroundImage = pic;
                picture1.Image = Properties.Resources.back;
                pictureBoxes.RemoveAt(numRnd);
                numRnd = rnd.Next(pictureBoxes.Count);
                PictureBox picture2 = pictureBoxes[numRnd];
                picture2.BackgroundImage = pic;
                picture2.Image = Properties.Resources.back;
                pictureBoxes.RemoveAt(numRnd);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image.Equals(pic.BackgroundImage))
            {
                return;
            }
            if (firstClick == null)
            {
                firstClick = sender as PictureBox;                
                firstClick.Image = firstClick.BackgroundImage;
            }
            else
            {
                secondClick = sender as PictureBox;                
                secondClick.Image = secondClick.BackgroundImage;
                if (secondClick.Image.Equals(firstClick.Image))
                {
                    firstClick = null;
                    secondClick = null;
                    count++;
                }
                else
                {
                    firstClick.Image = Properties.Resources.back;
                    secondClick.Image = Properties.Resources.back;
                    firstClick = null;
                    secondClick = null;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
