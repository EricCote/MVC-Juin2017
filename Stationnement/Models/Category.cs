namespace Stationnement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesLT.ProductCategory")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<Category>();
        }

        [Column("ProductCategoryID")]
        public int CategoryID { get; set; }

        [Column("ParentProductCategoryID")]
        public int? ParentCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid rowguid { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [Display(Name="Sous-Categorie")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> SubCategories { get; set; }

    
        public virtual Category ParentCategory { get; set; }
    }
}
