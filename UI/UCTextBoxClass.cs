using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GasFormsApp.UI
{
    public class UCTextBoxClass : UserControl
    {
        private TextBox _textBox;

        public UCTextBoxClass()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;

            _textBox = new TextBox();
            _textBox.BorderStyle = BorderStyle.None;
            _textBox.Multiline = false;
            _textBox.BackColor = Color.White; // 虽然白色，但我们用绘制覆盖它
            _textBox.ForeColor = Color.Black;
            _textBox.Location = new Point(10, 6);
            _textBox.Width = this.Width - 20;

            _textBox.TextChanged += (s, e) => this.OnTextChanged(e);
            this.Controls.Add(_textBox);

            this.Resize += (s, e) => AdjustTextBox();
            this.Size = new Size(200, 30);
        }

        private void AdjustTextBox()
        {
            _textBox.Width = this.Width - 20;
            _textBox.Height = this.Height - 12;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1);

            using (GraphicsPath path = GetRoundRectPath(rect, 10))
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightSkyBlue, Color.DodgerBlue, LinearGradientMode.Vertical))
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        // 可暴露 Text 属性给外部访问
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public TextBox InnerTextBox => _textBox; // 方便直接访问内部TextBox

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UCTextBoxClass
            // 
            this.Name = "UCTextBoxClass";
            this.Load += new System.EventHandler(this.UCTextBoxClass_Load);
            this.ResumeLayout(false);

        }

        private void UCTextBoxClass_Load(object sender, EventArgs e)
        {

        }
    }

}
