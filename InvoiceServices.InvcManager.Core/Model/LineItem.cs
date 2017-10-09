﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceServices.InvcManager.Core.Model
{
    public class LineItem
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string Description { get; set; }
        public int Qauntity { get; set; }
        public float perQauntityCost { get; set; }
        public float LineItemTotal { get; set; }
        
    }
}
