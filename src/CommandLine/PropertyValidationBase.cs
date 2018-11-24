// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See License.md in the project root for license information.

namespace CommandLine
{
    using System;

    using CommandLine.Core;

    /// <summary>
    /// Base for property based validations
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class PropertyValidationBase : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValidationBase"/> class
        /// </summary>
        /// <param name="message">The message to be displayed in the <see cref="Validate"/> call fails.</param>
        /// <param name="stopProcessing">if <c>true</c>, no further processing takes place if this validation fails</param>
        protected PropertyValidationBase(string message, bool stopProcessing)
        {
            this.StopProcessing = stopProcessing;
            if (message != null)
            {
                Message = message;
            }
            else
            {
                Message = "Validation failed";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValidationBase"/> class
        /// </summary>
        protected PropertyValidationBase()
            : this(null, false)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the application should stop on this validation error.
        /// </summary>
        public bool StopProcessing { get; }

        /// <summary>
        /// Gets the message to be displayed on error
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Validate the value.
        /// </summary>
        /// <param name="property">The property to be validated</param>
        /// <param name="value">The value to be validated.</param>
        /// <returns>an <see cref="Error"/> in case of validation error or <c>null</c> for success.</returns>
        internal abstract Error Validate(SpecificationProperty property, object value);
    }
}
