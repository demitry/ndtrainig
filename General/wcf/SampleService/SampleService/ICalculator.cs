using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
	[ServiceContract]
	public interface ICalculator
	{
		#region Common Methods

		/// <summary>
		/// проверка соединения
		/// </summary>
		/// <returns> OK </returns>
		[OperationContract]
		string TestConnection();

		#endregion

		#region Arithmetic

		/// <summary>
		/// сложение
		/// </summary>
		/// <param name="a"> слагаемое 1 </param>
		/// <param name="b"> слагаемое 2 </param>
		/// <returns> сумма </returns>
		[OperationContract]
		double Addition(double a, double b);

		/// <summary>
		/// вычитание
		/// </summary>
		/// <param name="a"> уменьшаемое </param>
		/// <param name="b"> вычитаемое </param>
		/// <returns> разность </returns>
		[OperationContract]
		double Subtraction(double a, double b);

		/// <summary>
		/// умножение
		/// </summary>
		/// <param name="a"> множитель 1 </param>
		/// <param name="b"> множитель 2 </param>
		/// <returns> произведение </returns>
		[OperationContract]
		double Multiplication(double a, double b);

		/// <summary>
		/// деление
		/// </summary>
		/// <param name="a"> делимое </param>
		/// <param name="b"> делитель </param>
		/// <returns> частное </returns>
		[OperationContract]
		double Division(double a, double b);

		#endregion
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}
