using RobloxCloudApi.APIRequests.DataStores;
using RobloxCloudApi.APIRequests.DataStores.OrderedDataStore;
using RobloxCloudApi.APITypes;
using RobloxCloudApi.APITypes.RobloxObjects.DataStoreTypes;
using RobloxCloudApi.Helpers;

namespace RobloxCloudApi;

#pragma warning disable CS8603

public class DataStoresApi
{
    private readonly IRobloxApiClient _client;

    public DataStoresApi(IRobloxApiClient client)
    {
        this._client = client;
    }
    
    /// <summary>
    ///     Use this method to get a page of DataStores in Universe.
    ///     Use <see cref="GetAllDataStores" /> to Get all DataStores
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="pageToken">A pageToken of the next list page</param>
    /// <param name="maxPageSize">Size of a page, a number between 1 and 100</param>
    /// <param name="showDeleted">Specifies returning of deleted dataStores</param>
    /// <param name="startsWith">Optional filtering the id of DataStore by its starting characters</param>
    /// <returns>An instance of <see cref="DataStoreList" /></returns>
    public  async Task<DataStoreList> GetDataStores(
        long universeId,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false,
        string? startsWith = null
    )
    {
        return (await _client.ThrowIfNull().SendRequest(
            new ListDataStoresRequest
            {
                PageToken = pageToken,
                MaxPageSize = maxPageSize,
                ShowDeleted = showDeleted,
                UniverseId = universeId,
                Filter = startsWith != null ? $"id.startsWith(\"{startsWith}\")" : null
            }));
    }

    /// <summary>
    ///     Use this method to get all dataStores in the universe
    /// </summary>
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="pageToken">A pageToken of the next list page</param>
    /// <param name="maxPageSize">Size of a page, a number between 1 and 100</param>
    /// <param name="showDeleted">Specifies automatic creation of an entry if it doesn't exist</param>
    /// <param name="startsWith">Optional filtering the id of DataStore by its starting characters</param>
    /// <returns>A list of <see cref="DataStoreInfo" /></returns>
    public  async Task<List<DataStoreInfo>> GetAllDataStores(
        
        long universeId,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false,
        string? startsWith = null
    )
    {
        var dataStores = new List<DataStoreInfo>();
        DataStoreList tempList;
        string? currentPageToken = null;
        do
        {
            tempList = await this.GetDataStores(universeId, currentPageToken, 100, true, startsWith);
            if (tempList.List == null)
                break;
            dataStores.AddRange(tempList.List);
            currentPageToken = tempList.NextPageToken;
        } while (tempList.NextPageToken != null);

        return dataStores;
    }

    /// <summary>
    ///     Use this method to delete DataStore. It sets the state of DataStore to "DELETED" to delete DataStore
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <returns>An instance of deleted <see cref="DataStoreInfo" /></returns>
    public  async Task<DataStoreInfo> DeleteDataStore(
        
        long universeId,
        string? dataStoreId)
    {
        return (await _client.ThrowIfNull().SendRequest(
            new DeleteDataStoreRequest
            {
                UniverseId = universeId,
                DataStoreId = dataStoreId
            }
        ));
    }

    /// <summary>
    ///     Use this method to undelete DataStore. It sets the state of DataStore back to "ACTIVE"
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <returns>An instance of deleted <see cref="DataStoreInfo" /></returns>
    public  async Task<DataStoreInfo> UndeleteDataStore(
        
        long universeId,
        string? dataStoreId)
    {
        return (await _client.ThrowIfNull().SendRequest(
            new UndeleteDataStoreRequest
            {
                UniverseId = universeId,
                DataStoreId = dataStoreId
            }
        ));
    }


    /// <summary>
    ///     Use this method to create Data Store
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="newDataStoreId">A DataStore ID to create</param>
    public  async Task CreateDataStore(
        
        long universeId,
        string newDataStoreId)
    {
        const string tempEntryId = "TempEntry2";
        var dataStores = await this.GetAllDataStores(universeId);
        
        // Necromancy is needed.
        if (dataStores.Exists(x => x.Id == newDataStoreId))
        {
            var thisDataStore = dataStores.First(x => x.Id == newDataStoreId);
            if (thisDataStore.State == DataStoreState.DELETED)
                await this.UndeleteDataStore(universeId, newDataStoreId);
            return;
        }

        // Creating by creating an entry and deleting it right after
        await this.CreateDataStoreEntry(
            universeId, newDataStoreId, tempEntryId, "Entry created during dataStoreCreation",
            [123]);
        await this.DeleteDataStoreEntry(universeId, newDataStoreId, tempEntryId);
    }

