﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utils
{
    public class TreeItemx
    {
        public string Name;
        public int Level;
        public int Id;

        public TreeItemx(string name, int level, int id)
        {
            this.Name = name;
            this.Level = level;
            this.Id = id;
        }
    }

}
