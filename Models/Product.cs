using Google.Cloud.Firestore;

namespace oasis_backend.Models
{
    [FirestoreData]
    public class Product
    {
        [FirestoreDocumentId]
        public string id { get; set; } = "";
        [FirestoreProperty("categoryId")]
        public string CategoryId { get; set; } = "";
        [FirestoreProperty("contactId")]
        public string ContactId { get; set; } = "";
        [FirestoreProperty("createdAt")]
        public Timestamp CreatedAt { get; set; }
        [FirestoreProperty("currentStock")]
        public int CurrentStock { get; set; }
        [FirestoreProperty("minimumStock")]
        public int MinimumStock { get; set; }
        [FirestoreProperty("name")]
        public string Name { get; set; } = "";
        [FirestoreProperty("openingStock")]
        public int OpeningStock { get; set; }
        [FirestoreProperty("price")]
        public double Price { get; set; }
    }
}
