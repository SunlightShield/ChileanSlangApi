using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChileanSlagApi
{
    public class GetAllData
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly ILogger<GetAllData> _logger;

        public GetAllData(FirestoreDb firestoreDb, ILogger<GetAllData> logger)
        {
            _firestoreDb = firestoreDb;
            _logger = logger;
        }

        public async Task<List<Dictionary<string, object>>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve data from Firestore.");
                CollectionReference collection = _firestoreDb.Collection("your-collection"); // Reemplaza "your-collection" con el nombre de tu colección
                QuerySnapshot snapshot = await collection.GetSnapshotAsync();

                var dataList = new List<Dictionary<string, object>>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        dataList.Add(document.ToDictionary());
                    }
                }

                _logger.LogInformation("Data retrieved successfully.");
                return dataList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving data from Firestore.");
                throw;
            }
        }
    }
}
