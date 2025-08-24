﻿using Syn.Core.SqlSchemaGenerator.Models;

using System.Collections.Generic;

namespace Syn.Core.SqlSchemaGenerator.Storage
{
    /// <summary>
    /// Defines a contract for storing and retrieving schema snapshots over time.
    /// Used by the migration engine to track historical schema states and detect changes.
    /// </summary>
    public interface ISchemaSnapshotStore
    {
        /// <summary>
        /// Saves a snapshot of the current schema with a unique version identifier.
        /// </summary>
        /// <param name="version">The version identifier for the snapshot (e.g., timestamp or semantic version).</param>
        /// <param name="entities">The list of entity definitions representing the schema.</param>
        void SaveSnapshot(string version, IReadOnlyList<EntityDefinition> entities);

        /// <summary>
        /// Retrieves the schema snapshot associated with the specified version.
        /// </summary>
        /// <param name="version">The version identifier of the snapshot to retrieve.</param>
        /// <returns>The list of entity definitions for the given version, or null if not found.</returns>
        IReadOnlyList<EntityDefinition>? GetSnapshot(string version);

        /// <summary>
        /// Gets the latest saved schema snapshot, if any.
        /// </summary>
        /// <returns>The most recent schema snapshot, or null if none exist.</returns>
        IReadOnlyList<EntityDefinition>? GetLatestSnapshot();

        /// <summary>
        /// Lists all available snapshot versions in chronological or semantic order.
        /// </summary>
        /// <returns>A list of version identifiers for all stored snapshots.</returns>
        IReadOnlyList<string> ListVersions();
    }
}