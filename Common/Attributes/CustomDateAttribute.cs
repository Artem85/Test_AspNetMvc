using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
            : base (typeof(DateTime),
                  DateTime.Now.AddYears(-10).ToShortDateString(),
                  DateTime.Now.ToShortDateString()
                  )
        {

        }
    }
}
