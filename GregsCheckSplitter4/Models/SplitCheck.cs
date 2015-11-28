using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GregsCheckSplitter4.Models
{
    public class Check
    {
        [Display(Name = "ID")]
        public int CheckID { get; set; }
        public string CheckName { get; set; }
        public decimal CheckTotal { get; set; }
        public decimal TaxPercentage{ get; set; }
        public decimal CheckTaxTotal {
            get
            {
                return CheckTotal * TaxPercentage;
            }
        }
        public decimal TipPercentage { get; set; }
        public decimal CheckTipTotal
        {
            get
            {
                return CheckTotal * TipPercentage;
            }
        }
        public decimal CheckGrandTotal
        {
            get
            {
                return CheckTotal + CheckTaxTotal + CheckTipTotal;
            }
        }
    }
    public class Party
    {
        public int PartyID { get; set; }
        public int CheckID { get; set; }
        public string PartyName { get; set; }
        public decimal PartyTotal { get; set; }
        public decimal PartyTotalTax { get; set; }
        public decimal PartyTipPercentage { get; set; }
        public decimal PartyTotalTip { get; set; }
        public decimal PartyGrandTotal { get; set; }
    }
    public class Diner
    {
        public int DinerID { get; set; }
        public int CheckID { get; set; }
        public int PartyID { get; set; }
        public string DinerName { get; set; }
        public decimal DinerEntree { get; set; }
        public decimal DinerDrink { get; set; }
        public decimal DinerDessert { get; set; }
        public decimal DinerAppetizer { get; set; }
        public decimal DinerTotal { get; set; }

    }

    public class SplitCheckDBContext : DbContext
    {
        public DbSet<Check> Checks { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Diner> Diners { get; set; }
    }
}
