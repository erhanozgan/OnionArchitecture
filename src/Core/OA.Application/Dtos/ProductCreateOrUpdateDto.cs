using System;
using System.ComponentModel.DataAnnotations;

namespace OA.Application.Dtos
{
    public class ProductCreateOrUpdateDto
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}