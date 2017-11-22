using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDurak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<int> playerCards = new List<int>();

        public List<int> computerCards = new List<int>();

        public List<int> tableCards = new List<int>();

        public List<int> deckList = new List<int>();

        public int trump;

        public int turn;

        public void DeckListInit()
        {
            void ClearLabels()
            {
                table.Text = "Table:";
                myCards.Text = "My cards:";
                enemyCard.Text = "Enemy cards:";
                giveDeck.Text = "Current deck:";
                defDeck.Text = "Default deck:";
                trumpLbl.Text = "Trump:";
            }
            deckList.Clear();
            computerCards.Clear();
            playerCards.Clear();
            tableCards.Clear();
            ClearLabels();
            int[] deckArray = new int[36];
            void Shuffle()
            {
                void Swap(ref int first, ref int second)
                {
                    int temp = first;
                    first = second;
                    second = temp;
                }
                var randomValue = new Random();
                for (int i = 35; i > 0; i--)
                {
                    int rnd = randomValue.Next(0, i);
                    Swap(ref deckArray[i], ref deckArray[rnd]);
                }
            }
            deckList.Clear();
            //int[] deckArray = new int[36];
            int value = 1;
            int suit = 0;
            for (int i = 0; i < 36; i++)
            {
                if (value > 9)
                    value = 1;
                if (suit > 3)
                    suit = 0;
                int result = 10 * value++ + suit++;
                deckArray[i] = result;
            }
            Shuffle();
            for (int i = 0; i < 36; i++)
            {
                deckList.Add(deckArray[i]);
            }
            var newTrump = new Random();
            trump = newTrump.Next(0, 3);
            var newTurn = new Random();
            turn = newTurn.Next(0, 1);
        }

        public void GiveCard()
        {
            while ((playerCards.Count < 6) && (deckList.Count > 0))
            {
                    playerCards.Add(deckList[deckList.Count - 1]);
                    deckList.RemoveAt(deckList.Count - 1);
            }
            while ((computerCards.Count < 6) && (deckList.Count > 0))
            {
                    computerCards.Add(deckList[deckList.Count - 1]);
                    deckList.RemoveAt(deckList.Count - 1);
            }
        }

        public int ComputerLogic(int player)
        {
            int Attack()
            {
                int minCard = computerCards[0];
                if (tableCards.Count == 0) // выбирается карта для начала хода
                {
                    for (int i = 1; i < computerCards.Count; i++) // в этом цикле определяется минимальная карта в руке компьютера
                    {
                        
                        if (((computerCards[i] / 10) < (minCard / 10)) && ((computerCards[i] % 10) != trump))
                        {
                            minCard = computerCards[i];
                        }
                    }
                    table.Text = table.Text + minCard.ToString();
                    tableCards.Add(minCard);
                    computerCards.Remove(minCard);
                    return 0;
                }
                else // выбираются катры для подкидывания
                {
                    for (int i = 0; i < tableCards.Count; i++)
                    {
                        for (int j = 0; j < computerCards.Count; j++)
                        {
                            if (((tableCards[i] / 10) == (computerCards[j] / 10)) && ((computerCards[j] % 10) != trump))
                            {
                                table.Text = table.Text + computerCards[j].ToString();
                                tableCards.Add(computerCards[j]);
                                computerCards.Remove(computerCards[j]);
                                return 0;
                            }
                        }
                    }
                    return 1;
                }
            }

            int Defense()
            {
                int minCard = 99;
                if ((tableCards[tableCards.Count - 1] % 10) != trump)
                {
                    for (int i = 0; i < computerCards.Count; i++)
                    {
                        if (((computerCards[i] / 10) > (tableCards[tableCards.Count - 1] / 10)) &&
                            ((computerCards[i] % 10) == (tableCards[tableCards.Count - 1] % 10)))
                        {
                            minCard = computerCards[i];
                        }
                    }
                    if (minCard == 99)
                    {
                        for (int i = 0; i < computerCards.Count; i++)
                        {
                            if (((computerCards[i] % 10) == trump) && ((computerCards[i] / 10) < minCard))
                            {
                                minCard = computerCards[i];
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < computerCards.Count; i++)
                    {
                        if (((computerCards[i] / 10) > (tableCards[tableCards.Count - 1] / 10)) &&
                            ((computerCards[i] % 10) == trump))
                        {
                            minCard = computerCards[i];
                        }
                    }
                }
                if (minCard != 99)
                {
                    tableCards.Add(minCard);
                    table.Text = table.Text + " " + minCard.ToString();
                    computerCards.Remove(minCard);
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            if (turn == 0)
                return Defense();
            else
                return Attack();
        }

        public void GameProcess()
        {
            trumpLbl.Text = trumpLbl.Text + " " + trump.ToString();
            int i = 0;
            while (i < deckList.Count)
            {
                defDeck.Text = defDeck.Text + " " + deckList[i];
                i++;
            }
            GiveCard(); // раздача карт в начале игры 
            if ((deckList.Count != 0) && ((playerCards.Count != 0) || (computerCards.Count != 0)))
            {
                GiveCard(); // раздача карт по ходу игры 
                cardCount.Text = "Cards in deck count: " + deckList.Count.ToString();
                i = 0;
                while (i < deckList.Count)
                {
                    giveDeck.Text = giveDeck.Text + " " + deckList[i];
                    i++;
                }
                for (int j = 0; j < 6; j++)
                {
                    myCards.Text = myCards.Text + " " + playerCards[j].ToString();
                    enemyCard.Text = enemyCard.Text + " " + computerCards[j].ToString();
                }
                turn = 1;
                int computerTurn = 0;
                if (turn == 0)
                {
                    while (computerTurn == 0)
                    {
                        // здесь пользователь выбирает карту
                        // и помещает её на стол
                        tableCards.Add(playerCards[0]);
                        computerTurn = ComputerLogic(); // здесь будет вызываться метод Defense
                    }
                }
                else
                {
                    if (ComputerLogic() == 1) // здесь будет вызываться метод Attack
                    {
                        computerCards.AddRange(tableCards);
                        tableCards.Clear();
                        
                    }
                    // здесь игрок выбирает карту, чтобы отбиться
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckListInit();
            GameProcess();
        }
    }
}
