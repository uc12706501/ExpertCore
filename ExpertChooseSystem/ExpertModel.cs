using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHP.Core;

namespace ExpertChooseSystem
{
    //表示专家模型
    public class ExpertModel
    {
        public ExpertModel(params double[] values)
        {
            if (values.Count() >= 14)
            {
                B1 = values[0];
                B2 = values[1];
                B3 = values[2];
                B4 = values[3];
                B5 = values[4];
                B6 = values[5];
                B7 = values[6];
                B8 = values[7];
                B9 = values[8];
                B10 = values[9];
                B11 = values[10];
                B12 = values[11];
                B13 = values[12];
                B14 = values[13];

            }
        }

        public double B1 { get; set; }
        public double B2 { get; set; }
        public double B3 { get; set; }
        public double B4 { get; set; }
        public double B5 { get; set; }
        public double B6 { get; set; }
        public double B7 { get; set; }
        public double B8 { get; set; }
        public double B9 { get; set; }
        public double B10 { get; set; }
        public double B11 { get; set; }
        public double B12 { get; set; }
        public double B13 { get; set; }
        public double B14 { get; set; }
    }
}
