using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatikaDevTodoAppV2
{
    public class BoardElements : IElements
    {
        public List<Card> elementCard = new();
        public string className;


        public void ListCard()
        {

            Console.WriteLine(className + " Board");
            Console.WriteLine("*******************************************");

            foreach (var item in elementCard)
            {
                Console.WriteLine("Başlık : " + item.title);
                Console.WriteLine("İçerik : " + item.contents);
                Console.WriteLine("Atanan Kişi : " + item.assignedPerson);
                Console.WriteLine("Büyüklük : " + item.size);

                Console.WriteLine("-");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void AddCard()
        {
            Console.Write("Başlık Giriniz : ");
            string inputTitle = Console.ReadLine();

            Console.Write("İçerik Giriniz : ");
            string inputcontent = Console.ReadLine();

            Console.Write("Atancak Kişiyi Giriniz : ");
            string inputAssignedPerson = Console.ReadLine();

            Console.Write("Büyüklük Seçiniz : ");
            int inputSize = int.Parse(Console.ReadLine());


            Card newCard = new Card(inputTitle, inputcontent, inputAssignedPerson, inputSize);
            elementCard.Add(newCard);

            ReturnToMainMenu();
        }

        public void UpdateCard()
        {
            string metodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Console.Write("İşlem Yapmak İstediğiniz Kart Başlığını Giriniz : ");
            string cardTitle = Console.ReadLine();

            for (int i = 0; i < elementCard.Count; i++)
            {
                if (elementCard[i].title.ToLower() == cardTitle.ToLower())
                {
                    Console.WriteLine("Kart Bulundu. Lütfen Yeni Değerleri Giriniz.");

                    Console.Write("Yeni Başlık: ");
                    elementCard[i].title = Console.ReadLine();

                    Console.Write("Yeni İçerik: ");
                    elementCard[i].contents = Console.ReadLine();

                    Console.Write("Yeni Atanan Kişi: ");
                    elementCard[i].assignedPerson = Console.ReadLine();

                    Console.Write("Yeni Büyüklük: ");
                    elementCard[i].size = int.Parse(Console.ReadLine());

                    break;
                }
                else
                {
                    NoCardsFound(i, metodName);
                }
            }

            ReturnToMainMenu();
        }

        public void DeleteCard()
        {
            string metodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Console.Write("Lütfen silmek istediğiniz kart başlığını yazınız: ");
            string cardTitle = Console.ReadLine();

            for (int i = 0; i < elementCard.Count; i++)
            {
                if (elementCard[i].title.ToLower() == cardTitle.ToLower())
                {
                    elementCard.RemoveAt(i);

                    Console.WriteLine("İşlem Başarı İle Gerçekleşti.Ana Menüye gidilior.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    NoCardsFound(i, metodName);
                }
            }

            ReturnToMainMenu();
        }

        public void MoveCard()
        {
            string metodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Console.Write("Taşımak İstediğiniz Kart Başlığını Giriniz : ");
            string cardTitle = Console.ReadLine();

            Card foundCard = new();

            for (int i = 0; i < elementCard.Count; i++)
            {
                if (elementCard[i].title.ToLower() == cardTitle.ToLower())
                {
                    foundCard = elementCard[i];

                    break;
                }
                else
                {
                    NoCardsFound(i,metodName);
                }
            }

            Console.WriteLine("Bulunan Kart Bilgileri : ");
            Console.WriteLine("**************************************");
            Console.WriteLine("Başlık       : " + foundCard.title);
            Console.WriteLine("İçerik       : " + foundCard.contents);
            Console.WriteLine("Atanan Kişi  : " + foundCard.assignedPerson);
            Console.WriteLine("Büyüklük     : " + foundCard.size);

            Console.WriteLine();
            Console.WriteLine("Lütfen taşımak istediğiniz Board'ı seçiniz:" + "\n" + 
                "(1) TODO" + "\n" + 
                "(2) IN PROGRESS" + "\n" + 
                "(3) DONE"
                );

            int operationNumber = int.Parse(Console.ReadLine());
            switch (operationNumber)
            {
                case 1:
                    Console.WriteLine("Kart Zaten Mevcut Başka Bir Board Seçiniz.");
                    MoveCard();
                    break;

                case 2:
                    GlobalVariables.inProgressBoard.cards.Add(foundCard);
                    break;

                case 3:
                    GlobalVariables.doneboard.cards.Add(foundCard);
                    break;
            }

            //elementCard.RemoveAt(cardIndex);
            elementCard.Remove(foundCard);

            ReturnToMainMenu();
        }


        void ReturnToMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(("İşlem Başarı İle Gerçekleşti.Ana Menüye gidiliyor.").ToUpper());
            GlobalVariables.MainMenu();
        }

        void NoCardsFound(int i, string methodName)
        {
            //Eğer kart listede ki hiçbir kartla eşleşmediyde
            //ve index listedeki en son karta geldiyse
            if (i == elementCard.Count - 1)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");

                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber == 1)
                {
                    Console.WriteLine("İşlem kullanıcı tarafından iptal edildi.Ana Menüye gidiliyor.");
                    Console.WriteLine();
                    GlobalVariables.MainMenu();
                }
                else
                {
                    switch (methodName)
                    {
                        case "UpdateCard":
                            UpdateCard();
                            break;

                        case "DeleteCard":
                            DeleteCard();
                            break;

                        case "MoveCard":
                            DeleteCard();
                            break;
                    }
                }
            }
        }
    }
}
