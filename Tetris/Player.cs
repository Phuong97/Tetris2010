using System.Windows.Forms;

namespace Tetris
{
    public class Player
    {
        private string name;
        private Panel panel;
        public string Name { get => name; set => name = value; }
        public Panel Panel { get => panel; set => panel = value; }

        public Player(string name, Panel panel)
        {
            this.Name = name;
            this.Panel = panel;
        }
    }
}
