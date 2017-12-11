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

        public List<Panel> cardsPanel = new List<Panel>();

        public void CardDrowing()
        {
            pictureBox2.Controls.Clear();
            pictureBox4.Controls.Clear();
            pictureBox5.Controls.Clear();
            for (int i = 0; i < computerCards.Count; i++) // отрисовка карт у компьютера
            {
                 Panel pn1 = new Panel();
                 pn1.Left = i * (500 - 71) / computerCards.Count;
                 pn1.Width = 71;
                 pn1.Height = 96;
                 pn1.Top = 0;
                 Image bmp = Image.FromFile(Application.StartupPath + "/bitmaps/" + "single.bmp");
                 pn1.BackgroundImage = bmp;
                 pictureBox2.Controls.Add(pn1);
            }

            for (int i = 0; i < playerCards.Count; i++) // отрисовка карт у игрока
            {
                if (playerCards[i] != 99)
                {
                    Panel pn1 = new Panel();
                    pn1.Left = i * (500 - 71) / playerCards.Count;
                    pn1.Width = 71;
                    pn1.Height = 96;
                    pn1.Top = 0;
                    pn1.Tag = playerCards[i];
                    pn1.MouseDoubleClick += pn_MouseDoubleClick;
                    cardsPanel.Add(pn1);
                    Image bmp = Image.FromFile(Application.StartupPath + "/bitmaps/" + playerCards[i].ToString() + ".bmp");
                    pn1.BackgroundImage = bmp;
                    pictureBox4.Controls.Add(pn1);
                }
            }

            for (int i = tableCards.Count; i > 0; i--)
            {
                if (tableCards[i-1] != 99)
                {
                    Panel pn1 = new Panel();
                    pn1.Left = i * (71 - 20);
                    pn1.Width = 71;
                    pn1.Height = 96;
                    pn1.Top = 100;
                    Image bmp = Image.FromFile(Application.StartupPath + "/bitmaps/" + tableCards[i-1].ToString() + ".bmp");
                    pn1.BackgroundImage = bmp;
                    pictureBox5.Controls.Add(pn1);
                }
            }
        }

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
            GC.Collect();
            pictureBox6.Image = null;
            deckList.Clear();
            computerCards.Clear();
            playerCards.Clear();
            tableCards.Clear();
            ClearLabels();
            int[] deckArray = new int[36];
            void Shuffle() // процедура для тасования колоды
            {
                void Swap(ref int first, ref int second) // велосипед
                {
                    int temp = first;
                    first = second;
                    second = temp;
                }
                var randomValue = new Random();
                for (int i = 35; i > 0; i--) // тасование колоды методом Фишера - Йейтса
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
            string trumpImage = (90 + trump).ToString();
            Image bmp = Image.FromFile(Application.StartupPath + "/bitmaps/" + Convert.ToString(trumpImage) + ".bmp");
            pictureBox6.Image = bmp;
        }

        public void GiveCard() // метод выполняет раздачу карт игрокам
        {
            while (((playerCards.Count < 6) || (computerCards.Count < 6)) && (deckList.Count > 0)) // сдача карт игрокам
            {
                if (playerCards.Count < 6)
                {
                    playerCards.Add(deckList[deckList.Count - 1]);
                    deckList.RemoveAt(deckList.Count - 1);
                }
                if (computerCards.Count < 6)
                {
                    computerCards.Add(deckList[deckList.Count - 1]);
                    deckList.RemoveAt(deckList.Count - 1);
                }
            }
            CardDrowing();
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
                            if (((computerCards[i] / 10) <= (minCard / 10)) && ((computerCards[i] % 10) != trump)) // компьютер ищет минимальную некозырную карту
                            {
                                minCard = computerCards[i];
                            }
                        }
                        if (minCard == 99) // если у компьютера только козыри
                        {
                            for (int i = 0; i < computerCards.Count; i++) // в этом цикле определяется минимальный козырь в руке компьютера
                            {
                                if (((computerCards[i] / 10) <= (minCard / 10)))
                                {
                                    minCard = computerCards[i];
                                }
                            }
                        }
                        if (computerCards.Count == 1)
                        {
                            tableCards.Add(computerCards[0]);
                            computerCards.RemoveAt(0);
                            RefreshLabels();
                            CardDrowing();
                            return 0;
                        }
                        table.Text = table.Text + minCard.ToString();
                        tableCards.Add(minCard);
                        computerCards.Remove(minCard);
                        RefreshLabels();
                        CardDrowing();
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
                                    CardDrowing();
                                    return 0;
                                }
                            }
                        }
                        turn = 0;
                        tableCards.Clear();
                        GiveCard();
                        RefreshLabels();
                        CardDrowing();
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
                    MessageBox.Show("Беру :(", "Бот");
                    WinnerCheck();
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
                    MessageBox.Show("Вы победили, поздравляем!", "Игра");
                    //Application.Exit(); // Сделать что-нибудь адекватное
                    NewGame();
                }
                if (computerCards.Count == 0)
                {
                    MessageBox.Show("Вы проиграли.", "Игра");
                    //Application.Exit();
                    NewGame();
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void NewGame()
        {
            DeckListInit();
            throwButton.Enabled = true;
            getButton.Enabled = true;
            bitoButton.Enabled = true;
            //GameProcess();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void pn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(((Panel)sender).Tag.ToString());
            //cardsPanel[pictureBox4.Controls.GetChildIndex((Control)sender)].Tag.ToString());
           // MessageBox.Show(((Panel)sender).ToString());
            //cardsPanel[pictureBox4.Controls.GetChildIndex((Control)sender)].ToString());
            WinnerCheck();
            //index.Text = index.Text + " " + pictureBox4.Controls.GetChildIndex((Control)sender).ToString();
            int myCard = (int)(((Panel)sender).Tag);
                //cardsPanel[pictureBox4.Controls.GetChildIndex((Control)sender)].Tag;
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
                        cardsPanel.RemoveAt(pictureBox4.Controls.GetChildIndex((Control)sender));
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
                            cardsPanel.RemoveAt(pictureBox4.Controls.GetChildIndex((Control)sender));
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
                            cardsPanel.RemoveAt(pictureBox4.Controls.GetChildIndex((Control)sender));
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
                            cardsPanel.RemoveAt(pictureBox4.Controls.GetChildIndex((Control)sender));
                            RefreshLabels();
                            int a = ComputerLogic(); // здесь будет вызван метод Attack
                        }
                    }
                }
            }
            CardDrowing();
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
                if (computerCards.Count > 0)
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
            CardDrowing();
            WinnerCheck();
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

        public int mode1 = -1;
        
        private void режимОтладкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode1 *= -1;
            if (mode1 > 0)
            {
                defDeck.Visible = true;
                giveDeck.Visible = true;
                cardCount.Visible = true;
                turnlbl.Visible = true;
                index.Visible = true;
            }
            else
            {
                defDeck.Visible = false;
                giveDeck.Visible = false;
                cardCount.Visible = false;
                turnlbl.Visible = false;
                index.Visible = false;
            }
        }

        public int mode2 = -1;

        private void ручнойРежиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode2 *= -1;
            if (mode2 > 0)
            {
                enemyCard.Visible = true;
                table.Visible = true;
                myCards.Visible = true;
                throwButton.Visible = true;
                playerChoice.Visible = true;
            }
            else
            {
                enemyCard.Visible = false;
                table.Visible = false;
                myCards.Visible = false;
                throwButton.Visible = false;
                playerChoice.Visible = false;
            }
        }
    }
}
