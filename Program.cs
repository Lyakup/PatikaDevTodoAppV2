using System;
using System.Collections.Generic;

namespace PatikaDevTodoAppV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            GlobalVariables.DefaultCards();

            GlobalVariables.MainMenu();
        }
    }


    public class GlobalVariables
    {
        public static Board todoBoard = new Board("TODO");
        public static Board inProgressBoard = new Board("IN PROGRESS");
        public static Board doneboard = new Board("DONE");


        public static void MainMenu()
        {
            #region Varsayılan Mesaj
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine();


            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz : ");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Güncellemek");
            Console.WriteLine("(5) Kart Taşımak");
            Console.WriteLine();

            #endregion


            #region Kullanıcıdan Alınan Veriye Göre İşlem Yaptırma

            int operationNumber = int.Parse(Console.ReadLine());
            switch (operationNumber)
            {
                case 1:
                    ListAllCards();
                    break;

                case 2:
                    todoBoard.AddCard();
                    break;

                case 3:
                    todoBoard.DeleteCard();
                    break;

                case 4:
                    todoBoard.UpdateCard();
                    break;

                case 5:
                    todoBoard.MoveCard();
                    break;
            }

            #endregion
        }


        public static void DefaultCards()
        {
            Card card1 = new Card("Okunacak", "Küçük Prens, 1984, Hayvan Çiftliği", "Yakup", 6);
            Card card2 = new Card("Gezi", "Nereler Gezilecek, Konaklama vs... ", "Esra", 1);
            Card card3 = new Card("Alınacaklar", "Un, Krema, Şeker", "Berkan", 2);
            todoBoard.cards.Add(card1);
            todoBoard.cards.Add(card2);
            inProgressBoard.cards.Add(card3);
        }

        public static void ListAllCards()
        {
            todoBoard.ListCard();
            inProgressBoard.ListCard();
            doneboard.ListCard();

            Console.WriteLine(("Tüm Board Listelendi.Ana Menüye gidiliyor.").ToUpper());
            Console.WriteLine();
            Console.WriteLine();

            MainMenu();
        }
    }
}
