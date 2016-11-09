using EletronicLifeTest.Critters;
using EletronicLifeTest.Map;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EletronicLifeTest
{
    public partial class Form1 : Form
    {
        private World _world = new World(new[]
            {
               "############################",
               "#####                 ######",
               "##   ***                **##",
               "#   *##**         **  O  *##",
               "#    ***     O    ##**    *#",
               "#       O         ##***    #",
               "#                 ##**     #",
               "#   O       #*             #",
               "#*          #**       O    #",
               "#***        ##**    O    **#",
               "##****     ###***       *###",
               "############################"
            }, new Dictionary<char, System.Type>
            {
                ['#'] = typeof(Wall),
                ['O'] = typeof(PlantEater),
                ['*'] = typeof(Plant)
            });

        public Form1()
        {
            InitializeComponent();
            textBox1.Font = new Font(FontFamily.GenericMonospace, 20);
            textBox1.Text = _world.ToString();
            timer1.Interval = 1000;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //_world.Turn();
            //label1.Text = _world.ToString();

            if (!timer1.Enabled)
                timer1.Start();
            else timer1.Stop();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            _world.Turn();
            textBox1.Text = _world.ToString();
        }
    }
}