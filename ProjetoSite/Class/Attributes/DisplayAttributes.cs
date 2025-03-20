﻿using System;
namespace ProjetoSite.Class.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayAttributes : Attribute
    {
        public bool PrimaryKey { get; }
        public string Name { get; }
        public int Column { get; }
        public DisplayAttributes(bool primaryKey, string name, int column)
        {
            PrimaryKey = primaryKey;
            Name = name;
            Column = column;
        }
    }
}
