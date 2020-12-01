﻿namespace WarehouseSystemAnalyst.Components.Model
{
    public class ColumnDefinition
    {
        public ColumnDefinition()
        {
            DataType = DataType.NotSet;
            Alignment = Alignment.NotSet;
        }

        public string DataField { get; set; }
        public string Caption { get; set; }
        public DataType DataType { get; set; }
        public string Format { get; set; }
        public Alignment Alignment { get; set; }
    }
}