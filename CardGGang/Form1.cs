using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace CardGGang
{
    public partial class Form1 : Form
    {
        SoundPlayer MainMusic = new SoundPlayer(Application.StartupPath + @"\Music\" + "MainMusic.wav");
        static string defaultPath = Application.StartupPath + @"\CardImage\";
        string cardPath = defaultPath;
        PictureBox[] pictureBoxs = new PictureBox[5];
        const int NormalProbability = 0;
        const int RareProbability = 70;
        const int EpicProbability = 95;
        const int LegendProbability = 99;
        bool[] checkCard = new bool[5];
        int[] checkProbability = new int[5];
        int[] cardCount = new int[4];
        const int WaitTime = 200;
        bool isClick = false;
        int cardOpenCount = 0;

        public Form1()
        {
            InitializeComponent();
            MainMusic.PlayLooping();
        }

        private void LegendCardPlay()
        {
            MainMusic.Stop();
            SoundPlayer simpleSound = new SoundPlayer(Application.StartupPath + @"\Music\" + "Legend.wav");
            simpleSound.Play();
            MainMusic.PlayLooping();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;

            for (int i = 0; i < pictureBoxs.Length; i++)
                pictureBoxs[i].BackColor = Color.Transparent;
            label1.Hide();

            startPoint = Pack.Location;
        }
        private int RandJobCardChoice()
        {
            Random rand = new Random();
            return rand.Next(0, 10);
        }
        private void CardJobChoice(int choiceValue)
        {
            switch (choiceValue)
            {
                case 0:
                    cardPath += @"Normal\";
                    break;
                case 1:
                    cardPath += @"Druid\";
                    break;
                case 2:
                    cardPath += @"Hunter\";
                    break;
                case 3:
                    cardPath += @"Mage\";
                    break;
                case 4:
                    cardPath += @"Paladin\";
                    break;
                case 5:
                    cardPath += @"Priest\";
                    break;
                case 6:
                    cardPath += @"Rogue\";
                    break;
                case 7:
                    cardPath += @"Shaman\";
                    break;
                case 8:
                    cardPath += @"Warlock\";
                    break;
                case 9:
                    cardPath += @"Warrior\";
                    break;
            }
        }

        private int RandomGradeCardChoice()
        {
            Random rand = new Random();
            return rand.Next(0, 100);
        }

        private void CardGradeChoice(int choiceValue)
        {
            if (choiceValue >= LegendProbability)
            {
                cardPath += @"Legend\";
                LegendCardPlay();
                cardCount[3]++;
                this.CardCountList.Items.Add("전설카드");
                CardCountList.SelectedIndex = CardCountList.Items.Count - 1;
            }
            else if (choiceValue >= EpicProbability && choiceValue < LegendProbability)
            {
                cardPath += @"Epic\";
                cardCount[2]++;
                this.CardCountList.Items.Add("특급카드");
                CardCountList.SelectedIndex = CardCountList.Items.Count - 1;
            }
            else if (choiceValue >= RareProbability && choiceValue < EpicProbability)
            {
                cardPath += @"Rare\";
                cardCount[1]++;
                this.CardCountList.Items.Add("희귀카드");
                CardCountList.SelectedIndex = CardCountList.Items.Count - 1;
            }
            else
            {
                cardPath += @"Normal\";
                cardCount[0]++;
                this.CardCountList.Items.Add("일반카드");
                CardCountList.SelectedIndex = CardCountList.Items.Count - 1;
            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (checkCard[0] == true) return;
            checkCard[0] = true;

            CardJobChoice(RandJobCardChoice());
            checkProbability[0] = RandomGradeCardChoice();

            bool chk = false;
            for(int i = 0; i < checkProbability.Length; i++)
            {
                if (i == 0) continue;
                if (checkCard[i] == true)
                {
                    chk = true;
                    break;
                }
            }

            if (chk == false)
                CardGradeChoice(RareProbability);
            else
                CardGradeChoice(checkProbability[0]);

            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(cardPath);
            System.IO.FileInfo[] fileList = directory.GetFiles("*.png");

            Thread.Sleep(WaitTime);

            Random rand = new Random();
            int randomValue = rand.Next(0, fileList.Length);

            pictureBox1.Load(cardPath + fileList[randomValue]);
            cardPath = defaultPath;
            CheckAllCard();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (checkCard[1] == true) return;
            checkCard[1] = true;

            CardJobChoice(RandJobCardChoice());
            checkProbability[1] = RandomGradeCardChoice();

            bool chk = false;
            for (int i = 0; i < checkProbability.Length; i++)
            {
                if (i == 1) continue;
                if (checkCard[i] == true)
                {
                    chk = true;
                    break;
                }
            }

            if (chk == false)
                CardGradeChoice(RareProbability);
            else
                CardGradeChoice(checkProbability[1]);

            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(cardPath);
            System.IO.FileInfo[] fileList = directory.GetFiles("*.png");

            Thread.Sleep(WaitTime);

            Random rand = new Random();
            int randomValue = rand.Next(0, fileList.Length);

            pictureBox2.Load(cardPath + fileList[randomValue]);
            cardPath = defaultPath;
            CheckAllCard();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (checkCard[2] == true) return;
            checkCard[2] = true;

            CardJobChoice(RandJobCardChoice());
            checkProbability[2] = RandomGradeCardChoice();

            bool chk = false;
            for (int i = 0; i < checkProbability.Length; i++)
            {
                if (i == 2) continue;
                if (checkCard[i] == true)
                {
                    chk = true;
                    break;
                }
            }

            if (chk == false)
                CardGradeChoice(RareProbability);
            else
                CardGradeChoice(checkProbability[2]);

            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(cardPath);
            System.IO.FileInfo[] fileList = directory.GetFiles("*.png");

            Thread.Sleep(WaitTime);

            Random rand = new Random();
            int randomValue = rand.Next(0, fileList.Length);

            pictureBox3.Load(cardPath + fileList[randomValue]);
            cardPath = defaultPath;
            CheckAllCard();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (checkCard[3] == true) return;
            checkCard[3] = true;

            CardJobChoice(RandJobCardChoice());
            checkProbability[0] = RandomGradeCardChoice();

            bool chk = false;
            for (int i = 0; i < checkProbability.Length; i++)
            {
                if (i == 3) continue;
                if (checkCard[i] == true)
                {
                    chk = true;
                    break;
                }
            }

            if (chk == false)
                CardGradeChoice(RareProbability);
            else
                CardGradeChoice(checkProbability[3]);

            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(cardPath);
            System.IO.FileInfo[] fileList = directory.GetFiles("*.png");

            Thread.Sleep(WaitTime);

            Random rand = new Random();
            int randomValue = rand.Next(0, fileList.Length);

            pictureBox4.Load(cardPath + fileList[randomValue]);
            cardPath = defaultPath;
            CheckAllCard();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (checkCard[4] == true) return;
            checkCard[4] = true;

            CardJobChoice(RandJobCardChoice());
            checkProbability[4] = RandomGradeCardChoice();

            bool chk = false;
            for (int i = 0; i < checkProbability.Length; i++)
            {
                if (i == 4) continue;
                if (checkCard[i] == true)
                {
                    chk = true;
                    break;
                }
            }

            if (chk == false)
                CardGradeChoice(RareProbability);
            else
                CardGradeChoice(checkProbability[4]);

            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(cardPath);
            System.IO.FileInfo[] fileList = directory.GetFiles("*.png");

            Thread.Sleep(WaitTime);

            Random rand = new Random();
            int randomValue = rand.Next(0, fileList.Length);

            pictureBox5.Load(cardPath + fileList[randomValue]);
            cardPath = defaultPath;
            CheckAllCard();
        }

        private void CheckAllCard()
        {
            for (int i = 0; i < checkCard.Length; i++)
                if (checkCard[i] == false) return;

            label1.Show();

        }
        private void label1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBoxs.Length; i++)
                pictureBoxs[i].Load(Application.StartupPath + @"\CardImage\" + "Card.png");

            for (int i = 0; i < checkCard.Length; i++) checkCard[i] = false;
            label1.Hide();

            this.CardCountList.Items.Add("일반 : " + cardCount[0] + ' '+ "희귀 : " + cardCount[1] + ' '+ 
                "특급 : " + cardCount[2] + ' '+ "전설 : " + cardCount[3] + '\n');
            TotalPowder.Text = (cardCount[0] * 5 + cardCount[1] * 20 + cardCount[2] * 100 + cardCount[3] * 400).ToString();
            lblCardOpenCount.Text = (++cardOpenCount).ToString();
        }

    }
}
