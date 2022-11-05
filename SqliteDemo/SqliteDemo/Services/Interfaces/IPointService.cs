
using SqliteDemo.Models;

namespace SqliteDemo.Services.Interfaces
{
    internal interface IPointService
    {
        Task<List<PointModel>> GetAllPoints();
    }
}