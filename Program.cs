using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	class Set
	{
		private string[] _arr;

		public Set()
		{
			this._arr = new string[0];
		}

		public Set(int size)
		{
			this._arr = new string[size];
		}

		public string this[int index]
		{
			get
			{
				string res = "";
				try
				{

					res = this._arr[index];
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Error: array doesn't have " + index + " element!");
				}

				return res;
			}
			set
			{
				if (index > -1 && index < this._arr.Length)
					this._arr[index] = value;
			}
		}

		public int Count
		{
			get { return this._arr.Length; }
		}

		public static Set operator -(Set arr, string s)
		{
			Set res = new Set();
			bool check = false;
			if (arr.Count > 0)
				for (int i = 0; i < arr.Count; i++)
					if (arr[i] == s && !check)
					{
						res = new Set(arr.Count - 1);
						for (int j = 0, k = 0; j < res.Count; j++, k++)
						{
							if (arr[k] != s)
								res[j] = arr[k];
							else
								--j;
						}
						check = true;
					}
			return res;
		}

		public static Set operator %(Set arr1, Set arr2)
		{
			Set res = new Set();
			int index = 0;
			int num;
			if (arr1.Count > arr2.Count)
				num = arr2.Count;
			else
				num = arr1.Count;
			string[] str = new string[num];
			for (int i = 0; i < num; i++)
				if (arr1[i] == arr2[i])
				{
					str[index] = arr1[i];
					index++;
				}
			res = new Set(index);
			for (int i = 0; i < index; i++)
				res[i] = str[i];
			return res;
		}

		public static Set operator +(Set arr, string s)
		{
			Set res = new Set();
			res = new Set(arr.Count + 1);
			for (int i = 0; i < arr.Count; i++)
				res[i] = arr[i];
			res[arr.Count] = s;
			return res;
		}

		public static bool operator ==(Set arr1, Set arr2)
		{
			bool check = true;
			if (arr1.Count != arr2.Count)
				check = false;
			else
				for (int i = 0; i < arr1.Count; i++)
					if (arr1[i] != arr2[i])
						check = false;
			return check;
		}

		public static bool operator !=(Set arr1, Set arr2)
		{
			bool check = false;
			if (arr1.Count != arr2.Count)
				check = true;
			else
				for (int i = 0; i < arr1.Count; i++)
					if (arr1[i] != arr2[i])
						check = true;
			return check;
		}

		public void Print()
		{
			for (int i = 0; i < _arr.Length; i++)
				Console.Write(" " + _arr[i]);
			Console.WriteLine();
		}

		public class Owner
		{
			int id;
			string name;
			string org;

			public Owner()
			{
				id = 45362;
				name = "Vlad";
				org = "ShoesComp.";
			}

			public void Print()
			{
				Console.WriteLine(id + " " + name + " " + org);
			}
		}

		public class Date
		{
			DateTime dt;
			public Date()
			{
				dt = new DateTime(2020, 10, 04);
			}

			public void Print()
			{
				Console.WriteLine(dt.ToString("d"));
			}
		}
	}

	static class SetCheck
	{
		public static string minStr(this Set s)
		{
			string min = s[0];
			for (int i = 0; i < s.Count; i++)
				if (s[i].Length < min.Length)
					min = s[i];
			return min;
		}

		public static Set ordering(this Set s)
		{
			Set res = new Set();
			res = new Set(s.Count);
			int index = 0;
			int max = s[0].Length;
			for (int i = 0; i < s.Count; i++)
				if (s[i].Length > max)
					max = s[i].Length;
			for (int i = 1; i <= max; i++)
			{
				for (int j = 0; j < s.Count; j++)
				{
					if (s[j].Length == i)
					{
						res[index] = s[j];
						index++;
					}
				}
			}
			return res;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Set arr1 = new Set(10);
			Set arr2 = new Set(10);

			string[] str1 = new string[] { "lorem", "ipsum", "dolor", "consectetur", "sit", "amet", "adipiscing", "elit", "sed", "do" };
			for (int i = 0; i < arr1.Count; i++)
				arr1[i] = str1[i];

			string[] str2 = new string[] { "diam", "vulputate", "ut", "pharetra", "sit", "amet", "aliquam", "id", "diam", "maecenas" };
			for (int i = 0; i < arr2.Count; i++)
				arr2[i] = str2[i];

			Console.Write("Set 1:");
			arr1.Print();
			Console.Write("Set 2:");
			arr2.Print();

			Console.WriteLine();
			Set arr3 = arr1 - "sit";
			Console.Write("First set - 'sit':");
			arr3.Print();

			Console.WriteLine();
			Set arr4 = arr2 + "sit";
			Console.Write("Second set + 'sit':");
			arr4.Print();

			Console.WriteLine();
			Set arr5 = arr1 % arr2;
			Console.Write("Intersection of 1 and 2 sets:");
			arr5.Print();

			Console.WriteLine();
			Set arr1copy = arr1;
			bool check;
			check = arr1 != arr2;
			Console.Write("Is 1 and 2 sets inequal? ");
			Console.WriteLine(check);
			check = arr1 != arr1copy;
			Console.Write("Is 1 and 1 copy sets inequal? ");
			Console.WriteLine(check);

			Console.WriteLine();
			string str = SetCheck.minStr(arr2);
			Console.Write("The shortest word in 2 set: ");
			Console.WriteLine(str);

			Console.WriteLine();
			Set arr6 = SetCheck.ordering(arr1);
			Console.Write("Ordered set 1:");
			arr6.Print();

			Console.WriteLine();
			Set.Owner vlad = new Set.Owner();
			vlad.Print();

			Console.WriteLine();
			Set.Date date = new Set.Date();
			date.Print();
		}
	}
}