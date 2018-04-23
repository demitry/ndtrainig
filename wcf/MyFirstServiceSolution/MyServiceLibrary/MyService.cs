﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MyServiceLibrary
{
    [DataContract]
    public class Maths
    {
       
        [DataMember]
        public int Number1 { get; set; }
        [DataMember]
        public int Number2 { get; set; }

    }

    [ServiceContract]
    public interface IMaths
    {
        [OperationContract]
         int Addition(Maths obj1);
        [OperationContract]
         int Subtraction(Maths obj2);
        [OperationContract]
         int Multiplication(Maths obj3);
        [OperationContract]
         int Division(Maths obj4);
    }
    class MyService:IMaths
    {
        #region IMaths Members

        public int Addition(Maths obj1)
        {
            return (obj1.Number1 + obj1.Number2);
        }

        public int Subtraction(Maths obj2)
        {
            return (obj2.Number1 - obj2.Number2);
        }

        public int Multiplication(Maths obj3)
        {
            return (obj3.Number1 * obj3.Number2);
        }

        public int Division(Maths obj4)
        {
            return (obj4.Number1 / obj4.Number2);
        }

        #endregion
    }
}
