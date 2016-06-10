using System;

namespace Test
{
	public static class Demonstration
	{
		public static void Main(string[] args)
		{
			Thing a = new Thing();

			Console.Write("(a == null) == ");
			Console.WriteLine(a == null);

			a.Destroy();
			Console.WriteLine("Destroying Thing a.");

			Console.Write("a.IsNullExtension() == ");
			Console.WriteLine(a.IsNullExtension());

			Console.Write("a.IsNullMember() == ");
			Console.WriteLine(a.IsNullMember());

			Console.Write("(a == null) == ");
			Console.WriteLine(a == null);
		}

		public static bool IsNullExtension<T>(this T o) where T : class
		{
			return o == null;
		}
	}

	public class Thing
	{
		public bool _isDestroyed = false;

		public void Destroy()
		{
			_isDestroyed = true;
		}

		public bool IsNullMember()
		{
			return this == null;
		}

		public static bool operator ==(Thing a, object b)
		{
			if (b == null)
			{
				return a._isDestroyed;
			}
			else
			{
				if (b is Thing)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public static bool operator !=(Thing a, object b)
		{
			return !(a == b);
		}
	}
}

