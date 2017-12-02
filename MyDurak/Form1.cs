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

        public List<int> playerCards = new List<int>(); // карты игрока

        public List<int> computerCards = new List<int>(); // карты компьютера

        public List<int> tableCards = new List<int>(); // карты на столе

        public List<int> deckList = new List<int>(); // карты в колоде

        public int trump; // козырь

        public int turn; // ход

        public void RefreshLabels() // метод для обновления содержимого лейблов
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

        public void DeckListInit() // метод создает колоду карт, выбирпет козырь и чей будет первый ход
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
            void Shuffle() // процедура для тоасования колоды
            {
                void Swap(ref int first, ref int second) // велосипед
                {
                    int temp = first;
                    first = second;
                    second = temp;
                }
                var randomValue = new Random();
                for (int i = 35; i > 0; i--) // тасование колоды методом Фтшера - Йейтса
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
            trump = newTrump.Next(0, 3); // выбор козыря
            var newTurn = new Random();
            turn = newTurn.Next(0, 2); // выбор первого игрока
            trumpLbl.Text = trumpLbl.Text + " " + trump;
            for (int i = 0; i < deckList.Count; i++)
                defDeck.Text = defDeck.Text + " " + deckList[i];
            GiveCard();
            RefreshLabels();
            if (turn == 1)
            {
                int a = ComputerLogic();
            }
        }

        public void GiveCard() // метод выполняет раздачу карт игрокам
        {
            while ((playerCards.Count < 6) && (deckList.Count > 0)) // сдача карт игроку
            {
                playerCards.Add(deckList[deckList.Count - 1]);
                deckList.RemoveAt(deckList.Count - 1);
            }
            while ((computerCards.Count < 6) && (deckList.Count > 0)) // сдача карт компьютеру
            {
                computerCards.Add(deckList[deckList.Count - 1]);
                deckList.RemoveAt(deckList.Count - 1);
            }
        }

        public int ComputerLogic() // метод отвечает за логику компьютера
        {
            int Attack() // процедура атаки, вызывается, когда turn = 1
            {
                if (computerCards.Count != 0) // если у компьютера есть карты
                {
                    int minCard = 99;
                    if (tableCards.Count == 0) // выбирается карта для начала хода
                    {
                        for (int i = 0; i < computerCards.Count; i++) // в этом цикле определяется минимальная карта в руке компьютера
                        {
                            if (((computerCards[i] / 10) < (minCard / 10)) && ((computerCards[i] % 10) != trump)) // компьютер ищет минимальную некозырную карту
                            {
                                minCard = computerCards[i];
                            }
                        }
                        if (minCard == 99) // если у компьютера только козыри
                        {
                            for (int i = 0; i < computerCards.Count; i++) // в этом цикле определяется минимальный козырь в руке компьютера
                            {
                                if (((computerCards[i] / 10) < (minCard / 10)))
                                {
                                    minCard = computerCards[i];
                                }
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
                        for (int i = 0; i < tableCards.Count; i++) // каждая карта на столе
                        {
                            for (int j = 0; j < computerCards.Count; j++) // сравнивается с картами в руке
                            {
                                if (((tableCards[i] / 10) == (computerCards[j] / 10)) && ((computerCards[j] % 10) != trump)) // если значения карт совпадают, она будет подброшенна
                                {
                                    table.Text = table.Text + computerCards[j].ToString();
                                    tableCards.Add(computerCards[j]);
                                    computerCards.Remove(computerCards[j]);
                                    RefreshLabels();
                                    return 0;
                                }
                            }
                        }
                        turn = 0;
                        tableCards.Clear();
                        GiveCard();
                        RefreshLabels();
                        return 1;
                    }
                }
                return 1;
            }

            int Defense() // процедура защиты, вызывается, когда turn = 0
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
                    tableCards.Add(minCard); // кладет её на стол
                    table.Text = table.Text + " " + minCard.ToString();
                    computerCards.Remove(minCard);
                    RefreshLabels();
                    return 0;
                }
                else // если не нашел
                {
                    computerCards.AddRange(tableCards); // забирает карты со стола
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
                    //Application.Exit(); // Сделать что-нибудь адекватное
                }
                if (computerCards.Count == 0)
                {
                    MessageBox.Show("Sorry, you lose.");
                    //Application.Exit();
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
            RefreshLabels();
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
                            ((enemyCard % 10) == (myCard % 10)) || ((myCard % 10) == trump))
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
