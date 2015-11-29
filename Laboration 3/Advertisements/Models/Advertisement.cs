using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.Models
{
    [Table("tbl_ads")]
    public class Advertisement
    {
        [Column("ad_id")]
        public int Id { get; set; }

        [Required]
        [Column("ad_rubrik")]
        public string Title { get; set; }

        [Required]
        [Column("ad_innehall")]
        public string Content { get; set; }

        [Column("ad_pris")]
        public int Price { get; set; }

        [Column("ad_annonskostnad")]
        public int AdvertisementCost { get; set; }
    }
}