﻿namespace Syn.Core.SqlSchemaGenerator.Attributes;

/// <summary>
/// Provides a human-readable description for the column or entity.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
public class DescriptionAttribute : Attribute
{
    /// <summary>
    /// The description text.
    /// </summary>
    public string Text { get; }

    public DescriptionAttribute(string text)
    {
        Text = text;
    }
}