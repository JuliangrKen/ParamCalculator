namespace ParamCalculator
{
    public partial class ParamCalculator : Form
    {
        /// <summary>  ������� ����������� ��� � Time ������� </summary>
        private int _ScreenNumber = 0;
        internal int ScreenNumber
        {
            get => _ScreenNumber;
            set => _ScreenNumber = value > MaxNumber ? (int)MaxNumber : value < 0 ? 0 : _ScreenNumber = value;
        }

        /// <summary>  ������������ �������� ��� ScreenNumber </summary>
        internal uint MaxNumber = 10;

        /// <summary>  ������� ����������� ��� � Time ������� </summary>
        internal uint Number = 10;

        /// <summary> ��� �� ������� ������ ����� ���������� Number � ScreenNumber </summary>
        internal uint Time = 1;

        private System.Windows.Forms.Timer _Timer;

        public ParamCalculator()
        {
            InitializeComponent();

            _Timer = new System.Windows.Forms.Timer();
            _Timer.Tick += AddNumberWhenTimerAlarm;
        }

        #region Buttons

        #region Take/Add Buttons

        private void TakeButton_Click(object sender, EventArgs e) =>
            AddOrTakeScreenNumber(false);

        private void AddButton_Click(object sender, EventArgs e) =>
            AddOrTakeScreenNumber(true);

        private void AddOrTakeScreenNumber(bool isPositiveNumber)
        {
            try
            {
                var num = Convert.ToUInt16(DifferenceNumberTextBox.Text);

                if (num >= MaxNumber)
                    throw new Exception();

                ScreenNumber += isPositiveNumber ? num : -num;
                ScreenNumberLabel.Text = ScreenNumber.ToString();
            }
            catch
            {
                MessageBox.Show("������������ ����!", "������", MessageBoxButtons.OK);
            }
        }

        #endregion

        private bool timerIsWork;

        private void RunTimerButton_Click(object sender, EventArgs e)
        {
            if (timerIsWork)
            {
                timerIsWork = false;
                _Timer.Stop();
            }
            else
            {
                timerIsWork = true;
                _Timer.Interval = (int)Time * 1000;
                _Timer.Start();
            }
        }

        private void AddNumberWhenTimerAlarm(object? myObject, EventArgs myEventArgs)
        {
            ScreenNumber += (int)Number;
            ScreenNumberLabel.Text = ScreenNumber.ToString();
        }

        #endregion

        #region TextBoxes

        private void NumberTextBox_TextChanged(object sender, EventArgs e) =>
            SetTextBoxValue(sender, ref Number);

        private void TimeTextBox_TextChanged(object sender, EventArgs e) =>
            SetTextBoxValue(sender, ref Time);

        private void MaxNumberTextBox_TextChanged(object sender, EventArgs e) =>
            SetTextBoxValue(sender, ref MaxNumber);

        private void SetTextBoxValue(object textBox, ref uint param)
        {
            try
            {
                param = Convert.ToUInt16((textBox as TextBox ?? throw new Exception()).Text);
            }
            catch
            {
                MessageBox.Show("������������ ����!", "������", MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}