using Sjerrul.CardDeck.Generic;
using System;
using System.Collections.Generic;

namespace Sjerrul.CardDeck.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Deck playerDeck;
            IList<Card> playerPile = new List<Card>();
            Deck computerDeck;
            IList<Card> computerPile = new List<Card>();

            IList<Card> discardPile = new List<Card>();

            deck.Split(out playerDeck, out computerDeck);

            bool gameEnded = false;
            while (!gameEnded)
            {               
                if (!playerDeck.HasCardsLeft)
                {
                    Console.WriteLine(String.Format("You are all out, reshuffling your pile into your hand"));
                    playerDeck = new Deck(playerPile);
                    playerDeck.Shuffle();
                    playerPile.Clear();
                }

                if (!computerDeck.HasCardsLeft)
                {
                    Console.WriteLine(String.Format("I am all out, reshuffling pile in my hand"));
                    computerDeck = new Deck(computerPile);
                    computerDeck.Shuffle();
                    computerPile.Clear();
                }

                while (playerDeck.HasCardsLeft && computerDeck.HasCardsLeft)
                {
                    Card playerCard = playerDeck.TakeTopCard();
                    Card computerCard = computerDeck.TakeTopCard();

                    Console.WriteLine(String.Format("I have the {0}, you have the {1}", computerCard, playerCard));

                    if (!playerCard.IsEqualValue(computerCard))
                    {
                        if (playerCard.IsHigherValueThan(computerCard))
                        {
                            playerPile.Add(playerCard);
                            playerPile.Add(computerCard);
                            Console.WriteLine(String.Format("You take both."));
                        }
                        else
                        {
                            computerPile.Add(playerCard);
                            computerPile.Add(computerCard);
                            Console.WriteLine(String.Format("I take both."));
                        }
                    }
                    else
                    {
                        discardPile.Add(playerCard);
                        discardPile.Add(computerCard);
                        Console.WriteLine(String.Format("It's a draw, let's remove those!"));
                    }
                }

                
                gameEnded = (computerPile.Count == 0 && !computerDeck.HasCardsLeft) || (playerPile.Count == 0 && !playerDeck.HasCardsLeft) ;
            }
            
            



            Console.ReadLine();
        }
    }
}
