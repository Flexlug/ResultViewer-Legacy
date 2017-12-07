using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultViewer
{
    public partial class ContestDataDialog : Form
    {
        private void JuryCountLabelRefresh()
        {
            JuryCountLabel.Text = $"Жюри: (Кол - во: {JuryListbox.Items.Count})";
        }

        private void ContCountLabelRefresh()
        {
            ContCountLabel.Text = $"Конкурсантов: (Кол - во: {ContestListbox.Items.Count})";
        }

        public ContestDataDialog()
        {
            InitializeComponent();
            JuryCountLabelRefresh();
            ContCountLabelRefresh();
			ContRemoveButton.Enabled = true;
			JuryRemoveButton.Enabled = true;
        }

		public ContestDataDialog(string[] juryList, string[] contestList) : this()
		{
			JuryListbox.Items.AddRange(juryList);
			ContestListbox.Items.AddRange(contestList);
			JuryCountLabelRefresh();
			ContCountLabelRefresh();
		}

        public int GetJuryCount() => JuryListbox.Items.Count;

        public int GetContestCount() => ContestListbox.Items.Count;

        public void GetJuryList(ref string[] juryList)
        {
            for (int i = 0; i < JuryListbox.Items.Count; i++)
            {
                juryList[i] = (string)JuryListbox.Items[i];
            }
        }

        public void GetContestList(ref string[] contestList)
        {
            for (int i = 0; i < ContestListbox.Items.Count; i++)
            {
                contestList[i] = (string)ContestListbox.Items[i];
            }
        }

        private bool CheckData() // Проверка введённых данных
        {
            if ((JuryListbox.Items.Count != 0) && (ContestListbox.Items.Count != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OkButton_Click(object sender, EventArgs e) // Нажатие кнопки ОК. Производится проверка введённых значений
        {
            if (CheckData())
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
                MessageBox.Show("Не все поля заполнены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelButton_Click(object sender, EventArgs e) // Нажатие кнопки Отмена. Проверка введённых значений НЕ ПРОИЗВОДИТСЯ
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }
             






        private void JuryFIOTextbox_TextChanged(object sender, EventArgs e)
        {
            if (JuryFIOTextbox.Text != "")
            {
                JuryAddButton.Enabled = true;
            }
            else
            {
                JuryAddButton.Enabled = false;
                return;
            }

            if (JuryListbox.Items.Count >= 30)
            {
                JuryAddButton.Enabled = false;
                return;
            }
            else
            {
                JuryAddButton.Enabled = true;
            }
        }   

        private void JuryAddButton_Click(object sender, EventArgs e)
        {
            JuryListbox.BeginUpdate();
            JuryListbox.Items.Add(JuryFIOTextbox.Text);
            JuryListbox.EndUpdate();
            JuryFIOTextbox.Text = "";
            JuryRemoveButton.Enabled = true;
            JuryCountLabelRefresh();
        }

        private void JuryRemoveButton_Click(object sender, EventArgs e)
        {
            JuryListbox.BeginUpdate();
            JuryListbox.Items.Remove(JuryListbox.SelectedItem);
            JuryListbox.EndUpdate(); 
            if (JuryListbox.Items.Count == 0)
            {
                JuryRemoveButton.Enabled = false;
            }
            if ((JuryListbox.Items.Count < 30) && (JuryAddButton.Enabled == false) && (JuryFIOTextbox.Text != ""))
            {
                JuryAddButton.Enabled = true;
            }
            JuryCountLabelRefresh();
        }
       
        private void ContFIOTextbox_TextChanged(object sender, EventArgs e)
        {
            if (ContFIOTextbox.Text != "")
            {
                ContAddButton.Enabled = true;
            }
            else
            {
                ContAddButton.Enabled = false;
                return;
            }

            if (ContestListbox.Items.Count >= 30)
            {
                ContAddButton.Enabled = false;
                return;
            }
            else
            {
                ContAddButton.Enabled = true;
            }
        }

        private void ContAddButton_Click(object sender, EventArgs e)
        {
            ContestListbox.BeginUpdate();
            ContestListbox.Items.Add(ContFIOTextbox.Text);
            ContestListbox.EndUpdate();
            ContFIOTextbox.Text = "";
            ContRemoveButton.Enabled = true;
            ContCountLabelRefresh();
        }

        private void ContRemoveButton_Click(object sender, EventArgs e)
        {
            ContestListbox.BeginUpdate();
            ContestListbox.Items.Remove(ContestListbox.SelectedItem);
            ContestListbox.EndUpdate();
            if (ContestListbox.Items.Count == 0)
            {
                ContRemoveButton.Enabled = false;
            }
            if ((ContestListbox.Items.Count < 30) && (ContAddButton.Enabled == false) && (ContFIOTextbox.Text != ""))
            {
                ContAddButton.Enabled = true;
            }
            ContCountLabelRefresh();
        }

		private void JuryFIOTextbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				//после нажатия клавиши Enter активируем кнопку OK
				JuryAddButton.Select();
				//перехватываем нажатие клавиши, удаляем системный звук
				e.Handled = true;
			}
		}

		private void ContFIOTextbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				//после нажатия клавиши Enter активируем кнопку OK
				ContAddButton.Select();
				//перехватываем нажатие клавиши, удаляем системный звук
				e.Handled = true;
			}
		}
	}
}

