using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Domain.Exceptions
{
    internal class SameTeamException : Exception
    {
        public override string Message
        {
            get
            {
                return "Both teams are the same.";
            }
        }
    }
}
