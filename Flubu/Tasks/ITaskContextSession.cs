﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Flubu.Tasks
{
    public interface ITaskContextProperties
    {
        /// <summary>
        /// Property indexer.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        string this[string propertyName]
        {
            get;
            set;
        }

        /// <summary>
        /// Get's the property by property name.
        /// </summary>
        /// <typeparam name="T">Type of returned property</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <returns>The property</returns>
        T Get<T>(string propertyName);

        /// <summary>
        /// Get's the property by property name.
        /// </summary>
        /// <typeparam name="T">Type of returned property</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <param name="defaultValue">Returned value if property is not set in session.</param>
        /// <returns>The property</returns>
        T Get<T>(string propertyName, T defaultValue);

        /// <summary>
        /// Checks by property name if property is stored in session.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        bool Has(string propertyName);

        /// <summary>
        /// Enumerates all properties
        /// </summary>
        /// <returns>Enumareted properties.</returns>
        IEnumerable<KeyValuePair<string, object>> EnumerateProperties();

        /// <summary>
        /// Set's property in session.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyValue">The propery value.</param>
        void Set<T>(string propertyName, T propertyValue);

        /// <summary>
        /// Clear all properties from session.
        /// </summary>
        void Clear();

        /// <summary>
        /// Removes the specified property from session.
        /// </summary>
        /// <param name="propertyName">The name of property to be removed.</param>
        void Remove(string propertyName);
    }
}
