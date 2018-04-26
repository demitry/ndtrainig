using System;
using NSubstitute;
using NUnit.Framework;

namespace NSubTutorial
{



	public class NSubTutorial
	{
		public void Run()
		{
			GettingStarted();
			CreatingSubstitute();
			SettingReturnValue();
			ReturnForSpecificArgs();
			ReturnForAnyArgs();
			ReturnFromFunction();
			MultipleReturnValues();
			ReplacingReturnValues();
			CheckingReceivedCalls();
			ClearingReceivedCalls();
			ArgumentMatchers();
			CallbacksVoidCallsAndWhenDo();
			ThrowingExceptions();
			RaisingEvents();
			AutoAndRecursiveMocks();
			SettingOutAndRefArgs();
			ActionsWithArgumentMatchers();
			CheckingCallOrder();
			PartialSubsAndTestSpies();
			ReturnForAllCallsOfType();
			Threading();
		}

		// Getting started
		public void GettingStarted()
		{
			// We can ask NSubstitute to create a substitute instance for this type. We could ask for a stub, mock, fake, spy, test double etc., 
			// but why bother when we just want to substitute an instance we have some control over?
			var calculator = Substitute.For<ICalculator>();

			// Now we can tell our substitute to return a value for a call:
			calculator.Add(1, 2).Returns(3);
			Assert.That(calculator.Add(1, 2), Is.EqualTo(3));

			// We can check that our substitute received a call, and did not receive others:
			calculator.Add(1, 2);
			calculator.Received().Add(1, 2);
			calculator.DidNotReceive().Add(5, 7);

			// We can also work with properties using the Returns syntax we use for methods, 
			// or just stick with plain old property setters (for read/write properties):
			calculator.Mode.Returns("DEC");
			Assert.That(calculator.Mode, Is.EqualTo("DEC"));

			calculator.Mode = "HEX";
			Assert.That(calculator.Mode, Is.EqualTo("HEX"));

			// NSubstitute supports argument matching for setting return values and asserting a call was received:
			calculator.Add(10, -5);
			calculator.Received().Add(10, Arg.Any<int>());
			calculator.Received().Add(10, Arg.Is<int>(x => x < 0));

			// We can use argument matching as well as passing a function to Returns() 
			// to get some more behaviour out of our substitute (possibly too much, but that’s your call):
			calculator
				.Add(Arg.Any<int>(), Arg.Any<int>())
				.Returns(x => (int)x[0] + (int)x[1]);
			Assert.That(calculator.Add(5, 10), Is.EqualTo(15));

			//Returns() can also be called with multiple arguments to set up a sequence of return values.
			calculator.Mode.Returns("HEX", "DEC", "BIN");
			Assert.That(calculator.Mode, Is.EqualTo("HEX"));
			Assert.That(calculator.Mode, Is.EqualTo("DEC"));
			Assert.That(calculator.Mode, Is.EqualTo("BIN"));

			//Finally, we can raise events on our substitutes (unfortunately C# dramatically restricts the extent to which this syntax can be cleaned up):
			bool eventWasRaised = false;
			calculator.PoweringUp += (sender, arguments) => eventWasRaised = true;
			calculator.PoweringUp += Raise.Event();
			Assert.That(eventWasRaised);
		}

		// Creating a substitute
		public void CreatingSubstitute()
		{
			/*
			The basic syntax for creating a substitute is:
			var substitute = Substitute.For<ISomeInterface>();
			This is how you’ll normally create substitutes for types. 
			
			Generally this type will be an interface, but you can also substitute classes in cases of emergency.
			
			! Warning: !
			Substituting for classes can have some nasty side-effects. 
			For starters, NSubstitute can only work with virtual members of the class, 
			so any non-virtual code in the class will actually execute! 
			
			If you try to substitute for your class 
			that formats your hard drive in the constructor or in a non-virtual property setter 
			then you’re asking for trouble. 
			
			If possible, stick to substituting interfaces.
			
			With the knowledge that we’re not going to be substituting for classes,
			here is how you create a substitute for a class that has constructor arguments:
			var someClass = Substitute.For<SomeClassWithCtorArgs>(5, "hello world");
			For classes that have default constructors the syntax is the same as substituting for interfaces.
			*/


			// Substituting for multiple interfaces
			// There are times when you want to substitute for multiple types. The best example of this is when you have code that works with a type, then checks whether it implements IDisposable and disposes of it if it doesn’t.

			/*
			var command = Substitute.For<ICommand, IDisposable>();
			var runner = new CommandRunner(command);

			runner.RunCommand();

			command.Received().Execute();
			((IDisposable)command).Received().Dispose();

			//Your substitute can implement several types this way, but remember you can only implement a maximum of one class. You can specify as many interfaces as you like, but only one of these can be a class. The most flexible way of creating substitutes for multiple types is using this overload:

			var substitute = Substitute.For(
				new[] { typeof(ICommand), typeof(ISomeInterface), typeof(SomeClassWithCtorArgs) },
				new object[] { 5, "hello world" }
			);
			Assert.IsInstanceOf<ICommand>(substitute);
			Assert.IsInstanceOf<ISomeInterface>(substitute);
			Assert.IsInstanceOf<SomeClassWithCtorArgs>(substitute);
			*/

			// Substituting for delegates
			//	NSubstitute can also substitute for delegate types by using Substiute.For<T>().When substituting for delegate types you will not be able to get the substitute to implement additional interfaces or classes.
			var func = Substitute.For<Func<string>>();
			func().Returns("hello");
			Assert.AreEqual("hello", func());
		}

