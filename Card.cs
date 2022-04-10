using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public class Card
    {
        public string title { get; set; }
        public string content { get; set; }
        public int userID { get; set; }

        public BoardSize size { get; set; }
        public string boardName { get; set; }


        public Card()
        {
        }

        public Card(string title, string content, int userID, BoardSize size ,string boardName)
        {
            this.title = title;
            this.content = content;
            this.userID = userID;
            this.size = size;
            this.boardName = boardName;
        }


        public void WriteCardInfo()
        {
            Console.WriteLine("Başlık       : " + title);
            Console.WriteLine("İçerik       : " + content);
            Console.WriteLine("Atanan Kişi  : " + userID);
            Console.WriteLine("Büyüklük     : " + size);
            Console.WriteLine("Board Adı    : " + boardName);
        }

        public void UpdateBoardName(string newName)
        {
            boardName = newName;
        }

    }

    public enum BoardSize
    {
        XS, S, M, L, XL
    } 
}
