using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config and in the associated .svc file.
public class MathService : IMathService
{

    #region IMathService Members

    public int Addition(Math obj1)
    {
        return (obj1.Number1 + obj1.Number2);
    }

    public int Subtraction(Math obj2)
    {
        return (obj2.Number1 - obj2.Number2);
    }

    #endregion
}
