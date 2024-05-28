using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using TFWebApi.Data.Model;
using TFWebApi.Interfaces;

namespace TFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorMockController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public LectorMockController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public async Task<List<Lector>> GetAllAsync()
        {
            return await _databaseService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Lector> GetByIdAsync(int id)
        {
            return await _databaseService.GetById(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(Lector lector)
        {
            return await _databaseService.CreateAsync(lector);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync(Lector lector)
        {
            return await _databaseService.UpdateAsync(lector);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _databaseService.DeleteAsync(id);
        }

    }
}
