//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vosmerka.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int Id_Sale { get; set; }
        public int Id_Agent { get; set; }
        public int Id_Product { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Product Product { get; set; }
    }
}
