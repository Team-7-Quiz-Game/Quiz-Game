using Autofac;
using Trivia.Core;
using Trivia.Core.Contracts;

namespace Trivia.UI
{
    public class AutofacModuleConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Factory>().As<IFactory>().SingleInstance();
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
        }
    }
}
