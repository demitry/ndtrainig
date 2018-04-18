using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//https://sohabr.net/habr/post/264889/

namespace SampleService
{
	public class Calculator : ICalculator
	{
		#region Common Methods

		/// <summary>
		/// проверка соединения
		/// </summary>
		/// <returns> OK </returns>
		public string TestConnection()
		{
			return "OK";
		}

		#endregion

		#region Arithmetic

		/// <summary>
		/// сложение
		/// </summary>
		/// <param name="a"> слагаемое 1 </param>
		/// <param name="b"> слагаемое 2 </param>
		/// <returns> сумма </returns>
		public double Addition(double a, double b)
		{
			return a + b;
		}

		/// <summary>
		/// вычитание
		/// </summary>
		/// <param name="a"> уменьшаемое </param>
		/// <param name="b"> вычитаемое </param>
		/// <returns> разность </returns>
		public double Subtraction(double a, double b)
		{
			return a - b;
		}

		/// <summary>
		/// умножение
		/// </summary>
		/// <param name="a"> множитель 1 </param>
		/// <param name="b"> множитель 2 </param>
		/// <returns> произведение </returns>
		public double Multiplication(double a, double b)
		{
			return a * b;
		}

		/// <summary>
		/// деление
		/// </summary>
		/// <param name="a"> делимое </param>
		/// <param name="b"> делитель </param>
		/// <returns> частное </returns>
		public double Division(double a, double b)
		{
			return a / b;
		}

		#endregion
	}
}
