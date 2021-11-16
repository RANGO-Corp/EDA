using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alere.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Alere.Models
{
    [Table("Tbl_Requisition")]
    public class Requisition
    {
        [HiddenInput, Column("Id")]
        public long RequisitionId { get; set; }
        [Column("Requisition_Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.AWAITING;
        public string Message { get; set; }

        // N : 1
        [ForeignKey("User")]
        public long? DonorId { get; set; }
        public User Donor { get; set; }

        // N : 1
        public long? FoodId { get; set; }
        public Food Food { get; set; }

        // N : 1
        [ForeignKey("User")]
        public long? ReceiverId { get; set; }
        public User Receiver { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Aprovado"), Style(Severity = "success")] APPROVED,
        [Display(Name = "Aguardando"), Style(Severity = "warning")] AWAITING,
        [Display(Name = "Recusado"), Style(Severity = "danger")] REFUSED
    }
}