using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFWebApi.Data.Model
{
    public class Lector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Url { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
