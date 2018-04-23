using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: If you change the interface name "IService" here, you must also update the reference to "IService" in Web.config.
[ServiceContract]
public interface IMathService
{

    [OperationContract]
    int Addition(Math obj1);

    [OperationContract]
    int Subtraction(Math obj2);

	
}

[DataContract]
public class Math
{
    int number1, number2;

	[DataMember]
	public int Number1
	{
        get { return number1; }
        set { number1 = value; }
	}

	[DataMember]
	public int Number2
	{
        get { return number2; }
        set { number2 = value; }
	}
}
