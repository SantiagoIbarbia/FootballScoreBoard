using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Domain.Exceptions
{

    internal class InvalidScoreException : Exception
    {
        public override string Message
        {
            get
            {
                return "You have passed an invalid result";
            }
        }
    }

}
