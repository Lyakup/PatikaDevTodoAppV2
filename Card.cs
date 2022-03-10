using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public class Card
    {
        public string title;
        public string contents;
        public string assignedPerson;
        public int size;

        public Card() { } // empty constructor
        
        public Card(string Title, string Contents, string AssignedPerson, int Size)
        {
            this.title = Title;
            this.contents = Contents;
            this.assignedPerson = AssignedPerson;
            this.size = Size;
        }

    }
}
