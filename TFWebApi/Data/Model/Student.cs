namespace TFWebApi.Data.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Grade { get; set; }
        public virtual Lector Lector { get; set; }
        public int LectorId { get; set; }
    }
}
