using SQLite;
using SqliteDemo.Models;
using SqliteDemo.Pages;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Services
{
    public class PointService : IPointService
    {
        private SQLiteAsyncConnection _db;
        public PointService()
        {
            if (_db is null)
            {
                string pathdb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDB2.db3");
                _db = new SQLiteAsyncConnection(pathdb);
                /*_db.CreateTableAsync<PointModel>();
                _db.InsertAsync(new PointModel() { Title = "MatheMatiques111", Date = DateTime.Now, Point = 18.10M });
                _db.InsertAsync(new PointModel() {  Title = "Anglais", Date = DateTime.Now, Point = 20.00M });
                _db.InsertAsync(new PointModel() {  Title = "Technologie", Date = DateTime.Now, Point = 11.90M }); */
            }
        }
        public async Task<List<PointModel>> GetAllPoints()
        {
            //return await _db.QueryAsync<PointModel>($"Select * From PointModel");
            return await _db.Table<PointModel>().ToListAsync();
        }
    }
}