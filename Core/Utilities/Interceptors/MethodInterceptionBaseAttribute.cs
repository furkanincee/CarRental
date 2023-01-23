using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] // Attribute hem classlarda hem metotlarda kullanılabilir, birden çok çağrılabilir, kalıtımla alınabilir.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // Hangi attribute önce çalışsın onun ayarı için sıra no veriyorsun buradan

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
