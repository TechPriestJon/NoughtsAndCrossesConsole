using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Enum;

namespace GameComponents.Squares
{
    public class GameSquare : IGameSquare
    {
        private NoughtCrossToken? _value;
        public NoughtCrossToken? Value
        {
            get { return _value; }
            set
            {
                if (_value == null)
                {
                    _value = value;
                }
                else
                {
                    throw new InvalidOperationException("Square already has value");
                }
            }
        }
    }
}