		// Setting a return value
		public void SettingReturnValue()
		{
			var calculator = Substitute.For<ICalculator>();
			calculator.Add(1, 2).Returns(3);

			// This value will be returned every time this call is made.
			// Returns() will only apply to this combination of arguments, 
			// so other calls to this method will return a default value instead.

			//Make a call return 3:
			calculator.Add(1, 2).Returns(3);
			Assert.AreEqual(calculator.Add(1, 2), 3);
			Assert.AreEqual(calculator.Add(1, 2), 3);

			//Call with different arguments does not return 3
			Assert.AreNotEqual(calculator.Add(3, 6), 3);


			//For properties
			// The return value for a property can be set in the same was as for a method, using Returns().You can also just use plain old property setters for read / write properties; they’ll behave just the way you expect them to.

			calculator.Mode.Returns("DEC");
			Assert.AreEqual(calculator.Mode, "DEC");

			calculator.Mode = "HEX";
			Assert.AreEqual(calculator.Mode, "HEX");

		}

		// Return for specific args
		public void ReturnForSpecificArgs()
		{
			var calculator = Substitute.For<ICalculator>();

			//Return when first arg is anything and second arg is 5:
			calculator.Add(Arg.Any<int>(), 5).Returns(10);
			Assert.AreEqual(10, calculator.Add(123, 5));
			Assert.AreEqual(10, calculator.Add(-9, 5));
			Assert.AreNotEqual(10, calculator.Add(-9, -9));

			//Return when first arg is 1 and second arg less than 0:
			calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
			Assert.AreEqual(345, calculator.Add(1, -2));
			Assert.AreNotEqual(345, calculator.Add(1, 2));

			//Return when both args equal to 0:
			calculator.Add(Arg.Is(0), Arg.Is(0)).Returns(99);
			Assert.AreEqual(99, calculator.Add(0, 0));
		}

		// Return for any args
		public void ReturnForAnyArgs()
		{
			// A call can be configured to return a value regardless of the arguments passed using the ReturnsForAnyArgs() extension method.

			var calculator = Substitute.For<ICalculator>();
			calculator.Add(1, 2).ReturnsForAnyArgs(100);
			Assert.AreEqual(calculator.Add(1, 2), 100);
			Assert.AreEqual(calculator.Add(-7, 15), 100);

			// The same behaviour can also be achieved using argument matchers: it is simply a shortcut for replacing each argument with Arg.Any<T>().
			// ReturnsForAnyArgs() has the same overloads as Returns(), so you can also specify multiple return values or calculated return values using this approach.
		}

		// Return from a function
		public void ReturnFromFunction()
		{
			// The return value for a call to a property or method can be set to the result of a function. 
			// This allows more complex logic to be put into the substitute. Although this is normally a bad practice,
			// there are some situations in which it is useful.

			var calculator = Substitute.For<ICalculator>();
			calculator
				.Add(Arg.Any<int>(), Arg.Any<int>())
				.Returns(x => (int)x[0] + (int)x[1]);

			Assert.That(calculator.Add(1, 1), Is.EqualTo(2));
			Assert.That(calculator.Add(20, 30), Is.EqualTo(50));
			Assert.That(calculator.Add(-73, 9348), Is.EqualTo(9275));
		}

		// Multiple return values
		public void MultipleReturnValues()
		{

		}

		// Replacing return values
		public void ReplacingReturnValues()
		{

		}

		// Checking received calls
		public void CheckingReceivedCalls()
		{

		}

		// Clearing received calls
		public void ClearingReceivedCalls()
		{

		}

		// Argument matchers
		public void ArgumentMatchers()
		{

		}

		// Callbacks, void calls and When..Do
		public void CallbacksVoidCallsAndWhenDo()
		{

		}

		// Throwing exceptions
		public void ThrowingExceptions()
		{

		}

		// Raising events
		public void RaisingEvents()
		{

		}

		// Auto and recursive mocks
		public void AutoAndRecursiveMocks()
		{

		}

		// Setting out and ref args
		public void SettingOutAndRefArgs()
		{

		}

		// Actions with argument matchers
		public void ActionsWithArgumentMatchers()
		{

		}

		// Checking call order
		public void CheckingCallOrder()
		{

		}

		// Partial subs and test spies
		public void PartialSubsAndTestSpies()
		{

		}

		// Return for all calls of a type
		public void ReturnForAllCallsOfType()
		{

		}

		// Threading
		public void Threading()
		{

		}
	}
}