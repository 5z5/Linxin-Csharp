//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sci_Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sci_Comment()
        {
            this.likes_sci_comment = new HashSet<likes_sci_comment>();
            this.Sci_Comment1 = new HashSet<Sci_Comment>();
        }
    
        public int id { get; set; }
        public int users_id { get; set; }
        public int article_id { get; set; }
        public string content { get; set; }
        public Nullable<int> parent_comment_id { get; set; }
        public Nullable<int> likes_num { get; set; }
        public Nullable<System.DateTime> creat_time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<likes_sci_comment> likes_sci_comment { get; set; }
        public virtual Sci_articles Sci_articles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sci_Comment> Sci_Comment1 { get; set; }
        public virtual Sci_Comment Sci_Comment2 { get; set; }
        public virtual Users Users { get; set; }
    }
}
