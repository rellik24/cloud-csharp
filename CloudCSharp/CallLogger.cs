using System;
using Castle.DynamicProxy;

namespace cloudcsharp.CloudCSharp
{
    public class CallLogger : IInterceptor

    {
        TextWriter _output;

        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {

            _output.WriteLine("你正在调用方法 \"{0}\" ",
              invocation.Method.Name);
            try
            {
                //在被拦截的方法执行完毕后 继续执行
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            _output.WriteLine("Interceptor End.");
        }
    }

    public interface IShape
    {
        void Area();
    }

    public class Circle : IShape
    {
        public void Area()
        {
            Console.WriteLine("Circle");
            throw new Exception("Circle GGGG"); // 強迫噴錯
        }
    }

    public class Square : IShape
    {
        public void Area()
        {
            Console.WriteLine("Square");
        }
    }
}

