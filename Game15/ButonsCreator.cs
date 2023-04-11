using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game15
{
    static class ButonsCreator
    {
        public static Button[] CreateButtons()
        {
            Button[] buttons = new Button[16];
            int width=0;
            int height=0;
            for (int i = 0; i < 16; i++)
            {
                buttons[i] = new Button();
                buttons[i].Size = new Size(50, 50);
                buttons[i].BackColor = Color.Yellow;
                buttons[i].Location = new Point(width,height);
                width += 55;
                if ((i + 1) % 4 == 0)
                {
                    height += 55;
                    width = 0;
                }
            }
            return buttons;
        }  

    }
}
