using SQLite;
using SqliteDemo.Models;
using SqliteDemo.Pages;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Services
{
    public class PointService : IPointService
    {
        private SQLiteAsyncConnection _db;
        private async Task SetConnection()
        {
            if (_db == null)
            {
                string pathdb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDB2.db3");
                _db = new SQLiteAsyncConnection(pathdb);
                await _db.CreateTableAsync<PointModel>();
               /* await _db.InsertAsync(new PointModel() { Id = 1, Title = "MatheMatiques111", Date = DateTime.Now, Point = 18.10M });
                await _db.InsertAsync(new PointModel() { Id = 2, Title = "Anglais", Date = DateTime.Now, Point = 20.00M });
                await _db.InsertAsync(new PointModel() { Id = 3, Title = "Technologie", Date = DateTime.Now, Point = 11.90M });
               */
            }
        }
        public async Task<List<PointModel>> GetAllPoints()
        {
            await SetConnection();
            return await _db.Table<PointModel>().ToListAsync();
        }


        public async Task<PointModel> GetPointById(int Id)
        {
            await SetConnection();
            return await _db.Table<PointModel>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task UpdatePoint(PointModel point)
        {
            await SetConnection();
             await _db.UpdateAsync(point);
        }
        public async Task DeletePoint(PointModel point)
        {
            await SetConnection();
            await _db.DeleteAsync(point);
        }

        public async Task InsertPoint(PointModel point)
        {
            await SetConnection();
            await _db.InsertAsync(point);
        }
    }
}