    /// <summary>
    ///     Use this method to get a list of entries in a DataStore
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="pageToken">A pageToken of next ListPage</param>
    /// <param name="maxPageSize">A number of items to return, a value between 1 and 100</param>
    /// <param name="showDeleted">Specifies returning of deleted entries</param>
    /// <param name="startsWith">Optional filtering id's of entries by its starting characters</param>
    /// <returns>An instance of <see cref="DataStoreEntryList" /></returns>
    public  async Task<DataStoreEntryList> GetDataStoreEntries(
        
        long universeId,
        string dataStoreId,
        string? scopeId = null,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false,
        string? startsWith = null)
    {
        return (await _client.ThrowIfNull().SendRequest(new ListDataStoreEntriesRequest
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            ScopeId = scopeId,
            PageToken = pageToken,
            MaxPageSize = maxPageSize,
            ShowDeleted = showDeleted,
            Filter = startsWith != null ? $"id.startsWith(\"{startsWith}\")" : null
        }));
    }

    /// <summary>
    ///     Use this method to get entry revisions
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">An ID of DataStore entry</param>
    /// <param name="pageToken">A pageToken of next ListPage</param>
    /// <param name="maxPageSize">A number of items to return, a value between 1 and 100</param>
    /// <param name="showDeleted">Specifies returning of deleted entries</param>
    /// <param name="filter">Optional filtering of revisions. See <see href="https://create.roblox.com/docs/cloud/reference/features/storage#Cloud_DeleteDataStoreEntry__Using_Universes_DataStores_Scopes"/> </param>
    /// <returns>An instance of <see cref="DataStoreEntryList" /></returns>
    public  async Task<DataStoreEntryList> GetDataStoreEntryRevisions(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false,
        string? filter = null
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new GetDataStoreEntryRevisionsRequest
        {
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            PageToken = pageToken,
            MaxPageSize = maxPageSize,
            ShowDeleted = showDeleted,
            UniverseId = universeId,
            Filter = filter,
        }));
    }

    /// <summary>
    ///     Use this method to get information about an entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">An ID of DataStore entry</param>
    /// <returns>An instance of <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> GetDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null)
    {
        return await _client.ThrowIfNull().SendRequest(new GetDataStoreEntryRequest
        {
            DataStoreId = dataStoreId,
            UniverseId = universeId,
            EntryId = entryId,
            ScopeId = scopeId
        });
    }

    /// <summary>
    ///     Use this method to update a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <param name="allowMissing">Specifies if updating entry should automatically create it if it doesn't exist</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> UpdateDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        object value,
        long[] dataStoreUsersIds,
        bool allowMissing = false,
        object? attributes = null,
        string? eTag = null
    )
    {
        return await _client.ThrowIfNull().SendRequest(new UpdateDataStoreEntryRequest
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Value = value,
            Attributes = attributes,
            Users = dataStoreUsersIds,
            ETag = eTag,
            AllowMissing = allowMissing
        });
    }


    /// <summary>
    ///     Use this method to update a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <param name="allowMissing">Specifies if updating entry should automatically create it if it doesn't exist</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> UpdateDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        object value,
        long[] dataStoreUsersIds,
        object? attributes = null,
        string? eTag = null,
        bool allowMissing = false
    )
    {
        return await this.UpdateDataStoreEntry(universeId, dataStoreId, entryId, null, value, dataStoreUsersIds, allowMissing,
            attributes, eTag);
    }

    /// <summary>
    ///     Use this method to delete a DataStore Entry. It sets an Entry State to "DELETED"
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="entryId">An ID of DataStore entry</param>
    /// <returns>An instance of <see cref="DataStoreEntry" /></returns>
    public  async Task DeleteDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId = null)
    {
        await _client.ThrowIfNull().SendRequest(new DeleteDataStoreEntryRequest
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId
        });
    }


    /// <summary>
    ///     Use this method to create a new a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> CreateDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        object value,
        long[] dataStoreUsersIds,
        object? attributes = null,
        string? eTag = null
    )
    {
        return await _client.ThrowIfNull().SendRequest(new CreateDataStoreEntryRequest
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Value = value,
            Attributes = attributes,
            Users = dataStoreUsersIds,
            ETag = eTag
        });
    }

    /// <summary>
    ///     Use this method to create a new a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="value">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <param name="eTag">Etag of a DataStore</param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> CreateDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        object value,
        long[] dataStoreUsersIds,
        object? attributes = null,
        string? eTag = null
    )
    {
        return await this.CreateDataStoreEntry(universeId, dataStoreId, entryId, null, value, dataStoreUsersIds,
            attributes, eTag);
    }

    /// <summary>
    ///     Use this method to create a new a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="scopeId">A scope of DataStore if needed</param>
    /// <param name="amount">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> IncrementDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        string? scopeId,
        int amount,
        long[] dataStoreUsersIds,
        object? attributes = null
    )
    {
        return await _client.ThrowIfNull().SendRequest(new IncrementDataStoreEntryRequest
        {
            UniverseId = universeId,
            DataStoreId = dataStoreId,
            EntryId = entryId,
            ScopeId = scopeId,
            Amount = amount,
            Attributes = attributes,
            Users = dataStoreUsersIds
        });
    }

    /// <summary>
    ///     Use this method to create a new a DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of DataStore entry</param>
    /// <param name="amount">New value of dataStoreEntry (Serialized JSON)</param>
    /// <param name="dataStoreUsersIds">A list of User id's affected by dataStore</param>
    /// <param name="attributes">A DataStore attributes</param>
    /// <returns>An updated instance of <see cref="DataStoreEntry" /></returns>
    public  async Task<DataStoreEntry> IncrementDataStoreEntry(
        
        long universeId,
        string dataStoreId,
        string entryId,
        int amount,
        long[] dataStoreUsersIds,
        object? attributes = null
    )
    {
        return await this.IncrementDataStoreEntry(universeId, dataStoreId, entryId, null, amount, dataStoreUsersIds);
    }

    public  async Task<SnapshotResult> SnapshotDataStores(
        
        long universeId)
    {
        return await _client.ThrowIfNull().SendRequest(new SnapshotDataStoresRequest
        {
            UniverseId = universeId
        });
    }
    
    
    
    /// <summary>
    ///     Use this method to get a list of Ordered DataStore Entries
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="dataStoreId">An Ordered DataStore ID (name)</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <param name="pageToken">A pageToken of next ListPage</param>
    /// <param name="maxPageSize">A number of items to return, a value between 1 and 100</param>
    /// <param name="showDeleted">Specifies returning of deleted entries</param>
    /// <param name="startsWith">Optional filtering id's of entries by its starting characters</param>
    /// <returns>An instance of <see cref="OrderedDataStoreEntryList" /></returns>
    public  async Task<OrderedDataStoreEntryList> GetOrderedDataStoreEntries(
        
        long universeId,
        string dataStoreId,
        string scopeId,
        string? pageToken = null,
        int maxPageSize = 10,
        bool showDeleted = false,
        string? startsWith = null)
    {
        return await _client.ThrowIfNull().SendRequest(new ListOrderedDataStoreEntriesRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = dataStoreId,
            ScopeId = scopeId,
            PageToken = pageToken,
            MaxPageSize = maxPageSize,
            ShowDeleted = showDeleted,
            Filter = startsWith != null ? $"id.startsWith(\"{startsWith}\")" : null
        });
    }
    
    /// <summary>
    ///     Use this method to get an Ordered DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="orderedDataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of Ordered DataStore entry</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<OrderedDataStoreEntry> GetOrderedDataStoreEntry(
        
        long universeId,
        string orderedDataStoreId,
        string scopeId,
        string entryId
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new GetOrderedDataStoreEntryRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = orderedDataStoreId,
            ScopeId = scopeId,
            EntryId = entryId
        }));
    }
    
    /// <summary>
    ///     Use this method to create a new Ordered DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="orderedDataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of Ordered DataStore entry</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <param name="value">New value of entry</param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<OrderedDataStoreEntry> CreateOrderedDataStoreEntry(
        
        long universeId,
        string orderedDataStoreId,
        string scopeId,
        string entryId,
        long value
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new CreateOrderedDataStoreEntryRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = orderedDataStoreId,
            ScopeId = scopeId,
            EntryId = entryId,
            Value = value,
        }));
    }
    
    /// <summary>
    ///     Use this method to update an Ordered DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="orderedDataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of Ordered DataStore entry</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <param name="value">New value of entry</param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<OrderedDataStoreEntry> UpdateOrderedDataStoreEntry(
        
        long universeId,
        string orderedDataStoreId,
        string scopeId,
        string entryId,
        long value
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new UpdateOrderedDataStoreEntryRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = orderedDataStoreId,
            ScopeId = scopeId,
            EntryId = entryId,
            Value = value,
        }));
    }
    
    /// <summary>
    ///     Use this method to delete an Ordered DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="orderedDataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of Ordered DataStore entry</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<OrderedDataStoreEntry> DeleteOrderedDataStoreEntry(
        
        long universeId,
        string orderedDataStoreId,
        string scopeId,
        string entryId
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new GetOrderedDataStoreEntryRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = orderedDataStoreId,
            ScopeId = scopeId,
            EntryId = entryId
        }));
    }
    
    /// <summary>
    ///     Use this method to increment Ordered DataStore Entry
    /// </summary>
    
    /// <param name="universeId">A roblox universe ID</param>
    /// <param name="orderedDataStoreId">A DataStore ID (name)</param>
    /// <param name="entryId">An id of Ordered DataStore entry</param>
    /// <param name="scopeId">A scope of Ordered DataStore </param>
    /// <param name="amount">Amount to increment</param>
    /// <returns>An instance of new <see cref="DataStoreEntry" /></returns>
    public  async Task<OrderedDataStoreEntry> IncrementOrderedDataStoreEntry(
        
        long universeId,
        string orderedDataStoreId,
        string scopeId,
        string entryId,
        long amount
    )
    {
        return (await _client.ThrowIfNull().SendRequest(new IncrementOrderedDataStoreEntryRequest()
        {
            UniverseId = universeId,
            OrderedDataStoreId = orderedDataStoreId,
            ScopeId = scopeId,
            EntryId = entryId,
            Amount = amount,
        }));
    }
    
    #pragma warning restore CS8603
}