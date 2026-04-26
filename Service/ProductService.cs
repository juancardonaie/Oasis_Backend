using Google.Cloud.Firestore;
using oasis_backend.Models;

namespace oasis_backend.Service
{
    public class ProductService
    {
        private readonly FirestoreDb _db;
        private const string Coleccion = "products";

        public ProductService(FirestoreDb db)
        {
            _db = db;
        }

        // Listar todos
        public async Task<List<Product>> GetAllAsync()
        {
            var snapshot = await _db.Collection(Coleccion).GetSnapshotAsync();
            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Product>())
                .ToList();
        }

        // Obtener uno por ID
        public async Task<Product?> GetByIdAsync(string id)
        {
            var doc = await _db.Collection(Coleccion).Document(id).GetSnapshotAsync();
            return doc.Exists ? doc.ConvertTo<Product>() : null;
        }

        // Crear
        public async Task<string> CreateAsync(Product product)
        {
            product.CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow);
            var docRef = await _db.Collection(Coleccion).AddAsync(product);
            return docRef.Id;
        }

        // Actualizar
        public async Task UpdateAsync(string id, Product product)
        {
            await _db.Collection(Coleccion).Document(id).SetAsync(product, SetOptions.MergeAll);
        }

        // Eliminar
        public async Task DeleteAsync(string id)
        {
            await _db.Collection(Coleccion).Document(id).DeleteAsync();
        }

    }
}
