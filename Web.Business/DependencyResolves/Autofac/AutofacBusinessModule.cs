using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Business.Abstract;
using Web.Business.Concrete;
using Web.Core.Utilities.Interceptors;
using Web.Core.Utilities.Security.JWT;
using Web.DataAccess.Abstract;
using Web.DataAccess.Concrete.EntityFramework;

namespace Web.Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfEducationalToyDal>().As<IEducationalToyDal>().SingleInstance();
            builder.RegisterType<EducationalToyManager>().As<IEducationalToyService>().SingleInstance();

            builder.RegisterType<EfPlushToyDal>().As<IPlushToyDal>().SingleInstance();
            builder.RegisterType<PlushToyManager>().As<IPlushToyService>().SingleInstance();

            builder.RegisterType<EfPuzzleToyDal>().As<IPuzzleToyDal>().SingleInstance();
            builder.RegisterType<PuzzleToyManager>().As<IPuzzleToyService>().SingleInstance();

            builder.RegisterType<EfScienceToyDal>().As<IScienceToyDal>().SingleInstance();
            builder.RegisterType<ScienceToyManager>().As<IScienceToyService>().SingleInstance();

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();


        }
    }
}
