//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace avto.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DataOfAddition { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SheetFormatId { get; set; }
    
        public virtual SheetFormat SheetFormat { get; set; }
        public virtual ServiceOrder ServiceOrder { get; set; }
    }
}
