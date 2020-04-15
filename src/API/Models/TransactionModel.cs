using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TransactionModel
    {
        public string SourceAccountNumber { get; set; }

        public string DestinationAccountNumber { get; set; }

        public decimal Value { get; set; }
    }
}
