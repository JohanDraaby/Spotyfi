//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spotyfi
{
    using System;
    using System.Collections.Generic;
    
    public partial class artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public artist()
        {
            this.albums = new HashSet<album>();
            this.songs = new HashSet<song>();
        }
    
        public int id { get; set; }
        public string real_name { get; set; }
        public string artist_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<album> albums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }

        public override string ToString()
        {
            return $"{nameof(id)}:{id} {nameof(artist_name)}:{artist_name} {nameof(real_name)}:{real_name}";
        }
    }
}
