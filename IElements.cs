using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public interface IElements
    {
        void ListCard();
        void AddCard();
        void UpdateCard();
        void DeleteCard();
        void MoveCard();
    }
}
