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
                "#      #    #      o      ##",
                "#                          #",
                "#          #####           #",
                "##         #   #    ##     #",
                "###           ##     #     #",
                "#           ###      #     #",
                "#   ####                   #",
                "#   ##       o             #",
                "# o  #         o       ### #",
                "#    #                     #",
                "############################"
            }, new Dictionary<char, System.Type>
            {
                ['#'] = typeof(WallCritter),
                ['o'] = typeof(BouncingCritter)
            });

        public Form1()
        {
            InitializeComponent();
            label1.Font = new Font(FontFamily.GenericMonospace, 20);
            label1.Text = _world.ToString();
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
            label1.Text = _world.ToString();
        }
    }
}