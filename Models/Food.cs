using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Alere.Models
{
    [Table("Tbl_Food")]
    public class Food
    {
        [Column("Id"), HiddenInput]
        public long FoodId { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public bool? IsReserved { get; set; }

        [Display(Name = "Reservado até"), DataType(DataType.Date)]
        public DateTime? ReservedUntil { get; set; }

        public bool? IsPerishable { get; set; }

        [Display(Name = "Data de Fabricação"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ManufacturedAt { get; set; }

        [Display(Name = "Data de Validade"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpireAt { get; set; }

        [Display(Name = "Imagem")]
        public string UrlImage { get; set; }

        [Display(Name = "Tipo do Alimento")]
        public FoodType Type { get; set; }

        public User User { get; set; }
        public long? UserId { get; set; }
    }

    public enum FoodType
    {
        [Display(Name = "Orgânico")] ORGANIC,
        [Display(Name = "Industrializado")] INDUSTRIALIZED
    }
}