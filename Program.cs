// using Autofac;
// using Autofac.Extras.DynamicProxy;
using cloudcsharp.CloudCSharp;
using Castle.DynamicProxy;

public class Program
{
    public static void Main(string[] args)
    {
        // // 建立 Autofac 容器
        // var builder = new ContainerBuilder();
        // builder.RegisterType<Circle>().As<IShape>().InterceptedBy(typeof(CallLogger)).EnableInterfaceInterceptors();

        // builder.Register(c => new CallLogger(Console.Out));

        // var container = builder.Build();
        // var circle = container.Resolve<IShape>();
        // circle.Area();

        var proxyGenerator = new ProxyGenerator();
        var callLogger = new CallLogger(Console.Out);

        // 宣告兩個同 interface 的不同 class
        var circle = proxyGenerator.CreateInterfaceProxyWithTarget<IShape>(new Circle(), callLogger);
        var square = proxyGenerator.CreateInterfaceProxyWithTarget<IShape>(new Square(), callLogger);


        circle.Area();
        square.Area();
    }
}
