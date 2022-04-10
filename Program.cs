using System;
using System.Collections.Generic;

namespace PatikaDevTodoAppV2
{
    public class Program
    {
        static void Main(string[] args)
        {
            OperationController.DefaultCards();
            OperationController.MainMenu();
        }
    }


    public class OperationController
    {
        public static void MainMenu()
        {
            DefaultMessage();
            DefaultOperation();
            MainMenu();
        }

        static void DefaultMessage()
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
            Console.WriteLine("(0) UYGULAMADAN ÇIK ");
            Console.WriteLine();

            #endregion
        }

        static void DefaultOperation()
        {
            #region Kullanıcıdan Alınan Veriye Göre İşlem Yaptırma
            int operationNumber = 0;

            try
            {
                operationNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen Sayısal Bir Değer Giriniz.");
                MainMenu();
            }

            switch (operationNumber)
            {
                case 1:
                    BoardController.ListAllBoardCards();
                    break;

                case 2:
                    BoardController.AddCard();

                    break;

                case 3:
                    BoardController.DeleteCard();
                    break;

                case 4:
                    BoardController.UpdateCard();
                    break;

                case 5:
                    BoardController.MoveCard();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Lütfen İlgili Değerler Aralığında bir Değer Giriniz!");
                    DefaultOperation();
                    break;

            }
            #endregion
        }

        public static void DefaultCards()
        {
            Card[] cards = new Card[]
            {
                new Card("Okunacak", "Küçük Prens, 1984, Hayvan Çiftliği", 456332, BoardSize.XL, "Todo"),
                new Card("Al", "Un, Krema, Şeker", 121456, BoardSize.XS, "Todo"),
                new Card("Gezi", "Nereler Gezilecek, Konaklama vs... ", 174396, BoardSize.S, "Todo")
            };

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].UpdateBoardName(Boards.boards[i].BoardName);
                Boards.AddCardToBoard(cards[i], i + 1);
            }
        }
    }
}
