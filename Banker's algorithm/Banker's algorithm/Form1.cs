using System.ComponentModel;
using System.Text;

namespace Banker_s_algorithm
{
    public partial class Form1 : Form
    {
        private Label processLabel, resourceLabel, resourceTotalLabel, allocLabel, maxLabel, availLabel, resultLabel, needMatrixLabel,processreqLabel, ResourceLabel;
        private TextBox processTextBox, resourceTextBox, resourceTotalTextBox, allocTextBox, maxTextBox, availTextBox, resultTextBox, needMatrixTextBox, processreqTextBox, ResourceTextbox;
        private Button runButton,resetButton;
        public Form1()
        {
            InitializeComponent();
            
            // Set up the form
            this.Text = "Banker's Algorithm";
            this.ClientSize = new Size(1080, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create the input labels and text boxes
            processLabel = new Label();
            processLabel.Text = "Number of Processes:";
            processLabel.AutoSize = true;
            processLabel.Location = new Point(20, 20);
            this.Controls.Add(processLabel);

            processTextBox = new TextBox();
            processTextBox.Location = new Point(200, 20);
            this.Controls.Add(processTextBox);

            resourceLabel = new Label();
            resourceLabel.Text = "Number of Resources:";
            resourceLabel.AutoSize = true;
            resourceLabel.Location = new Point(20, 60);
            this.Controls.Add(resourceLabel);

            resourceTextBox = new TextBox();
            resourceTextBox.Location = new Point(200, 60);
            this.Controls.Add(resourceTextBox);

            resourceTotalLabel = new Label();
            resourceTotalLabel.Text = "Total number of \neach resource :";
            resourceTotalLabel.AutoSize = true;
            resourceTotalLabel.Location = new Point(20, 100);
            this.Controls.Add(resourceTotalLabel);

            resourceTotalTextBox = new TextBox();
            resourceTotalTextBox.Location = new Point(200, 100);
            this.Controls.Add(resourceTotalTextBox);

            allocLabel = new Label();
            allocLabel.Text = "Allocation Matrix :";
            allocLabel.AutoSize = true;
            allocLabel.Location = new Point(20, 300);
            this.Controls.Add(allocLabel);

            allocTextBox = new TextBox();
            allocTextBox.Location = new Point(200, 300);
            allocTextBox.Multiline = true;
            allocTextBox.Size = new Size(150, 60);
            this.Controls.Add(allocTextBox);

            maxLabel = new Label();
            maxLabel.Text = "Maximum Matrix :";
            maxLabel.AutoSize = true;
            maxLabel.Location = new Point(550, 300);
            this.Controls.Add(maxLabel);

            maxTextBox = new TextBox();
            maxTextBox.Location = new Point(700, 300);
            maxTextBox.Multiline = true;
            maxTextBox.Size = new Size(150, 60);
            this.Controls.Add(maxTextBox);

            availLabel = new Label();
            availLabel.Text = "Available Resources:";
            availLabel.AutoSize = true;
            availLabel.Location = new Point(20, 160);
            this.Controls.Add(availLabel);

            availTextBox = new TextBox();
            availTextBox.Location = new Point(200, 160);
            this.Controls.Add(availTextBox);



            needMatrixLabel = new Label();
            needMatrixLabel.Text = "Need Matrix :";
            needMatrixLabel.AutoSize = true;
            needMatrixLabel.Location = new Point(20, 700);
            this.Controls.Add(needMatrixLabel);

            needMatrixTextBox = new TextBox();
            needMatrixTextBox.Location = new Point(200, 700);
            needMatrixTextBox.Multiline = true;
            needMatrixTextBox.AutoSize = true;
            needMatrixTextBox.ReadOnly = true;
            needMatrixTextBox.Enabled = false;
            needMatrixTextBox.Size = new Size(150, 60);
            this.Controls.Add(needMatrixTextBox);

            // Create the result label and text box
            resultLabel = new Label();
            resultLabel.Text = "Safe Sequence:";
            resultLabel.Location = new Point(500, 60);
            this.Controls.Add(resultLabel);

            resultTextBox = new TextBox();
            resultTextBox.Location = new Point(630, 60);
            resultTextBox.Enabled = false;
            resultTextBox.ReadOnly = true;
            resultTextBox.AutoSize= true;
            this.Controls.Add(resultTextBox);

            ////req process
            processreqLabel = new Label();
            processreqLabel.Text = "Req Processes number :";
            processreqLabel.AutoSize = true;
            processreqLabel.Location = new Point(20, 200);
            this.Controls.Add(processreqLabel);

            processreqTextBox = new TextBox();
            processreqTextBox.Location = new Point(200, 200);
            this.Controls.Add(processreqTextBox);

            /// Res req

            ResourceLabel = new Label();
            ResourceLabel.Text = "Req Resources\n ex. 1 0 8 (each need form each resoruce) :";
            ResourceLabel.AutoSize = true;
            ResourceLabel.Location = new Point(20, 240);
            this.Controls.Add(ResourceLabel);

            ResourceTextbox = new TextBox();
            ResourceTextbox.Location = new Point(400, 240);
            this.Controls.Add(ResourceTextbox);

            // Create the run button
            runButton = new Button();
            runButton.Text = "Run";
            runButton.AutoSize = true;
            runButton.Location = new Point(900, 100);
            runButton.Size = new Size(100, 50);
            runButton.Click += new EventHandler(RunButtonClick);
            this.Controls.Add(runButton);

            // Create the reset button
            resetButton = new Button();
            resetButton.Text = "Reset";
            resetButton.AutoSize = true;
            resetButton.Location = new Point(900, 150);
            resetButton.Size = new Size(100, 50);
            resetButton.Click += new EventHandler(resetButton_Click);
            this.Controls.Add(resetButton);

        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            // Reset all text boxes to empty strings
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
                if(textBox.Enabled==true)
                    textBox.BackColor = Color.White;
                else
                    textBox.BackColor = SystemColors.Control; 
            }
            allocTextBox.Size = new Size(150, 60);
            resultTextBox.Font = allocTextBox.Font;

        }
        private void RunButtonClick(object sender, EventArgs e)
        {
            
            // Parse the input values
            int n = int.Parse(processTextBox.Text);
            int m = int.Parse(resourceTextBox.Text);
            int pro_n=int.Parse(processreqTextBox.Text);
            List<List<int>> alloc = ParseMatrix(allocTextBox.Text, n, m);
            List<List<int>> max = ParseMatrix(maxTextBox.Text, n, m);
            List<int> avail = ParseVector(availTextBox.Text, m);
            List<int> process_req = ParseVector(ResourceTextbox.Text, m);

            
            // Display a "waiting" message box
            MessageBox.Show("Please wait...", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Task.Delay(5000);
            MessageBox.Show("Operation complete!", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

            // Run the Banker's Algorithm
            List<int> seq = BankersAlgorithm(n, m, alloc, max, avail,process_req,pro_n);

            // Display the safe sequence (or an error message)
            if (seq == null)
            {
                //resultTextBox.ForeColor = Color.Red;
                resultTextBox.BackColor = Color.Red;
                resultTextBox.Font = new Font(resultTextBox.Font, FontStyle.Bold);
                resultTextBox.Text = "Error: System is in an unsafe state!";
                 resultTextBox.Width=10+resultTextBox.Text.Length*7;
                
            }
            else
            {
                string seqString = "";
                foreach (int i in seq)
                {
                    seqString += "P" + i + " -> ";
                }
                seqString = seqString.Substring(0, seqString.Length - 4); /// TO REMOVE THE EXTRA ->
                resultTextBox.Text = seqString;
                resultTextBox.Width = 10+resultTextBox.Text.Length * 7;
                resultTextBox.BackColor = Color.LightGreen;
            }
        }

        private List<int> BankersAlgorithm(int n, int m, List<List<int>> alloc, List<List<int>> max, List<int> avail, List<int> process_req,int pro_n)
        {
            /// add the needed resoruces in currenlty aloc and - it from the aval
            /// 

            for (int j = 0; j < m; j++)
            {
                if (avail[j] == 0 && process_req[j] > 0)
                    return null; // Unsafe state
                avail[j]-=process_req[j];
                alloc[pro_n-1][j]+=process_req[j];

            }
            availTextBox.Text = string.Join(" ",avail);
            WriteDataToTextBox(alloc, allocTextBox);

            // Initialize the need matrix
            List<List<int>> need = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                need.Add(new List<int>(m));
                for (int j = 0; j < m; j++)
                {
                    need[i].Add(max[i][j] - alloc[i][j]);
                }
            }

            ///updating the text box
            WriteDataToTextBox(need, needMatrixTextBox);

            // Initialize the finish and work vectors
            List<int> finish = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                finish.Add(0);
            }
            List<int> work = new List<int>(avail);

            // Find a safe sequence if not will return null 
            List<int> seq = new List<int>();
            int count = 0;
            while (count < n)
            {
                bool found = false;
                for (int i = 0; i < n; i++)
                {
                    if (finish[i] == 0)
                    {
                        bool canRun = true;
                        for (int j = 0; j < m; j++)
                        {
                            if (need[i][j] > work[j])
                            {
                                canRun = false;
                                break;
                            }
                        }
                        if (canRun)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                work[j] += alloc[i][j];
                            }
                            finish[i] = 1;
                            seq.Add(i);
                            count++;
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    return null; // Unsafe state
                }
            }
            return seq; // Safe state
        }

