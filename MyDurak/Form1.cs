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

        public void RefreshLabels()
        {
            table.Text = "Table:";
            myCards.Text = "My cards:";
            enemyCard.Text = "Enemy cards:";
            giveDeck.Text = "Current deck:";
            cardCount.Text = "Card in deck count:";
            for (int i = 0; i < tableCards.Count; i++)
                table.Text = table.Text + " " + tableCards[i];
            for (int i = 0; i < playerCards.Count; i++)
                myCards.Text = myCards.Text + " " + playerCards[i];
            for (int i = 0; i < computerCards.Count; i++)
                enemyCard.Text = enemyCard.Text + " " + computerCards[i];
            for (int i = 0; i < deckList.Count; i++)
                giveDeck.Text = giveDeck.Text + " " + deckList[i];
            cardCount.Text = cardCount.Text + " " + deckList.Count;
            turnlbl.Text = turnlbl.Text + " " + turn;
        }

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
                turnlbl.Text = "Turn:";
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
            turn = 0;
            trumpLbl.Text = trumpLbl.Text + " " + trump;
            for (int i = 0; i < deckList.Count; i++)
                defDeck.Text = defDeck.Text + " " + deckList[i];
            GiveCard();
            RefreshLabels();
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

        public int ComputerLogic()
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
                    RefreshLabels();
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
                                RefreshLabels();
                                return 0;
                            }
                        }
                    }
                    RefreshLabels();
                    turn = 0;
                    return 1;
                }
            }

            int Defense()
            {
                int minCard = 99;
                if ((tableCards[tableCards.Count - 1] % 10) != trump) // если ИИ надо отбиваться от некозырной карты
                {
                    for (int i = 0; i < computerCards.Count; i++) // ИИ ищет катры среди некозырных
                    {
                        if (((computerCards[i] / 10) > (tableCards[tableCards.Count - 1] / 10)) &&
                            ((computerCards[i] % 10) == (tableCards[tableCards.Count - 1] % 10)))
                        {
                            minCard = computerCards[i];
                        }
                    }
                    if (minCard == 99) // если не нашел, то
                    {
                        for (int i = 0; i < computerCards.Count; i++) // ищет среди козырных
                        {
                            if (((computerCards[i] % 10) == trump) &&
                                ((computerCards[i] / 10) < minCard))
                            {
                                minCard = computerCards[i];
                            }
                        }
                    }
                }
                else // если ИИ надо отбиться от козырной карты
                {
                    for (int i = 0; i < computerCards.Count; i++) // ИИ ищет подходящий козырь
                    {
                        if (((computerCards[i] / 10) > (tableCards[tableCards.Count - 1] / 10)) &&
                            ((computerCards[i] % 10) == trump))
                        {
                            minCard = computerCards[i];
                        }
                    }
                }
                if (minCard != 99) // если ИИ нашел подходящую карту
                {
                    tableCards.Add(minCard);
                    table.Text = table.Text + " " + minCard.ToString();
                    computerCards.Remove(minCard);
                    RefreshLabels();
                    return 0;
                }
                else // если не нашел
                {
                    computerCards.AddRange(tableCards);
                    tableCards.Clear();
                    GiveCard();
                    RefreshLabels();
                    MessageBox.Show("Бот: беру :(");
                    return 1;
                }
            }

            if (turn == 0)
                return Defense();
            else
                return Attack();
        }

        public void WinnerCheck()
        {
            if (deckList.Count == 0)
            {
                if (playerCards.Count == 0)
                {
                    MessageBox.Show("You win! Congratulation.");
                }
                if (computerCards.Count == 0)
                {
                    MessageBox.Show("Sorry, you lose.");
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckListInit();
            throwButton.Enabled = true;
            getButton.Enabled = true;
            bitoButton.Enabled = true;
            //GameProcess();
        }

        private void throwButton_Click(object sender, EventArgs e)
        {
            WinnerCheck();
            int myCard = (int)playerChoice.Value;
            if (turn == 0) // если сейчас игрок атакует 
            {
                if (tableCards.Count == 0) // если на столе нет карт, то мы кладем любую
                {
                    //int myCard = (int)playerChoice.Value;
                    if (playerCards.Contains(myCard))
                    {
                        tableCards.Add(myCard);
                        playerCards.Remove(myCard);
                        RefreshLabels();
                        int a = ComputerLogic(); // будет вызван метод Defense
                    }
                }
                else // если на столе есть карты, то мы кладем карту совпадающую по значению с теми, что на столе
                {
                    if (playerCards.Contains(myCard))
                    {
                        bool check = false;
                        for (int i = 0; i < tableCards.Count; i++)
                        {
                            if ((myCard / 10) == (tableCards[i] / 10))
                            {
                                check = true;
                            }
                        }
                        if (check)
                        {
                            tableCards.Add(myCard);
                            playerCards.Remove(myCard);
                            RefreshLabels();
                            int a = ComputerLogic(); // будет вызван метод Defense
                        }
                    }
                }
            }
            else // если игрок отбивается от карт противника
            {
                int enemyCard = tableCards[tableCards.Count - 1];
                if (playerCards.Contains(myCard))
                {
                    if ((enemyCard % 10) != trump) // если последняя карта на столе не козырная
                    {
                        if (((enemyCard / 10) < (myCard / 10)) && 
                            (((enemyCard % 10) == (myCard % 10)) || ((myCard % 10) == trump)))
                        {
                            tableCards.Add(myCard);
                            playerCards.Remove(myCard);
                            RefreshLabels();
                            int a = ComputerLogic(); // здесь будет вызван метод Attack
                        }
                    }
                    else // если последняя карта на столе козырная
                    {
                        if (((enemyCard / 10) < (myCard / 10)) && ((myCard % 10) == trump))
                        {
                            tableCards.Add(myCard);
                            playerCards.Remove(myCard);
                            RefreshLabels();
                            int a = ComputerLogic(); // здесь будет вызван метод Attack
                        }
                    }
                }
            }
        }

        private void bitoButton_Click(object sender, EventArgs e)
        {
            WinnerCheck();
            if ((turn == 0) && (tableCards.Count != 0))
            {
                tableCards.Clear();
                GiveCard();
                RefreshLabels();
                turn = 1;
                int a = ComputerLogic();
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            WinnerCheck();
            if (turn == 1)
            {
                playerCards.AddRange(tableCards);
                tableCards.Clear();
                GiveCard();
                RefreshLabels();
                int a = ComputerLogic();
            }
        }
    }
}
