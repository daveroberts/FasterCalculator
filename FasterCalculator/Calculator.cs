using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FasterCalculator
{
    public partial class Calculator : Form
    {
		private bool _prepopAnswer = false;
        private double _lastAnswer;
		private int _currentIndex = -1;
        private List<string> _lastExpressions = new List<string>();
        public Calculator()
        {
            InitializeComponent();
        }
		private void txtEntry_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				e.Handled = true;
			}
		}
		private void txtEntry_KeyUp(object sender, KeyEventArgs e)
        {
			e.Handled = true;
			if (e.KeyCode == Keys.F1)
			{
				MessageBox.Show("Faster Calculator\nWritten by Dave Roberts\ndave.a.roberts@gmail.com\nDBAD License 2010");
				
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (_lastExpressions.Count > 0)
				{
					_currentIndex++;
					if (_currentIndex > _lastExpressions.Count - 1)
					{
						_currentIndex = _lastExpressions.Count - 1;
					}
					txtEntry.Text = _lastExpressions[_currentIndex];
					txtEntry.SelectionStart = txtEntry.Text.Length;
				}
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (_lastExpressions.Count > 0)
				{
					_currentIndex--;
					if (_currentIndex < 0)
					{
						_currentIndex = 0;
					}
					txtEntry.Text = _lastExpressions[_currentIndex];
					txtEntry.SelectionStart = txtEntry.Text.Length;
				}
			}
			e.Handled = false;
        }
        private void DisplayAnswer(string formula, string answer, bool hadError)
        {
            txtHistory.SelectionStart = txtHistory.Text.Length;
            txtHistory.SelectionFont = new Font("Arial", (float)12);
            txtHistory.SelectionColor = Color.Gray;
            txtHistory.SelectedText += formula + "\n";
            txtHistory.SelectionFont = new Font("Arial", (float)13);
			if (hadError)
			{
				txtHistory.SelectionColor = Color.Red;
			}
			else
			{
				txtHistory.SelectionColor = Color.Black;
			}
            txtHistory.SelectedText += answer + "\n";
            txtHistory.ScrollToCaret();
        }
        private void txtEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the user pressed enter (enter = 13)
            if (e.KeyChar == 13)
            {
                e.Handled = true;
				_currentIndex = -1;
				if (txtEntry.Text == "") {
					if (_lastExpressions.Count > 0) {
						txtEntry.Text = _lastExpressions[0];
					}
				}
				string strInput = txtEntry.Text;
				_lastExpressions.Insert(0, strInput);
				if (strInput.Contains("ans")) { strInput = strInput.Replace("ans", _lastAnswer.ToString()); }
				string strResult;
				bool hadError = false;
				_prepopAnswer = true;
				try
				{
					double result = BetterMaths.DoParse(strInput);
					_lastAnswer = result;
					result = Math.Round(result, 2);
					strResult = addCommas(result);
				}
				catch (Exception ex)
				{
					hadError = true;
					strResult = ex.Message;
				}
				DisplayAnswer(txtEntry.Text, strResult, hadError);
				txtEntry.Text = "";
            }
            else if (e.KeyChar == '^' || e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '%')
            {
				if (_prepopAnswer && txtEntry.Text == "")
                {
					_prepopAnswer = false;
                    txtEntry.Text = "ans" + e.KeyChar;
                    txtEntry.SelectionStart = txtEntry.Text.Length;
                    e.Handled = true;
                }
            }
        }
		private string addCommas(double result)
		{
			if (Double.IsInfinity(result) || Double.IsNaN(result))
			{
				return result.ToString();
			}
			string strResult = result.ToString();
			if (result >= 10000)
			{
				int dotPosition = strResult.IndexOf(".");
				if (dotPosition == -1)
				{
					dotPosition = strResult.Length;
				}
				dotPosition -= 3;
				while (dotPosition >= 1)
				{
					strResult = strResult.Insert(dotPosition, ",");
					dotPosition -= 3;
				}
			}
			return strResult;
		}
    }
}
