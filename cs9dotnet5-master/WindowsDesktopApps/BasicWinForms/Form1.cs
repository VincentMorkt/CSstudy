﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegacyWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGoToChristmas_Click(object sender, EventArgs e)
        {
            DateTime christmas = new DateTime(2020, 12, 25);
            monthCalendar1.SelectionStart = christmas;
            monthCalendar1.SelectionEnd = christmas;
        }
    }
}
