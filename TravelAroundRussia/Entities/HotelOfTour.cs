//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAroundRussia.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelOfTour
    {
        public int IDHotelOfTour { get; set; }
        public Nullable<int> IDHotel { get; set; }
        public Nullable<int> IDTour { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
