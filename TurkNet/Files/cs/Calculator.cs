using Terrasoft.Core;
using Terrasoft.Core.Factories;
using TurkNet.Api;

namespace TurkNet.Files.cs
{
	[DefaultBinding(typeof(ICalculator), Name = "V1")]
	public class Calculator : ICalculator
	{
		private readonly UserConnection _name;

		public Calculator(UserConnection nameOfMyVariable)
		{
			_name = nameOfMyVariable;
		}

		public int Add(int a, int b)
		{
			return a + b;
		}
		public int Sub(int a, int b)
		{
			return a - b;
		}
	}
	

	[DefaultBinding(typeof(ICalculator), Name = "V2")]
	public class CalculatorTwo : ICalculator
	{

		public int Add(int a, int b)
		{
			return a + b+1000;
		}
		public int Sub(int a, int b)
		{
			return a - b-1000;
		}
	}
}
