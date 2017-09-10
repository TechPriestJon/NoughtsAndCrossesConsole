using GameComponents.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Squares
{
    public interface INandCSquare : ISquare
    {
        NoughtCrossToken? Value { get; set; }
    }
}
