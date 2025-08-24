﻿using System.Reflection;
using Syn.Core.SqlSchemaGenerator.Models;
using Syn.Core.SqlSchemaGenerator.Attributes;

namespace Syn.Core.SqlSchemaGenerator.AttributeHandlers;

/// <summary>
/// Handles <see cref="IndexAttribute"/> and adds index metadata to the column.
/// </summary>
public class IndexAttributeHandler : ISchemaAttributeHandler
{
    /// <summary>
    /// Applies index attributes found on the property to the column model.
    /// </summary>
    public void Apply(PropertyInfo property, ColumnModel column)
    {
        var attributes = property.GetCustomAttributes<IndexAttribute>();

        foreach (var attr in attributes)
        {
            var index = new IndexModel
            {
                Name = attr.Name,
                IsUnique = attr.IsUnique,
                Columns = attr.IncludeColumns?.ToList() ?? new List<string>()
            };

            column.Indexes.Add(index);
        }
    }
}