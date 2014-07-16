using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HelperSharp.Mvc
{
    /// <summary>
    /// MVC Controller helper.
    /// </summary>
    public static class ControllerHelper
    {
        /// <summary>
        /// Gets all concrete controller types.
        /// </summary>
        /// <returns>The controller types.</returns>
        public static IList<Type> GetControllerTypes()
        {
            return ReflectionHelper.GetSubclassesOf<ControllerBase>(true);
        }

        /// <summary>
        /// Gets all actions descriptors of the controller.
        /// </summary>
        /// <param name="controllerType">The controller type.</param>
        /// <returns>The actions descriptors.</returns>
        public static IList<ActionDescriptor> GetActionsDescriptors(Type controllerType)
        {
            return new ReflectedControllerDescriptor(controllerType)
                .GetCanonicalActions()
                .ToList();
        }

        /// <summary>
        /// Get all actions descriptors of the controller.
        /// </summary>
        /// <typeparam name="TController">The controller.</typeparam>
        /// <returns>The actions descriptors.</returns>
        public static IList<ActionDescriptor> GetActionsDescriptors<TController>()
        {
            return GetActionsDescriptors(typeof(TController));
        }

        /// <summary>
        /// Get all actions descriptors of the controller that are decorated with the specified custom attribute.
        /// </summary>
        /// <param name="controllerType">The controller type.</param>
        /// <param name="customAttributeType">The custom attribute type.</param>
        /// <returns>The actions descriptors.</returns>
        public static IList<ActionDescriptor> GetActionsDescriptors(Type controllerType, Type customAttributeType)
        {
            return new ReflectedControllerDescriptor(controllerType)
                .GetCanonicalActions()
                .Where(a => a.IsDefined(customAttributeType, true))
                .ToList();
        }

        /// <summary>
        /// Get all actions descriptors of the controller that are decorated with the specified custom attribute.
        /// </summary>
        /// <typeparam name="TController">The controller.</typeparam>
        /// <typeparam name="TCustomAttribute">The custom attribute.</typeparam>
        /// <returns>The actions descriptors.</returns>
        public static IList<ActionDescriptor> GetActionsDescriptors<TController, TCustomAttribute>()
        {
            return GetActionsDescriptors(typeof(TController), typeof(TCustomAttribute));
        }
    }
}
