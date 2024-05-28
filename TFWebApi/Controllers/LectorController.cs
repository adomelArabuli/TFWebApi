using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TFWebApi.Data.Model;
using TFWebApi.Data.Model.DTO;
using TFWebApi.Services;

namespace TFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class LectorController : ControllerBase
    {
        private readonly ILectorService _lectorService;

        public LectorController(ILectorService lectorService)
        {
            _lectorService = lectorService;
        }

        [HttpGet]
        public async Task<ICollection<Lector>> GetAll(int pageNumber, int pageSize)
        {
            return await _lectorService.GetAll(pageNumber,pageSize);
        }

        //[HttpGet("{id}")]
        //public async Task<Lector> GetById(int id)
        //{
        //    var result = await _lectorService.GetById(id);
        //    return result;
        //}

        //[HttpPost] 
        //public async Task<bool> Create(LectorCreateDTO model)
        //{

        //    return await _lectorService.CreateLector(model);
        //}

        //[HttpPut]
        //public async Task<bool> Update(LectorUpdateDTO model)
        //{
        //    return await _lectorService.UpdateLector(model);
        //}

        //[HttpDelete]
        //public async Task<bool> DeleteLector(int id)
        //{
        //    return await _lectorService.DeleteLector(id);
        //}
    }
}
