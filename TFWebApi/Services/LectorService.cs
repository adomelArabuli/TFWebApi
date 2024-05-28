using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TFWebApi.Data;
using TFWebApi.Data.Model;
using TFWebApi.Data.Model.DTO;

namespace TFWebApi.Services
{
    public class LectorService : ILectorService
    {
        // CreateLector, GetAllLector, GetLectorById, UpdateLector, DeleteLector

        private readonly ApplicationDbContext _db;
        //private readonly IMapper _mapper;
        private readonly ILectorService _lectorService;
        public LectorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Lector>> GetAll(int pageNumber ,int pageSize)
        {
            try
            {
                // filtering
                //var lectors = await _db.lectors.Where(x => x.Name.Contains("t")).ToListAsync();

                // sorting
                //var lectors = await _db.lectors.OrderByDescending(x => x.Id).ToListAsync();

                List<Lector> lectors = new List<Lector>();

                for (int i = 1; i <= 100; i++)
                {
					var lector = new Lector()
					{
						Id = i,
						Email = GenerateRandomString(20),
						Name = GenerateRandomString(10),
					};

					lectors.Add(lector);
                }

				var lectorsToShow = lectors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                //var lectors = await _db.lectors.Where(x => x.Name.Contains("t")).ToListAsync();



                return lectorsToShow;
            }
            catch (Exception)
            {
                return null;
            }
        }

		static string GenerateRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			Random random = new Random();
			StringBuilder stringBuilder = new StringBuilder(length);

			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(chars[random.Next(chars.Length)]);
			}

			return stringBuilder.ToString();
		}

		//public async Task<Lector> GetById(int id)
		//{
		//    //Eager loading
		//    //var lector = await _db.Lectors.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id);

		//    //Lazy loading
		//    //var lector = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == id);
		//    //var students = lector.Students.ToList();

		//    //var student = await _db.students.SingleOrDefaultAsync(x => x.Id == id);
		//    //var lectorName = student.Lector.Name;

		//    // Explicit loading

		//    //var lector = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == id);

		//    //await _db.Entry(lector).Collection(l => l.Students).LoadAsync();

		//    //var student = await _db.students.FromSqlRaw("SELECT * FROM dbo.students WHERE id = 4").ToListAsync();
		//    int idTest = 4;
		//    var student = await _db.students.FromSqlInterpolated($"SELECT * FROM dbo.students WHERE id = {idTest}").ToListAsync();

		//    var lector = await _db.Lectors.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id);

		//    if (lector == null)
		//        return default;

		//    return lector;
		//}

		//public async Task<bool> CreateLector(LectorCreateDTO model)
		//{
		//    try
		//    {
		//        var lector = _mapper.Map<Lector>(model);

		//        await _db.Lectors.AddAsync(lector);

		//        await _db.SaveChangesAsync();

		//        return true;
		//    }
		//    catch (Exception)
		//    {
		//        return false;
		//    }
		//}

		//public async Task<bool> UpdateLector(LectorUpdateDTO model)
		//{
		//    var lectorToUpdate = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == model.Id);

		//    if (lectorToUpdate == null)
		//        return default;

		//    _mapper.Map(model, lectorToUpdate);

		//    _db.Lectors.Update(lectorToUpdate);

		//    _db.SaveChangesAsync();

		//    return true;
		//}

		//public async Task<bool> DeleteLector(int id)
		//{
		//    try
		//    {
		//        #region AggregationFunctions

		//        // Query syntax, MethodSyntax

		//        //Query Syntax
		//        //var query = from lector1 in _db.Lectors
		//        //            join student in _db.students on lector1.Id equals student.LectorId
		//        //            select new
		//        //            {
		//        //                LectorName = lector1.Name,
		//        //                StudentName = student.Name
		//        //            };

		//        //Method syntax

		//        //var query = await _db.Lectors
		//        //    .Join(_db.students,
		//        //    lector => lector.Id,
		//        //    student => student.LectorId,
		//        //    (lector, student) => new
		//        //    {
		//        //        LectorName = lector.Name,
		//        //        StudentName = student.Name
		//        //    }).ToListAsync();


		//        //var query = _db.students
		//        //    .GroupBy(x => x.LectorId)
		//        //    .Select(group => new
		//        //    {
		//        //        LectorId = group.Key,
		//        //        TotalStudents = group.Count(),
		//        //        AverageAge = group.Average(s => DateTime.Now.Year - s.BirthDate.Year)
		//        //    }).ToList();

		//        //var totalAmount = _db.students.Sum(s => s.Grade);
		//        //var maxGrade = _db.students.Max(s => s.Grade);
		//        //var minGrade = _db.students.Min(s => s.Grade);
		//        //var averageGrade = _db.students.Average(s => s.Grade);

		//        #endregion

		//        var lector = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == id);

		//        if (lector is null)
		//            return false;

		//        _db.Remove(lector);

		//        await _db.SaveChangesAsync();

		//        return true;
		//    }
		//    catch (Exception)
		//    {
		//        return false;
		//    }
		//}
	}
}
