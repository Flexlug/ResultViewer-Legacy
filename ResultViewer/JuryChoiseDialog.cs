// Copyright 2019 Flexlug

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at

// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

// See the License for the specific language governing permissions and
// limitations under the License.

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
	public partial class JuryChoiseDialog : Form
	{
		private int[][] juryChoise;

		private bool CheckIfAvalible(object sender, int index)	   //Проверяет, не занято ли имя конкурсанта. В противном случае возвращает ложь
		{
			if (index == 0)
				return true;

			if (!((onePointComboBox.SelectedIndex == index) && !(sender.Equals(onePointComboBox))))
				if (!((twoPointsComboBox.SelectedIndex == index) && !(sender.Equals(twoPointsComboBox))))
					if (!((threePointsComboBox.SelectedIndex == index) && !(sender.Equals(threePointsComboBox))))
						if (!((fourPointsComboBox.SelectedIndex == index) && !(sender.Equals(fourPointsComboBox))))
							if (!((fivePointsComboBox.SelectedIndex == index) && !(sender.Equals(fivePointsComboBox))))
								if (!((sixPointsComboBox.SelectedIndex == index) && !(sender.Equals(sixPointsComboBox))))
									if (!((sevenPointsComboBox.SelectedIndex == index) && !(sender.Equals(sevenPointsComboBox))))
										if (!((eightPointsComboBox.SelectedIndex == index) && !(sender.Equals(eightPointsComboBox))))
											if (!((tenPointsComboBox.SelectedIndex == index) && !(sender.Equals(tenPointsComboBox))))
												if (!((twelvePointsComboBox.SelectedIndex == index) && !(sender.Equals(twelvePointsComboBox))))
													return true;

			return false;

		}

		public void GetJuryChoise(ref int[][] juryChoise)
		{
			Array.Copy(this.juryChoise, juryChoise, this.juryChoise.Length);
		}


		private void initJuryChoise(int juryCount)
		{
			for (int i = 0; i < juryCount; i++)
			{
				juryChoise[i] = new int[10];
			}
		}

        public void initComboBoxes(string[] juryList, string[] contestList)
        {
            JuryComboBox.Items.AddRange(juryList);
            JuryComboBox.SelectedIndex = 0;
            onePointComboBox.Items.AddRange(contestList);
            onePointComboBox.SelectedIndex = 0;
            twoPointsComboBox.Items.AddRange(contestList);
            twoPointsComboBox.SelectedIndex = 0;
            threePointsComboBox.Items.AddRange(contestList);
            threePointsComboBox.SelectedIndex = 0;
            fourPointsComboBox.Items.AddRange(contestList);
            fourPointsComboBox.SelectedIndex = 0;
            fivePointsComboBox.Items.AddRange(contestList);
            fivePointsComboBox.SelectedIndex = 0;
            sixPointsComboBox.Items.AddRange(contestList);
            sixPointsComboBox.SelectedIndex = 0;
            sevenPointsComboBox.Items.AddRange(contestList);
            sevenPointsComboBox.SelectedIndex = 0;
            eightPointsComboBox.Items.AddRange(contestList);
            eightPointsComboBox.SelectedIndex = 0;
            tenPointsComboBox.Items.AddRange(contestList);
            tenPointsComboBox.SelectedIndex = 0;
            twelvePointsComboBox.Items.AddRange(contestList);
            twelvePointsComboBox.SelectedIndex = 0;
        }

		public JuryChoiseDialog(string[] juryList, string[] contestList)
		{
			InitializeComponent();
			juryChoise = new int[juryList.Length][];
			initJuryChoise(juryList.Length);
            initComboBoxes(juryList, contestList);
		} 

        public JuryChoiseDialog(string[] juryList, string[] contestList, int[][] juryChoise)
        {
            InitializeComponent();
            this.juryChoise = juryChoise;
            initComboBoxes(juryList, contestList);
            JuryComboBox.SelectedIndex = 0;
            JuryComboBox_SelectionChangeCommitted(new ComboBox(), new EventArgs());
        }

		private void onePointComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, onePointComboBox.SelectedIndex))
			{
				onePointComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", onePointComboBox);
			}
			else
			{
				juryChoise[JuryComboBox.SelectedIndex][0] = onePointComboBox.SelectedIndex;
			}
		}

		private void twoPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{ 
			if (!CheckIfAvalible(sender, twoPointsComboBox.SelectedIndex))
			{
				twoPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", twoPointsComboBox);
			}
			else
			{
				juryChoise[JuryComboBox.SelectedIndex][1] = twoPointsComboBox.SelectedIndex;
			}

		}
		private void threePointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, threePointsComboBox.SelectedIndex))
			{
				threePointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", threePointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][2] = threePointsComboBox.SelectedIndex;
			}
		}

		private void fourPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, fourPointsComboBox.SelectedIndex))
			{
				fourPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", fourPointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][3] = fourPointsComboBox.SelectedIndex;
			}	
		}

		private void fivePointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, fivePointsComboBox.SelectedIndex))
			{
				fivePointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", fivePointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][4] = fivePointsComboBox.SelectedIndex;
			}

		}

		private void sixPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, sixPointsComboBox.SelectedIndex))
			{
				sixPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", sixPointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][5] = sixPointsComboBox.SelectedIndex;
			}
		}

		private void sevenPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, sevenPointsComboBox.SelectedIndex))
			{
				sevenPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", sevenPointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][6] = sevenPointsComboBox.SelectedIndex;
			}
		}

		private void eightPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, eightPointsComboBox.SelectedIndex))
			{
				eightPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", eightPointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][7] = eightPointsComboBox.SelectedIndex;
			}

		}

		private void tenPointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, tenPointsComboBox.SelectedIndex))
			{
				tenPointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", tenPointsComboBox);
			}
			{
				juryChoise[JuryComboBox.SelectedIndex][8] = tenPointsComboBox.SelectedIndex;
			}

		}

		private void twelvePointsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!CheckIfAvalible(sender, twelvePointsComboBox.SelectedIndex))
			{
				twelvePointsComboBox.SelectedIndex = 0;
				toolTip1.Show("Данный конкурсант уже выбран", twelvePointsComboBox);
			}

			{
				juryChoise[JuryComboBox.SelectedIndex][9] = twelvePointsComboBox.SelectedIndex;
			}

		}

		private void JuryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			onePointComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][0];
			twoPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][1];
			threePointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][2];
			fourPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][3];
			fivePointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][4];
			sixPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][5];
			sevenPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][6];
			eightPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][7];
			tenPointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][8];
			twelvePointsComboBox.SelectedIndex = juryChoise[JuryComboBox.SelectedIndex][9];
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
