﻿// Copyright 2019 Flexlug

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
    public partial class ColorManager : Form
    {
        Graphics g;
        MVSettings mvs;

        public ColorManager(Color cl)
        {
            InitializeComponent();

            RedTrackBar.Value = cl.R;
            RedTrackBar.Refresh();

            GreenTrackBar.Value = cl.G;
            GreenTrackBar.Refresh();

            BlueTrackBar.Value = cl.B;
            BlueTrackBar.Refresh();

            RedTrackBar.ValueChanged += new System.EventHandler(this.RedTrackBar_ValueChanged);
            GreenTrackBar.ValueChanged += new System.EventHandler(this.GreenTrackBar_ValueChanged);
            BlueTrackBar.ValueChanged += new System.EventHandler(this.BlueTrackBar_ValueChanged);

            ShowColorBox.Image = new Bitmap(ShowColorBox.Width, ShowColorBox.Height);
            g = Graphics.FromImage(ShowColorBox.Image);
            DrawColor();

        }

        private void DrawColor()
        {
            SolidBrush sb = new SolidBrush(Color.FromArgb(255,
                                                          RedTrackBar.Value, 
                                                          GreenTrackBar.Value, 
                                                          BlueTrackBar.Value));

            Rectangle rect = new Rectangle(new Point(0, 0), 
                                           new Size(ShowColorBox.Width, ShowColorBox.Height));

            g.FillRectangle(sb, rect);
            ShowColorBox.Invalidate();
        }

        private void RedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            DrawColor();
        }

        private void GreenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            DrawColor();
        }

        private void BlueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            DrawColor();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void ConfirmChanges(ref Color cl)
        {
            cl = Color.FromArgb(255, RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }
    }
}
