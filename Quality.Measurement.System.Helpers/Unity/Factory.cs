using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Quality.Measurement.System.Shared.Helpers.Unity
{
    public class Factory
    {
        #region Container Methods

        private static IUnityContainer _container;
        private static readonly object ContainerAccess = new object();
        private static bool _isConfigured;

        public static IUnityContainer Container
        {
            get
            {
                Init();
                return _container;
            }
            set { _container = value; }
        }

        /// <summary>
        /// Initialized the unity container and reads its configuration
        /// </summary>
        public static void Init()
        {
            if (_container == null || _isConfigured == false)
            {
                lock (ContainerAccess)
                {
                    if (_container == null || _isConfigured == false)
                    {
                        try
                        {
                            _container = new UnityContainer();
                            _container.LoadConfiguration();
                            _isConfigured = true;
                        }
                        catch (Exception ex)
                        {
                          // Debug.WriteLine("Unity Load Error!!! - " + ex.Message);
                            throw new Exception(
                                "Unity Configuration Error - Check the <unity> section of your config file.", ex);
                        }
                    }
                }
            }
        }

        #endregion

        #region CreateInstance Methods

        public static T CreateInstance<T>()
        {
            // this is where Unity takes over and does its magic.
            var obj = Container.Resolve<T>();
            return obj;
        }

        #endregion
        //public static object CreateInstance(Type objectType)
        //{
        //    // if the object is not registered, just try to create it.
        //    var retValue = Container.IsRegistered(objectType) ? Container.Resolve(objectType) : Activator.CreateInstance(objectType);
        //    return retValue;
        //}

        public static T CreateInstance<T>(string name)
        {
            var obj = Container.Resolve<T>(name);
            return obj;
        }

        //#endregion

        //#region RegisterInstance Methods

        //public static IUnityContainer RegisterInstance<T>(T instance)
        //{
        //    return Container.RegisterInstance(instance);
        //}

        //public static IUnityContainer RegisterInstance<T>(string name, T instance)
        //{
        //    return Container.RegisterInstance(name, instance);
        //}

        //public static IUnityContainer RegisterInstance(Type t, string name, object instance, LifetimeManager lifetime)
        //{
        //    return Container.RegisterInstance(t, name, instance, lifetime);
        //}

        //#endregion

        //#region RegisterType Methods

        //public static void Register(Type registerType, params InjectionMember[] injectionMembers)
        //{
        //    Container.RegisterType(registerType, injectionMembers);
        //}

        //public static IUnityContainer RegisterType<TFrom, TTo>() where TTo : TFrom
        //{
        //    return Container.RegisterType<TFrom, TTo>(new TransientLifetimeManager());
        //}

        //public static IUnityContainer RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager) where TTo : TFrom
        //{
        //    return Container.RegisterType<TFrom, TTo>(lifetimeManager);
        //}

        //public static IUnityContainer RegisterType(Type from, Type to, string name, LifetimeManager lifetimeManager,
        //                                           params InjectionMember[] injectionMembers)
        //{
        //    return Container.RegisterType(from, to, name, lifetimeManager, injectionMembers);
        //}

        //#endregion

        //#region Resolve Methods

        //public static T Resolve<T>()
        //{
        //    return Container.Resolve<T>();
        //}

        //public static T Resolve<T>(string name)
        //{
        //    return Container.Resolve<T>(name);
        //}

        //public static object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides)
        //{
        //    return Container.Resolve(t, name, resolverOverrides);
        //}

        //public static IEnumerable<object> ResolveAll(Type objectType)
        //{
        //    return Container.ResolveAll(objectType);
        //}

        //public static IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides)
        //{
        //    return Container.ResolveAll(t, resolverOverrides);
        //}

        //#endregion

        //public static IUnityContainer Parent
        //{
        //    get { return Container.Parent; }
        //}

        //public static IEnumerable<ContainerRegistration> Registrations
        //{
        //    get { return Container.Registrations; }
        //}

        //public static bool IsRegistered(Type objectType)
        //{
        //    return Container.IsRegistered(objectType);
        //}

        //public static bool IsRegistered<T>()
        //{
        //    return Container.IsRegistered<T>();
        //}

        //public static IUnityContainer AddExtension(UnityContainerExtension extension)
        //{
        //    return Container.AddExtension(extension);
        //}

        //public static object BuildUp(Type t, object existing, string name, params ResolverOverride[] resolverOverrides)
        //{
        //    return Container.BuildUp(t, existing, name, resolverOverrides);
        //}

        //public static object Configure(Type configurationInterface)
        //{
        //    return Container.Configure(configurationInterface);
        //}

        //public static IUnityContainer CreateChildContainer()
        //{
        //    return Container.CreateChildContainer();
        //}

        //public static IUnityContainer RemoveAllExtensions()
        //{
        //    return Container.RemoveAllExtensions();
        //}

        //public static void Teardown(object o)
        //{
        //    Container.Teardown(o);
        //}

        //public static void Dispose()
        //{
        //    Container.Dispose();
        //}
    }
}