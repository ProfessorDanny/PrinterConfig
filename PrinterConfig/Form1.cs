using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;
using System.Timers;
using System.Net.Sockets;
using System.Net.NetworkInformation;


namespace PrinterConfig
{



    public partial class Form1 : Form
    {

        private const int BufferSize = 1024;
        string ConfigFileName = "";

        string PrinterListFileName = "";

        String buffer = "";
        String Term = "\r\n";
        String InputFileName = @"C:\PrinterConfig\PrinterList.txt";
        //String OutputFileName = @"C:\PrinterConfig\StatusFile.txt";
        String line = "";
        int CountOfPrintersAdded = 0;
        int ProcessedCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadPrinterListButton_Click(object sender, EventArgs e)
        {
            //Open File for Printer list and Read it

            ///Select file Dialog

            OpenFileDialog openPrinterListFile = new OpenFileDialog();

            openPrinterListFile.InitialDirectory = "c:\\PrinterConfig\\";

            openPrinterListFile.Filter = "Printer Config files (*.txt, *.cfg)|*.txt;*.cfg|All files (*.*)|*.*";
            openPrinterListFile.FilterIndex = 0;
            openPrinterListFile.RestoreDirectory = true;

            if (openPrinterListFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string InputFileName = openPrinterListFile.FileName;
            PrinterListFileName = openPrinterListFile.FileName;


            // Open selected file

            System.IO.StreamReader file = new System.IO.StreamReader(InputFileName);

            // Read file last and load it in to PrinterListBox for processing

            while ((line = file.ReadLine()) != null)
            {
                //char[] charArr = line.ToCharArray();
                if (line != "")
                {
                    PrintersListBox.Items.Add(line);
                    CountOfPrintersAdded++;

                    PrintersToProcessLabel.Text = "Printers to Process: " + CountOfPrintersAdded.ToString();
                }
            }
        }

        private void SelectConfigButton_Click(object sender, EventArgs e)
        {
            //Open File for Printer Config and Read it

            ///Select file Dialog

            OpenFileDialog openConfigFile = new OpenFileDialog();

            openConfigFile.InitialDirectory = "c:\\PrinterConfig\\";

            openConfigFile.Filter = "Printer Config files (*.prn, *.cfg)|*.prn;*.cfg|All files (*.*)|*.*";
            openConfigFile.FilterIndex = 0;
            openConfigFile.RestoreDirectory = true;

            if (openConfigFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ConfigFileName = openConfigFile.FileName;

            // Open selected file
            ConfigSendlistBox.Items.Clear();

            System.IO.StreamReader file = new System.IO.StreamReader(ConfigFileName);

            // Read file last and load it in to PrinterListBox for processing

            while ((line = file.ReadLine()) != null)
            {
                //char[] charArr = line.ToCharArray();
                if (line != "")
                {
                    ConfigSendlistBox.Items.Add(line);

                    buffer += line + Term;
                    //counter++;

                    //PrintersToProcessLabel.Text = "Printers to Process: " + counter.ToString();
                }
            }


            Console.WriteLine(buffer);


            //PrintersListBox.Items.Clear();
        }

        private void SendConfigButton_Click(object sender, EventArgs e)
        {
            //SendConfigButton.BackColor = System.Drawing.Color.Green;

            // Get Output Log File ready

            String OutputFileName = @"C:\PrinterConfig\PrinterConfig.LOG";

            StreamWriter LogFile = new StreamWriter(OutputFileName , true);

            string NewRun = "Start of New Run " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss ");
            LogFile.WriteLine("\n\n" + NewRun );


            OutPutListBox.Items.Clear();
            ProcessedCounter = 0;
            PrintersProcessedPercentageBar.Minimum = 0;
            PrintersProcessedPercentageBar.Maximum = CountOfPrintersAdded;
            PrintersProcessedPercentageBar.Value = 0;

            foreach (var item in PrintersListBox.Items)
            {
                System.Threading.Thread.Sleep(10);

                OutPutListBox.Update();
                CompletedLabel.Update();
                PrintersProcessedPercentageBar.Update();

                string datetime = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"); // includes leading zeros
                string HostAddress = item.ToString();

                try
                {
                    Ping PingPrinterTest = new Ping();
                    PingReply reply = PingPrinterTest.Send(HostAddress, 1000);
                    if (reply != null)
                    {
                        SendTCP(ConfigFileName, HostAddress, 9100);

                        OutPutListBox.Items.Add("Pass " + item);
                        LogFile.WriteLine("PASS " + item + "  " + datetime );

                    }
                }
                catch
                {
                    OutPutListBox.Items.Add("FAIL " + item);
                    LogFile.WriteLine("FAIL " + item + "  " + datetime );
                }

                
                ProcessedCounter++;
                CompletedLabel.Text = "Completed: " + ProcessedCounter.ToString();

                PrintersProcessedPercentageBar.Value = ProcessedCounter;

                CompletedLabel.Update();
                PrintersProcessedPercentageBar.Update();
                OutPutListBox.Update();

            } // End of For Each processing

            //Close the file
            LogFile.Close();

        } // End of Send Config Processing Button 

        private void AddPrinterButton_Click(object sender, EventArgs e)
        {
            PrintersListBox.Items.Add(AddPrinterTextBox.Text);
            AddPrinterTextBox.Text = "";
            CountOfPrintersAdded++;
            PrintersToProcessLabel.Text = "Printers to Process: " + CountOfPrintersAdded.ToString();
        }

        private void AddPrinterTextBox_TextChanged(object sender, EventArgs e)
        {

            //AddPrinterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            this.AddPrinterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);

        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (AddPrinterTextBox.Text.Length > 0)
                {
                    PrintersListBox.Items.Add(AddPrinterTextBox.Text);
                    CountOfPrintersAdded++;
                    PrintersToProcessLabel.Text = "Printers to Process: " + CountOfPrintersAdded.ToString();
                }
                AddPrinterTextBox.Text = ""; // Clear the Entry Text Box for next one since it was added to the List Box
            }
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //AddPrinterButton_Click((object)sender, e);

                e.Handled = true;
                PrintersListBox.Items.Add(AddPrinterTextBox.Text);
                CountOfPrintersAdded++;
                PrintersToProcessLabel.Text = "Printers to Process: " + CountOfPrintersAdded.ToString();
                AddPrinterTextBox.Text = "";
            }
            e.Handled = true;
        }

