﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyTest
{
    public class GraphNode
    {
        public int Value { get; set; }

        public string SValue { get; set; }
        public bool Visited { get; set; }
        public List<GraphNode> Childern { get; set; }

        public GraphNode()
        {
            Childern = new List<GraphNode>();
        }
    }
}
