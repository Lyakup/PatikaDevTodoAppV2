using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public class Board : BoardElements
    {
        public List<Card> cards = new();

        public Board(string boardName)
        {
            base.className = boardName;
            base.elementCard = cards;
        }
    }
}
