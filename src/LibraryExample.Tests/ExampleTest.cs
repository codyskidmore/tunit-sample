namespace LibraryExample.Tests;

public class ExampleTest
{
    [Before(Test)]
    public void BeforeTestHook(TestContext context)
    {
        context.ObjectBag["calculator"] = new Calculator();
    }

    [Before(Class)]
    public static void BeforeClassHook()
    {
        TestContext.Current!.ObjectBag["calculator"] = new Calculator();
    }

    [Before(Assembly)]
    public static void BeforeAssemblyHook()
    {
        TestContext.Current!.ObjectBag["calculator"] = new Calculator();
    }

    [After(Test)]
    public void AfterTestHook(TestContext context)
    {
        // do something
        //Console.WriteLine(context.Result..);
    }
    
    [Test]
    [Arguments(6, 9)]
    [Retry(3)]
    public async Task TestAdd(int a, int b)
    {
        var calculator = TestContext.Current!.ObjectBag["calculator"] as Calculator;
        await Assert.That(calculator!.Add(a, b)).IsEqualTo(15);
    }
    
    [Test]
    [Arguments(7, 9)]
    [DependsOn(nameof(TestAdd))]
    public async Task TestAdd2(int a, int b)
    {
        var calculator = TestContext.Current!.ObjectBag["calculator"] as Calculator;
        await Assert.That(calculator!.Add(a, b)).IsEqualTo(16);
    }
    
}