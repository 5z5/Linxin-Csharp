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
    
    public partial class Answers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answers()
        {
            this.Answer_Comment = new HashSet<Answer_Comment>();
            this.Col_ans = new HashSet<Col_ans>();
            this.likes_ans = new HashSet<likes_ans>();
        }
    
        public int id { get; set; }
        public int users_id { get; set; }
        public int question_id { get; set; }
        public string answer_content { get; set; }
        public Nullable<int> likes_num { get; set; }
        public Nullable<System.DateTime> creat_time { get; set; }
        public string type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer_Comment> Answer_Comment { get; set; }
        public virtual Questions Questions { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Col_ans> Col_ans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<likes_ans> likes_ans { get; set; }
    }
}
