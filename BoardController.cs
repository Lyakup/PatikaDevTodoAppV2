using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public class BoardController
    {
        public static void ListAllBoardCards()
        {
            foreach (var item in Boards.boards)
            {
                item.ListCards();
            }
        }

        public static void AddCard()
        {
            Console.Write("Başlık Giriniz : ");
            string inputTitle = Console.ReadLine();

            Console.Write("İçerik Giriniz : ");
            string inputcontent = Console.ReadLine();

            Console.Write("Atancak Kişi ID'si : ");
            int inputAssignedPerson = int.Parse(Console.ReadLine());

            Console.WriteLine("Büyüklük Seçiniz : (0) XS , (1) S , (2) M , (3) L , (4) XL");
            int inputSize = int.Parse(Console.ReadLine());


            Card newCard = new Card(inputTitle, inputcontent, inputAssignedPerson, (BoardSize)inputSize, "Todo");
            Boards.AddCardToBoard(newCard, 1);
        }

        public static void DeleteCard()
        {
            Console.Write("Lütfen silmek istediğiniz kart başlığını yazınız: ");
            string cardTitle = Console.ReadLine();

            Card foundCard = Boards.FindCardFromBoard(cardTitle);
            Boards.DeleteCardFromBroad(foundCard, foundCard.boardName);

            Console.WriteLine();
            Console.WriteLine("İşlem Tamamlandı.Ana Menüye gidiliyor.".ToUpper());
        }

        public static void UpdateCard()
        {
            Console.Write("İşlem Yapmak İstediğiniz Kart Başlığını Giriniz : ");
            string cardTitle = Console.ReadLine();
            Card foundCard = Boards.FindCardFromBoard(cardTitle);

            if(foundCard != null)
            {
                Console.WriteLine("Bulunan Kart Bilgileri!");
                foundCard.WriteCardInfo();

                Console.WriteLine("Lütfen Yeni Değerleri Giriniz!");

                Console.WriteLine();
                Console.Write("Yeni Başlık: ");
                foundCard.title = Console.ReadLine();

                Console.Write("Yeni İçerik: ");
                foundCard.content = Console.ReadLine();

                Console.Write("Yeni Atanan Kişi ID'si: ");
                foundCard.userID = int.Parse(Console.ReadLine());

                Console.WriteLine("Yeni Büyüklük : (0) XS , (1) S , (2) M , (3) L , (4) XL");
                int inputSize = int.Parse(Console.ReadLine());
                foundCard.size = (BoardSize)inputSize;
            }

            Console.WriteLine();
            Console.WriteLine("İşlem Tamamlandı.Ana Menüye gidiliyor.".ToUpper());
        }

        public static void MoveCard()
        {
            Card foundCard = new Card();

            try
            {
                Console.Write("Taşımak İstediğiniz Kart Başlığını Giriniz : ");
                string cardTitle = Console.ReadLine();
                foundCard = Boards.FindCardFromBoard(cardTitle);

                if (foundCard == null || string.IsNullOrEmpty(foundCard.title))
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Bulunan Kart Bilgileri : ");
                    foundCard.WriteCardInfo();
                }

                Console.WriteLine();
                Console.WriteLine("Lütfen taşımak istediğiniz Board'ı seçiniz: ");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGGRESS");
                Console.WriteLine("(3) DONE");

            }
            catch (Exception)
            {
                Console.WriteLine();
                OperationController.MainMenu();
            }

            int operationIndex = 0;
            bool isPassed = false;


            try
            {
                operationIndex = int.Parse(Console.ReadLine());
                isPassed = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen doğru bir değer giriniz.");
                isPassed = false;
            }

            if (isPassed)
            {
                string newBoardName = Boards.BoardIndexToName(operationIndex);
                Card updatedCard = new Card(foundCard.title, foundCard.content, foundCard.userID, foundCard.size, newBoardName);

                if (updatedCard != null || updatedCard.title == "")
                {
                    Boards.AddCardToBoard(updatedCard, operationIndex, out bool isAdded);

                    if (isAdded)
                        Boards.DeleteCardFromBroad(foundCard, foundCard.boardName);
                }
            }
        }

    }
}
