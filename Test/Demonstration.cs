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

			Console.Write("(a == null) == ");
			Console.WriteLine(a == null);

			Console.Write("a.IsNullGenericExtension() == ");
			Console.WriteLine(a.IsNullGenericExtension());

			Console.Write("a.IsNullConcreteExtension() == ");
			Console.WriteLine(a.IsNullConcreteExtension());

			Console.Write("IsNullGenericStatic(a) == ");
			Console.WriteLine(IsNullGenericStatic(a));

			Console.Write("IsNullConcreteStatic(a) == ");
			Console.WriteLine(IsNullConcreteStatic(a));

			Console.Write("a.IsNullMember() == ");
			Console.WriteLine(a.IsNullMember());

		}

		public static bool IsNullGenericExtension<T>(this T o)
		{
			return o == null;
		}

		public static bool IsNullConcreteExtension(this Thing o)
		{
			return o == null;
		}

		public static bool IsNullGenericStatic<T>(T o)
		{
			return o == null;
		}

		public static bool IsNullConcreteStatic(Thing o)
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

