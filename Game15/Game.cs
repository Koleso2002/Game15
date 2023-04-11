using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game15
{
    [Serializable]
    internal class Game
    {
        private int[,] array;

        [NonSerialized]
        private Button[] buttons;

        public Game(Control.ControlCollection control)
        {
            buttons = ButonsCreator.CreateButtons();
            control.AddRange(buttons);
            array = new int[4, 4];
            List<int> list = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
            }
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int index = rand.Next(0, list.Count);
                    array[i, j] = list[index];
                    list.RemoveAt(index);
                }
            }
            Show();
            foreach (var item in buttons)
            {
                item.Click += ClickMethod;
            }
        }

        public void Resume(Control.ControlCollection control)
        {
            buttons=ButonsCreator.CreateButtons();
            control.AddRange(buttons);
            foreach (var item in buttons)
            {
                item.Click += ClickMethod;
            }
            Show();
        }

        private void ClickMethod(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int row = 0;
                int col = 0;
                int nullrow = 0;
                int nullcol = 0;
                int.TryParse(button.Text, out int number);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (number == array[i, j])
                        {
                            row = i;
                            col = j;
                        }
                        if (array[i, j] == 0)
                        {
                            nullrow = i;
                            nullcol = j;
                        }
                    }
                }
                //if(Math.Abs(nullrow==row))
                
                if (nullrow == row && nullcol - 1 == col ||
                    nullrow == row && nullcol + 1 == col ||
                    nullrow + 1 == row && nullcol == col ||
                    nullrow - 1 == row && nullcol == col)
                {
                    array[nullrow, nullcol] = array[row, col];
                    array[row, col] = 0;
                    Show();
                }
            }
        }

        public void Show()
        {
            int index = 0;
            bool final = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[index].Text = array[i, j].ToString();
                    buttons[index].Visible = true;

                    if (buttons[index].Text == "0")
                    {
                        buttons[index].Visible = false;
                    }
                    if (final == true && index < 15)
                    {
                        final = (index+1).ToString() == buttons[index].Text;
                    }
                    index++;
                }
            }
            if (final)
            {
                foreach (var item in buttons)
                {
                    item.BackColor = Color.Red;
                }
            }

        }

    }
}
