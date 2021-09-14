using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class Order
    {
     
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string UserName { get; set; }
        public string AdresTanimi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }   
        public string Semt { get; set; }  
        public string Telefon { get; set; }


      virtual public List<OrderLine> OrderLines { get; set; }
    }
    public enum EnumOrderState
    { 
        [Display(Name ="Onay Bekleniyor")]
        Waiting,
        [Display(Name = "Onay Tamamlandı")]
        Completed
    }
}
