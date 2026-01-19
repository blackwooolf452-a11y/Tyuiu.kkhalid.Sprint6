namespace Tyuiu.Kkhalid.Sprint6.Task5.V22
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // گروه‌باکس ورودی
            groupBoxInput = new GroupBox();
            buttonLoad = new Button();
            labelFileInfo = new Label();

            // DataGridView
            groupBoxGrid = new GroupBox();
            dataGridViewNums = new DataGridView();

            // نمودار
            chartNums = new Chart();

            // گروه‌باکس نتایج
            groupBoxResult = new GroupBox();
            textBoxResult = new TextBox();

            // دکمه‌ها
            buttonSave = new Button();
            buttonInfo = new Button();

            // برچسب وضعیت
            labelStatus = new Label();

            // ... کدهای طراحی فرم
        }

        private GroupBox groupBoxInput;
        private Button buttonLoad;
        private Label labelFileInfo;
        private GroupBox groupBoxGrid;
        private DataGridView dataGridViewNums;
        private Chart chartNums;
        private GroupBox groupBoxResult;
        private TextBox textBoxResult;
        private Button buttonSave;
        private Button buttonInfo;
        private Label labelStatus;
    }
}