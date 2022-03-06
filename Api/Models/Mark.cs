﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Table("Mark")]
    public partial class Mark
    {
        [Key]
        public int Id { get; set; }
        public double? Report1 { get; set; }
        public double? Report2 { get; set; }
        public double? Report3 { get; set; }
        public double? Report4 { get; set; }
        public double? Report5 { get; set; }
        public double? Report6 { get; set; }
        public double? Final { get; set; }
        public int AccountId { get; set; }
        [StringLength(50)]
        public string Status { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Marks")]
        public virtual Account Account { get; set; }
    }
}