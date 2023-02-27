using System;
using System.Windows.Forms;
using System.Threading;
using FUTEK_USB_DLL;
using Zaber.Motion;
using Zaber.Motion.Ascii;

namespace LoadCell_OwnProgram
{
    public partial class MainForm : Form
    {
        private Thread _calculationThread;
        private IntPtr DeviceHandle;
        private int DeviceStatus;
        private string t_Off_Val;
        private string t_Full_Val;
        private string t_FullLoad_Val;
        private string t_Deci_Point;
        private string t_NormData;
        private string t_UnitCode;
        public Int32 UnitCode;
        public Int32 OffsetVal;
        public Int32 FullVal;
        public Int32 FullLoadVal;
        public Int32 DeciPoint;
        public Int32 NormalVal;
        public Double CalcVal;

        public MainForm()
        {
            InitializeComponent();
        }

        //This is to calculate the laod cell force
        private void Calculate()
        {
            FUTEK_USB_DLL.USB_DLL futek = new FUTEK_USB_DLL.USB_DLL();
            

            // Connect to the device
            futek.Open_Device_Connection("538827");
            DeviceStatus = futek.DeviceStatus;
            if (DeviceStatus == 0)
            {
                MessageBox.Show("The device is connected");
            }
            DeviceHandle = futek.DeviceHandle;

            while (true)
            {
                // Getting the required values
                t_Off_Val = futek.Get_Offset_Value(DeviceHandle);
                OffsetVal = Int32.Parse(t_Off_Val);
                t_Full_Val = futek.Get_Fullscale_Value(DeviceHandle);
                FullVal = Int32.Parse(t_Full_Val);
                t_FullLoad_Val = futek.Get_Fullscale_Load(DeviceHandle);
                FullLoadVal = Int32.Parse(t_FullLoad_Val);
                t_Deci_Point = futek.Get_Decimal_Point(DeviceHandle);
                DeciPoint = Int32.Parse(t_Deci_Point);
                t_NormData = futek.Normal_Data_Request(DeviceHandle);
                NormalVal = Int32.Parse(t_NormData);
                t_UnitCode = futek.Get_Unit_Code(DeviceHandle);
                UnitCode = Int32.Parse(t_UnitCode);

                // Calculate the value
                CalcVal = (double)(NormalVal - OffsetVal) / (FullVal - OffsetVal) * FullLoadVal / Math.Pow(10, DeciPoint);

                // Display the result
                if (InvokeRequired)
                {
                    Invoke(new Action(() => ResultsLab.Text = CalcVal.ToString("n2")));
                }
                else
                {
                    ResultsLab.Text = CalcVal.ToString("n2");
                }

                // Wait for a second before calculating again
                Thread.Sleep(1000);
            }
        }

        //This is to move the linear actuator
        private void LinearActuator()
        {
            using (var connection = Connection.OpenSerialPort("COM5"))
            {
                connection.EnableAlerts();

                var deviceList = connection.DetectDevices();
                Console.WriteLine($"Found {deviceList.Length} devices.");

                var device = deviceList[0];

                var axis = device.GetAxis(1);
                if (!axis.IsHomed())
                {
                    axis.Home();
                }

                // Move to 10mm
                axis.MoveAbsolute(10, Units.Length_Millimetres);

                // Move by an additional 5mm
                axis.MoveRelative(5, Units.Length_Millimetres);
            }
        }


        //This start the load cell calculation
        private void button3_Click(object sender, EventArgs e)
        {
            // Disable the start button
            button3.Enabled = false;

            // Start the calculation thread
            _calculationThread = new Thread(Calculate);
            _calculationThread.Start();
            MessageBox.Show("About to Start Calculations!");

            //Moving the linear actuator
            MessageBox.Show("Running the linear Actuator");
            LinearActuator();
        }
        //This stops the load cell calculation
        private void button4_Click(object sender, EventArgs e)
        {
            if (_calculationThread != null && _calculationThread.IsAlive)
            {
                _calculationThread.Abort();
            }

            // Enable the start button
            button3.Enabled = true;
            this.Close();
            Application.Exit();
        }
    }
}
