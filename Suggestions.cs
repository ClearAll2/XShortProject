﻿using System;

namespace XShort
{
    class Suggestions
    {
        public string loc;
        public int count;
        public DateTime lasttime;

        public Suggestions(string _loc, int _count, DateTime _lastime)
        {
            loc = _loc;
            count = _count;
            lasttime = _lastime;
        }
    }
}
