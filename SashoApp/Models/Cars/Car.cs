using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SashoApp.Models.Cars
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; } // Марка (например BMW)

        [Required]
        [StringLength(50)]
        public string Model { get; set; } // Модел (например 320d)

        [Range(1900, 2100)]
        public int Year { get; set; } // Година на производство

        [StringLength(30)]
        public string Color { get; set; } // Цвят

        [Required]
        public int Mileage { get; set; } // Пробег в километри

        [Required]
        [StringLength(20)]
        public string FuelType { get; set; } // Тип гориво

        [Required]
        [StringLength(20)]
        public string Transmission { get; set; } // Скоростна кутия

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Цена

        [StringLength(1000)]
        public string Description { get; set; } // Описание на колата

        [StringLength(255)]
        public string ImageUrl { get; set; } // URL към снимката на колата

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // Дата на публикуване

        [StringLength(20)]
        public string Status { get; set; } = "Available"; // Статус на колата: Available, Sold
    }
}
