namespace ParamCalculator
{
    public partial class ParamCalculator : Form
    {
        /// <summary>  ������� ����������� ��� � Time ������� </summary>
        internal uint ScreenNumber = 0;

        /// <summary>  ������������ �������� ��� ScreenNumber </summary>
        internal uint MaxNumber = 10;

        /// <summary>  ������� ����������� ��� � Time ������� </summary>
        internal uint Number = 10;

        /// <summary>  ������� �������� ��� ������� �� ScreenNumber </summary>
        internal uint DifferenceNumber = 0;

        /// <summary> ��� �� ������� ������ ����� ���������� Number � ScreenNumber </summary>
        internal uint Time = 10;

        public ParamCalculator()
        {
            InitializeComponent();
        }
    }
}