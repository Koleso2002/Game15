using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Game15
{
    public partial class Form1 : Form
    {
        Game obj;
        BinaryFormatter bf;
        public Form1()
        {
            InitializeComponent();
            //foreach (var item in ButonsCreator.CreateButtons())
            //{
            //    this.Controls.Add(item);
            //}

            //this.Controls.AddRange(ButonsCreator.CreateButtons());
            bf = new BinaryFormatter();
            obj = LoadGame();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            using (Stream write = File.Create("Save"))
            {
                bf.Serialize(write, obj);
            }
        }

        private Game LoadGame()
        {
            if (File.Exists("Save"))
                using (Stream read = File.OpenRead("Save"))
                {
                    object value = bf.Deserialize(read);
                    if (value is Game)
                    {
                        Game o=value as Game;
                        o.Resume(this.Controls);
                        return o;
                    }
                }     
            return new Game(this.Controls);
        }
    }

}

