using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using NeuralNetTypes;
using NeuralNet.Configuration;
using System.IO;

namespace NeuralNetTester
{
    public partial class NeuralNetForm : Form
    {
        // The current neural net, and whether it is trained or not
        private NeuralNetTask net;
        private bool trained;

        // Each item in the drop down is associated with a delegate that creates the neural net
        private delegate NeuralNetTask NeuralNetCreator();

        public NeuralNetForm()
        {
            InitializeComponent();

            // Add the neural networks that have config files
            Dictionary<string, NeuralNetCreator> comboSource = FindConfigFiles(".");
            // This is how to add a neural network that doesn't have a config file
            comboSource.Add("Square", (() => new NeuralNetSquare()));

            cmbType.DisplayMember = "Key";
            cmbType.ValueMember = "Value";
            cmbType.DataSource = new BindingSource(comboSource, null);
        }

        private Dictionary<string, NeuralNetCreator> FindConfigFiles(string path)
        {
            var configs = new Dictionary<string, NeuralNetCreator>();

            foreach (string file in Directory.GetFiles(path, "*.net.xml"))
            {
                var factory = new ConfiguredNeuralNetFactory(file);
                configs.Add(factory.ShortDescription, factory.CreateNeuralNet);
            }

            return configs;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateNet();
        }

        private void CreateNet()
        { 
            lstOutput.Items.Clear();
            NotReadyForQuery();

            net = ((NeuralNetCreator)cmbType.SelectedValue).Invoke();
            trained = false;

            net.Message += OnNetMessage;
            txtDescription.Text = net.Description;
        }

        private async void btnTrain_Click(object sender, EventArgs e)
        {
            btnTrain.Enabled = false;

            // If we already have a trained network, then when we re-train
            // we need to create a new network first
            if (trained) CreateNet();

            // Clear the output list
            lstOutput.Items.Clear();

            // Do the training
            if (chkLimit.Checked)
                await Task.Run(() => net.Train((long)updIterations.Value));
            else
                await Task.Run(() => net.Train());

            // Enable user input
            btnTrain.Enabled = true;
            PrepareForQuery();
            trained = true;
        }

        // Disable user input
        private void NotReadyForQuery()
        {
            dgvInputs.Columns.Clear();
            dgvInputs.Rows.Clear();

            dgvOutputs.Columns.Clear();
            dgvOutputs.Rows.Clear();

            txtSubmit.Enabled = false;
        }

        // Enable user input
        private void PrepareForQuery()
        {
            dgvInputs.Columns.Clear();
            dgvInputs.Columns.Add("number", "Number");
            dgvInputs.Columns.Add("input", "Input value");

            dgvInputs.Columns["number"].ReadOnly = true;
            dgvInputs.Columns["number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvInputs.Columns["input"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvInputs.Rows.Clear();
            for (int i = 0; i < net.InputNeuronCount; i++)
            {
                dgvInputs.Rows.Add(new string[] { (i + 1).ToString(), "" });
            }

            dgvOutputs.Columns.Clear();
            dgvOutputs.Columns.Add("number", "Number");
            dgvOutputs.Columns.Add("output", "Output value");

            dgvOutputs.Columns["number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvOutputs.Columns["output"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvOutputs.Rows.Clear();
            for (int i = 0; i < net.OutputNeuronCount; i++)
            {
                dgvOutputs.Rows.Add(new string[] { (i + 1).ToString(), "" });
            }

            txtSubmit.Enabled = true;
        }

        // Display a message from the neural net
        private void OnNetMessage(object sender, MessageEventArgs e)
        {
            // Because the neural net runs on its own thread
            // we need to be sure that AddToOutput runs on the main thread
            Invoke((MethodInvoker)(() => AddToOutput(e.Message)));
        }

        // Display a message to the user
        private void AddToOutput(string message)
        {
            lstOutput.Items.Add(message);
            lstOutput.SelectedIndex = lstOutput.Items.Count - 1;
        }

        private void chkLimit_CheckedChanged(object sender, EventArgs e)
        {
            updIterations.Enabled = chkLimit.Checked;
        }

        // Prevent the user from selecting a cell in the output grid
        private void dgvOutputs_SelectionChanged(object sender, EventArgs e)
        {
            dgvOutputs.ClearSelection();
        }

        private void txtSubmit_Click(object sender, EventArgs e)
        {
            double[] inputs = new double[net.InputNeuronCount];

            // Set the inputs
            for (int i = 0; i < net.InputNeuronCount; i++)
            {
                if (dgvInputs[1, i] == null || !net.InputOutputFormatter.TryParse((string)dgvInputs[1, i].Value, out inputs[i]))
                {
                    MessageBox.Show($"Input number {i+1} is not in a valid format", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            // Do the calculation
            double[] outputs = net.Calculate(inputs);

            // Show the outputs
            for (int i = 0; i < net.OutputNeuronCount; i++)
            {
                dgvOutputs[1, i].Value = net.InputOutputFormatter.OutputToString(outputs[i]);
            }
        }
    }
}
