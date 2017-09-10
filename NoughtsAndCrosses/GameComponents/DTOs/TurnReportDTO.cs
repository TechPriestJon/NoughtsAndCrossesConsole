using GameComponents.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.DTOs
{
    public class TurnReportDTO
    {
        public int x;
        public int y;
        public bool Success;
        public string Message;
        public int GameTurn;
        public Guid Player;
        public Guid Winner;
        public GameState GameState;
    }
}
