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
    
    public partial class Col_news
    {
        public int id { get; set; }
        public int collects_id { get; set; }
        public int news_id { get; set; }
    
        public virtual Collects Collects { get; set; }
        public virtual Psy_news Psy_news { get; set; }
    }
}
