using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class ResourceBackgroundWorker : BackgroundWorker
    {
        public ToolStripProgressBar progressBar;
        public ToolStripStatusLabel progressLabel; 
    }
}
