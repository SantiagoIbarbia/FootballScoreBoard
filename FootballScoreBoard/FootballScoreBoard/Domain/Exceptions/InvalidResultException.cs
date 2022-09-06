using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreBoard.Domain.Exceptions
{

    internal class InvalidResultException : Exception
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
