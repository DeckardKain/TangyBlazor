using System.ComponentModel.DataAnnotations;


namespace Tangy_Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Cannot Be Empty.")]
        public string Name { get; set; }
    }
}
