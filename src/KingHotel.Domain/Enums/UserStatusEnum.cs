using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Domain.Enums
{
    public enum UserStatusEnum
    {
        Created = 0,
        InProgress = 1,
        Suspended = 2,
        Cancelled = 3,
        Finished = 4,
        PaymentPending = 5
    }
}