        private void ClearPrinterListButton_Click(object sender, EventArgs e)
        {
            PrintersListBox.Items.Clear();
            CountOfPrintersAdded = 0;
            PrintersToProcessLabel.Text = "Printers to Process: " + CountOfPrintersAdded.ToString();
        }

        private void ConfigSendlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        public void SendTCP(string FileToSend, string IPA, Int32 PortN) // M = file path   IPA host name or IP      PortN port 9100 for us
        {
            byte[] SendingBuffer = null;
            TcpClient client = null;
            //lblStatus.Text = "";
            NetworkStream netstream = null;

            try
            {
                client = new TcpClient(IPA, PortN);
                //lblStatus.Text = "Connected to the Server...\n";
                netstream = client.GetStream();


                FileStream Fs = new FileStream(FileToSend, FileMode.Open, FileAccess.Read);

                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                //progressBar1.Maximum = NoOfPackets;
                int TotalLength = (int)Fs.Length, CurrentPacketLength, PacketCounter = 0;


                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = TotalLength;
                    }

                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    // if (progressBar1.Value >= progressBar1.Maximum)
                    //     progressBar1.Value = progressBar1.Minimum;
                    // progressBar1.PerformStep();
                }

                // lblStatus.Text = lblStatus.Text + "Sent " + Fs.Length.ToString() + " bytes to the server";
                Fs.Close();
            }
            catch (Exception ex)
            {
                OutPutListBox.Items.Add("FAIL " + IPA + "  " + ex);
            }
            finally
            {
                netstream.Close();
                client.Close();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }










}

