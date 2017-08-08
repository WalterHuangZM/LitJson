using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class TestStart
{
    static void Main(string[] args)
    {
        JsonMapper.RegisterObjectConvert(new TestConvert());

        TestClass tc = new TestClass();
        tc.id = -1;
        TestClass0 t0 = new TestClass0();
        t0.id = 0;
        TestClass1 t1 = new TestClass1();
        t1.id = 1;
        string json = JsonMapper.ToJson(tc);
        string json0 = JsonMapper.ToJson(t0);
        string json1 = JsonMapper.ToJson(t1);
        Console.WriteLine(json);
        Console.WriteLine(json0);
        Console.WriteLine(json1);
        
        TestClass t = JsonMapper.ToObject<TestClass>(json);
        t.Debug();
        t = JsonMapper.ToObject<TestClass>(json0);
        t.Debug();
        t = JsonMapper.ToObject<TestClass>(json1);
        t.Debug();

        TestClass[] arr = new TestClass[3];
        arr[0] = tc;
        arr[1] = t0;
        arr[2] = t1;
        string jsonArr = JsonMapper.ToJson(arr);
        Console.WriteLine(jsonArr);
        TestClass[] tArr = JsonMapper.ToObject<TestClass[]>(jsonArr);
        for (int i=0; i<tArr.Length; i++)
        {
            tArr[i].Debug();
        }

        bool isRunning = true;
        while (isRunning)
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape) isRunning = false;
        }
    }
}

public class TestConvert : IJsonConvert<TestClass>
{
    public TestClass Convert(IJsonWrapper input)
    {
        int id = ((IJsonWrapper)input["id"]).GetInt();
        switch (id)
        {
            case -1: return input.ToObject<TestClass>();
            case 0: return input.ToObject<TestClass0>();
            case 1: return input.ToObject<TestClass1>();
        }
        throw new NotImplementedException();
    }
}


public class TestClass
{
    public int id;

    public virtual void Debug()
    {
        Console.WriteLine("TestClass");
    }
}


public class TestClass0 : TestClass
{
    public override void Debug()
    {
        Console.WriteLine("TestClass0");
    }
}

public class TestClass1 : TestClass
{
    public override void Debug()
    {
        Console.WriteLine("TestClass1");
    }
}
