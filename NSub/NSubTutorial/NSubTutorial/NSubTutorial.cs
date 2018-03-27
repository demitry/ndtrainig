using NSubstitute;
using NUnit.Framework;

namespace NSubTutorial
{
	public class NSubTutorial
	{

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

		}

		// Setting a return value
		public void SettingReturnValue()
		{

		}

		// Return for specific args
		public void ReturnForSpecificArgs()
		{

		}

		// Return for any args
		public void ReturnForAnyArgs()
		{

		}

		// Return from a function
		public void ReturnFromFunction()
		{

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