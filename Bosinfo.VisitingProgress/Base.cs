using Bosinfo.VisitingProgress.UtilityTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bosinfo.VisitingProgress
{
    public partial class Base : Form
    {
        public static Log log = new Log();

        public bool ListenerSwitchStatus;

        public Base()
        {
            InitializeComponent();
        }
    }
}
