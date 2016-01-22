# DITest
Just for Microsoft DI Team!

1. Open the "DependencyInjectionFixture.cs" inside the "Test.MFT.Integration" lib.
	- There you can see all "ServiceCollection.Add..." magic
	- What you also can see is that there are is 3 times nearly the same code starting with "services.Scan(", only difference is the type that should be resolved.

2. Open the 3 classes which resolve the types specified in "services.Scan("
	- QueryDispatcher inside "MFT.Core.CQRS"
	- CommandDispatcher inside "MFT.Core.CQRS"
	- EventPublisher inside "MFT.Core.EventSourcing"
	- Basicly this 3 files are the same, the only difference is which type they resolve (This is the strange thing about it)

3. The "error" occures inside the "EventPublisher" class.
	- Set a breakpoint to line 24 (Null will be returned)
	- You can also set a breakpoint inside the CommandDispatcher class on line 26 to see that this is working.

4. Start debugging the test "when_creating_an_new_user.it_should_exist_in_the_event_store" and see the issue.
