using TFWebApi.Data.Model;
using TFWebApi.Data.Model.DTO;
using TFWebApi.Interfaces;

namespace TFWebApi.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly List<Lector> Lectors;

        public DatabaseService(List<Lector> lectors)
        {
            Lectors = new List<Lector>()
            {
                new Lector(){Id = 1, Email = "test@gmail.com", Name = "test"},
                new Lector(){Id = 2, Email = "test1@gmail.com", Name = "test2"},
                new Lector(){Id = 3, Email = "test2@gmail.com", Name = "test3"},
                new Lector(){Id = 4, Email = "test3@gmail.com", Name = "test4"},
                new Lector(){Id = 5, Email = "test4@gmail.com", Name = "test5"},
            };
        }

        public async Task<List<Lector>> GetAllAsync()
        {
            return Lectors.ToList();
        }

        public async Task<Lector> GetById(int id)
        {
            return Lectors.FirstOrDefault(x => x.Id == id);
        }
        public async Task<bool> CreateAsync(Lector lector)
        {
            var existingLector = Lectors.Find(x => x.Id == lector.Id);
            if (existingLector != null)
                return false;

            Lectors.Add(lector);
            return true;
        }
        public async Task<bool> UpdateAsync(Lector lector)
        {
            var lectorToUpdate = Lectors.Find(x => x.Id == lector.Id);
            if (lectorToUpdate is null) return false;

            lectorToUpdate.Id = lector.Id;
            lectorToUpdate.Email = lector.Email;
            lectorToUpdate.Name = lector.Name;
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingLector = Lectors.Find(x => x.Id == id);
            if (existingLector is null)
                return false;

            Lectors.Remove(existingLector);
            return true;
        }
    }
}
