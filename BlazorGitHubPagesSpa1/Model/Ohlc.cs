using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGitHubPagesSpa1.Model
{
    public class Ohlc
    {

        public string Name { get; set; }
        public string Change { get; set; }
        public string PChange { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public Decimal? Open { get; set; }
        public Decimal? High { get; set; }
        public Decimal? Low { get; set; }
        public Decimal? Close { get; set; }
        public Decimal? AdjClose { get; set; }
        public Decimal? Volume { get; set; }
        public Decimal? Value { get; set; }
        public Decimal? ChandelierExit { get; set; }
        public Decimal? EMA5 { get; set; }
        public Decimal? EMA10 { get; set; }
        public Decimal? EMA12 { get; set; }
        public Decimal? EMA26 { get; set; }
        public Decimal? EMA50 { get; set; }
        public Decimal? EMA200 { get; set; }
        public string EMA200_signal { get; set; }
        public Decimal? RSI { get; set; }
        public string RSI_Signal { get; set; }
        public Decimal? MACDHistogram { get; set; }
        public Decimal? MACDLine { get; set; }
        public Decimal? MACDSignal { get; set; }
        public Decimal? SAR { get; set; }
        public string ActionZone { get; set; }
        public string? MA { get; set; }
        public Decimal? PP { get; set; }
        public Decimal? R1 { get; set; }
        public Decimal? S1 { get; set; }
        public Decimal? R2 { get; set; }
        public Decimal? S2 { get; set; }
        public Decimal? R3 { get; set; }
        public Decimal? S3 { get; set; }
        public Decimal? R4 { get; set; }
        public Decimal? S4 { get; set; }
        public Decimal? ZigZag { get; set; }
        public Decimal? PointType { get; set; }
        public Decimal? RetraceHigh { get; set; }
        public Decimal? RetraceLow { get; set; }
        public Decimal? Fractal { get; set; }
        public string Fractal_Marget { get; set; }
        public Decimal? SuperTrend { get; set; }
        public string BuySell_Signal { get; set; }
        public string SuperTrend_Signal { get; set; }

    }
}
