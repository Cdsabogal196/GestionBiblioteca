using System;
using System.Web.Mvc;
using GestionDeBiblioteca.Repositories.Implementation;
using GestionDeBiblioteca.Repositories.Interfaces;
using GestionDeBiblioteca.Services.Implementation;
using GestionDeBiblioteca.Services.Interfaces;
using Unity;
using Unity.Mvc5;

namespace GestionDeBiblioteca
{

    public static class UnityConfig
        {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IBookRepository, BookRepository>();

            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IAuthorService, AuthorService>();


            // TODO: Register your type's mappings here.
            // container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}