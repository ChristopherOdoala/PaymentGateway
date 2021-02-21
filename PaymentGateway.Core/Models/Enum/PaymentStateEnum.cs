using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PaymentGateway.Core.Models.Enum
{
    public enum PaymentStateEnum
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Processed")]
        Processed,
        [Description("Failed")]
        Failed
    }
}
