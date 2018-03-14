using System.Windows.Forms;

namespace Tetris
{
    public class Player
    {
        /// <summary>
        /// Khai báo biến
        /// </summary>
        #region

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Panel panel;
        public Panel Panel
        {
            get { return panel; }
            set { panel = value; }
        }
        #endregion
        public Player(string name, Panel panel)
        {
            this.Name = name;
            this.Panel = panel;
        }
    }
}
