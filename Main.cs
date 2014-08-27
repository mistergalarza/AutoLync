using AutoLync.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoLync
{
    public partial class Main : Form
    {
        Lyncy lync;

        public Main()
        {
            InitializeComponent();
            lync = new Lyncy();
            lync.Start();
        }

        
    }
}
