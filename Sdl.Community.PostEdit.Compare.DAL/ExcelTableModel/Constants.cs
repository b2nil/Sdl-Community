﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.PostEdit.Compare.DAL.ExcelTableModel
{
	public static class Constants
	{
		#region Post edit modifications analysis table
		public static string ExactMatch { get { return "100%"; } }
		public static string Segments { get { return "Segments"; } }
		public static string Words { get { return "Words"; } }
		public static string Characters { get { return "Characters"; } }
		public static string Percent { get { return "Percent"; } }
		public static string Total { get { return "Total"; } }
		public static string Fuzzy99 { get { return "95% - 99%"; } }
		public static string Fuzzy94 { get { return "85% - 94%"; } }
		public static string Fuzzy84 { get { return "75% - 84%"; } }
		public static string Fuzzy74 { get { return "50% - 74%"; } }
		public static string New { get { return "New"; } }
		public static string AnalysisBand { get { return "Analysis Band"; } }
		#endregion

		#region TERp Analysis table
		public static string Range { get { return "Range"; } }
		public static string RefWords { get { return "Ref.Words"; } }
		public static string Errors { get { return "Errors"; } }
		public static string Ins { get { return "Ins"; } }
		public static string Del { get { return "Del"; } }
		public static string Sub { get { return "Sub"; } }
		public static string Shft { get { return "Shft"; } }
		public static string Terp00 { get { return "0%"; } }
		public static string Terp01 { get { return "01% - 05%"; } }
		public static string Terp06 { get { return "06% - 09%"; } }
		public static string Terp10 { get { return "10% - 19%"; } }
		public static string Terp20 { get { return "20% - 29%"; } }
		public static string Terp30 { get { return "30% - 39%"; } }
		public static string Terp40 { get { return "40% - 49%"; } }
		public static string Terp50 { get { return "50% +"; } }
		#endregion
	}
}
