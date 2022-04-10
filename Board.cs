using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDevTodoAppV2
{
    public class Board
    {
        public string BoardName { get; set; }
        public List<Card> boardCards = new();

        public Board(string name)
        {
            BoardName = name;
        }


        public void ListCards()
        {
            Console.WriteLine(BoardName + " Board");
            Console.WriteLine("*******************************************");

            foreach (var item in boardCards)
            {
                item.WriteCardInfo();

                Console.WriteLine("-");
            }

            Console.WriteLine();
        }

        public void AddCardToBoard(Card card, out bool isAdded)
        {
            isAdded = false;

            if (boardCards.Count <= 0)
            {
                boardCards.Add(card);
                //Console.WriteLine("Kart Listesi Boştu Eklendi");
                isAdded = true;
                return;
            }
            else
            {
                foreach (var item in boardCards)
                {
                    if (item.title.ToLower() == card.title.ToLower())
                    {
                        Console.WriteLine("Kart Zaten Mevcut Başka Board Seçiniz!");
                        isAdded = false;
                        return;
                    }
                }
            }

            if (card != null)
            {
                boardCards.Add(card);
                isAdded = true;
                Console.WriteLine(card.title + " başlıklı kart " + BoardName + " adlı board'a eklendi.");
            }
        }

        public Card FindCardWithName(string cardTitle)
        {
            Card card = null;
            foreach (var item in boardCards)
            {
                if (item.title.ToLower() == cardTitle.ToLower())
                {
                    card = item;
                    break;
                }
            }
            return card;
        }

    }



    public class Boards
    {
        public static List<Board> boards = new()
        {
            new Board("Todo"),
            new Board("In Proggress"),
            new Board("Done")
        };


        public static void AddCardToBoard(Card card, int boardIndex, out bool isAdded)
        {
            boards[boardIndex - 1].AddCardToBoard(card, out isAdded);
        }

        public static void AddCardToBoard(Card card, int boardIndex)
        {
            boards[boardIndex - 1].AddCardToBoard(card, out bool isAdded);
        }

        public static Card FindCardFromBoard(string cardTitle)
        {
            Card card = null;

            try
            {
                for (int i = 0; i <= boards.Count; i++)
                {
                    if (card == null)
                    {
                        card = boards[i].FindCardWithName(cardTitle);
                    }
                    else
                    {
                        return card;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Yaptınız.Lütfen tekrar deneyiniz!");
            }

            Console.WriteLine("Kart bulunamadı!");
            return new Card();
        }

        public static void DeleteCardFromBroad(Card card, string boardName)
        {
            Card cd = FindCardFromBoard(card.title);
            if (cd == null || cd.title == "")
            {
                Console.WriteLine("Lütfen İsmi Doğru Giriniz!");
                return;
            }

            switch (boardName)
            {
                case "Todo":
                    boards[0].boardCards.Remove(card);
                    break;

                case "In Proggress":
                    boards[1].boardCards.Remove(card);
                    break;

                case "Done":
                    boards[2].boardCards.Remove(card);
                    break;
            }
        }

        public static string BoardIndexToName(int boardIndex)
        {
            switch (boardIndex)
            {
                case 1:
                    return "Todo";

                case 2:
                    return "In Proggress";

                case 3:
                    return "Done";
            }

            return "";
        }


    }
}
