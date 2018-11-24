// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See License.md in the project root for license information.

namespace CommandLine
{
    using System;
    using System.IO;

    using CommandLine.Core;

    /// <summary>
    /// The file exists validation attribute.
    /// </summary>
    public class FileExistsValidationAttribute : PropertyValidationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileExistsValidationAttribute"/> class.
        /// </summary>
        public FileExistsValidationAttribute()
            : this("File {0} not found", true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileExistsValidationAttribute"/> class.
        /// </summary>
        /// <param name="stopProcessing">If <c>true</c>, processing stops after this error</param>
        public FileExistsValidationAttribute(bool stopProcessing)
            : this("File {0} not found", stopProcessing)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileExistsValidationAttribute"/> class.
        /// </summary>
        /// <param name="message">The message to be displayed if the validation fails</param>
        /// <param name="stopProcessing">If <c>true</c>, processing stops after this error</param>
        public FileExistsValidationAttribute(string message, bool stopProcessing)
            : base(message, stopProcessing)
        {
        }

        internal override Error Validate(SpecificationProperty property, object value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (File.Exists((string)value))
            {
                return null;
            }

            return new ValidationFailedError(property.Property.Name, string.Format(this.Message, (string)value), this.StopProcessing);
        }
    }
}