        private List<List<int>> ParseMatrix(string text, int rows, int cols)
        {
            List<List<int>> matrix = new List<List<int>>(rows);
            string[] lines = text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length != rows)
            {
                throw new ArgumentException("Invalid number of rows in matrix");
            }
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>(cols));
                string[] values = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != cols)
                {
                    throw new ArgumentException("Invalid number of columns in matrix");
                }
                for (int j = 0; j < cols; j++)
                {
                    matrix[i].Add(int.Parse(values[j]));
                }
            }
            return matrix;
        }

        private List<int> ParseVector(string text, int size)
        {
            List<int> vector = new List<int>(size);
            string[] values = text.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != size)
            {
                throw new ArgumentException("Invalid size of vector");
            }
            for (int i = 0; i < size; i++)
            {
                vector.Add(int.Parse(values[i]));
            }
            return vector;
        }

        private void WriteDataToTextBox(List<List<int>> data, TextBox textBox)
        {
            int numRows = data.Count;
            int numCols = data[0].Count;

            // Create a StringBuilder to store the matrix data
            StringBuilder sb = new StringBuilder();

            // Loop through the rows and columns of the data list
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    // Append the data to the StringBuilder in matrix format
                    sb.AppendFormat("{0,10}", data[i][j]);
                }
                sb.AppendLine(); // Add a newline after each row
            }

            // Set the text of the textbox to the matrix data
            textBox.Text = sb.ToString();
            //textBox.Enabled = false;
            textBox.BackColor = Color.LightBlue;
            textBox.Width = 80*numCols;
            textBox.Height = 80 * numRows;
        }

    }
}