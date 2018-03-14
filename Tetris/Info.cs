namespace Tetris
{
    public class Info
    {
        #region
        /// <summary>
        /// Khai báo biến
        /// </summary>
        int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion
        public Info()
        {
            Score = 0;
            Level = 0;
            Speed = 0;
        }


        public void UpLevel(Info info, int score)
        {
            info.Score += 10;
            if (info.Score == 100)
            {
                info.Level++;
                info.Score = 0;
                info.Speed -= 200;
            }
        }
    }

}
