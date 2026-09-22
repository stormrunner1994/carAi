using System;
using System.Windows.Forms;

namespace CarAI
{
    public partial class Form1 : Form
    {
        private Simulator Simulator {  get; set; }

        public Form1()
        {
            InitializeComponent();
            Viewer.Init(this);
            Simulator = new Simulator();
            comboBoxSteps.SelectedIndex = 0;
            comboBoxNumberCars.SelectedIndex = 1;


        }

        public Panel GetPanel()
        {
            return panel1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                StartSimulation();
            }
            else
            {
                button1.Text = "Start";
                StopSimulation();
            }
        }

        private void StopSimulation()
        {
            Simulator.Stop();
        }

        private void StartSimulation()
        {
            int value = 0;
            Simulator.TerminationReasons stopreason = Simulator.TerminationReasons.None;
            if (comboBoxTime.SelectedIndex != -1)
            {
                stopreason = Simulator.TerminationReasons.Time;
                if (comboBoxTime.Text == "5sek")
                    value = 5;
                else if (comboBoxTime.Text == "20sek")
                    value = 20;
                else if (comboBoxTime.Text == "1min")
                    value = 60;
                else if (comboBoxTime.Text == "2min")
                    value = 120;
            }
            else if (comboBoxSteps.SelectedIndex != -1)
            {
                stopreason = Simulator.TerminationReasons.Steps;
                Int32.TryParse(comboBoxSteps.Text, out value);
            }

            Simulator.Start(stopreason, value);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                comboBoxTime.SelectedIndex = -1;
                comboBoxSteps.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                comboBoxSteps.SelectedIndex = -1;
                comboBoxTime.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            int numberCars = 5;
            Int32.TryParse(comboBoxNumberCars.Text, out numberCars);
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            Simulator.NextMove();
        }
    }
}
