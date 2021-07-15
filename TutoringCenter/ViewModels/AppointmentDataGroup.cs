using System;
using System.ComponentModel.DataAnnotations;

namespace TutoringCenter.ViewModels
{
    public class AppointmentDataGroup
    {        
        [DataType(DataType.Date)]
        public DateTime? RequestDate { get; set; }
        public int? RequestCount { get; set; }
        
    }
}