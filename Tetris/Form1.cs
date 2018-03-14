using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;// giúp phân luồng thread k bị xung đột ạ.
            action = new Action();
            info = new Info();
            board = new Board();
            socket = new SocketManager();

        }
        Action action = new Action();
        Block currentBlock;
        Block nextBlock;
        Info info;
        Block nextnextBlock;
        Player player;
        Board board;
        SocketManager socket;
        int minutes;
        int second;
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            pnlLogin.Visible = true; //hiện panel connect

            btnModeClassic.Visible = false;
            btnModeTime.Visible = false;
            pnlClient.Visible = false;
            pnlServer.Visible = false;
            pnlServerInClient.Visible = false;
            pnlClientInServer.Visible = false;
            lbWatch.Visible = false;
            pictureBox1.Visible = false;
            minutes = 4; second = 60;
        }

        /// <summary>
        /// Load sẵn địa chỉ IP máy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            }
        }

        /// <summary>
        /// Load xong sẽ hiện bảng nhập IP và btn connect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//button Connect
        {
            socket.IP = txtIP.Text.Trim();
            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                pnlLogin.Visible = false;
                socket.isServer = true;
            }
            else
            {
                pnlLogin.Visible = false;
                socket.isServer = false;
                Listen();
            }

            if (socket.isServer == true) // nếu là server thì cho chọn chế độ
            {
                btnModeClassic.Visible = true;
                btnModeTime.Visible = true;
                lbName.Text = "Player Server";
            }
            else // client thì đợi
            {
                lb3sPlay.Text = "Đợi Server Chọn chế độ";
                lbName.Text = "Player Client";
            }
            player = action.setPlayer(socket.isServer, pnlServer, pnlClient);
            //xét người chơi là server hay client
        }

        /// <summary>
        /// Chọn chế độ chơi
        /// 1.Time Mode
        /// 2.Classic Mode 
        /// </summary>

        #region
        public void ModeTime()
        {
            lbWatch.Visible = true;
            pnlServer.Visible = true;
            pnlClient.Visible = true;
            if (player.Name == "Player_Server")
            {
                pnlServerInClient.Visible = false;
                pnlClientInServer.Visible = true;
            }
            else
            {
                lb3sPlay.Visible = false;
                pnlServerInClient.Visible = true;
                pnlClientInServer.Visible = false;

            }
            timerBegin.Enabled = true;/// Khởi động đếm ngc 3s r play
        }
        private void btnModeTime_Click(object sender, EventArgs e)
        {
            try
            {
                ModeTime();
                socket.Send(new SocketData((int)SocketCommand.MODETIME, null, null, "", 0, 0, 0));
                Listen();
            }
            catch
            {
                MessageBox.Show("Chưa có client kết nối đến.");
                timerBegin.Enabled = false;
                this.Close();
                return;
            }
        }

        public void ModeClassic()
        {
            pnlServer.Visible = true;
            pnlClient.Visible = true;
            if (player.Name == "Player_Server")
            {
                pnlServerInClient.Visible = false;
                pnlClientInServer.Visible = true;
            }
            else
            {
                lb3sPlay.Visible = false;
                pnlServerInClient.Visible = true;
                pnlClientInServer.Visible = false;

            }
            timerBegin.Enabled = true;
        }
        private void btnModeClassic_Click(object sender, EventArgs e)
        {
            try
            {
                ModeClassic();
                socket.Send(new SocketData((int)SocketCommand.MODECLASSIC, null, null, "", 0, 0, 0));
                Listen();
            }
            catch
            {
                MessageBox.Show("Chưa có client kết nối đến.");
                timerBegin.Enabled = false;
                this.Close();
                return;
            }
        }

        #endregion

        /// <summary>
        /// Sau khi server chọn Mode sẽ gửi đến cho client
        /// </summary>
        public void AfterClickMode()
        {
            if (player.Name == "Player_Server")
            {
                action.Init(pnlServer);// Panel server
                pnlClient.BackColor = Color.Gray;
                lbInfoClient.Text = "Chờ thông tin từ Client";
            }
            else
            {
                action.Init2(pnlClient); //Panel client
                pnlServer.BackColor = Color.Gray;
                lbInfoServer.Text = "Chờ thông tin từ Server";//pnael nhận dữ liệu
            }
        }

        /// <summary>
        /// Hàm count down 3s
        /// </summary>
        int count = 4;
        private void timerBegin_Tick(object sender, EventArgs e)
        {
            lb3sPlay.Visible = true;
            count--;
            lb3sPlay.Text = count.ToString();
            if (count == 0)
            {
                lb3sPlay.Visible = false;
                btnModeClassic.Visible = false;
                btnModeClassic.Enabled = false;
                btnModeTime.Enabled = false;
                btnModeTime.Visible = false;
                timerBegin.Enabled = false;
                AfterClickMode(); // show 2 panel chơi
                PlayGame(player); // Khởi tạo khối gạch
                timer1.Enabled = true;//timer làm rơi khối gạch
                timerWatch.Enabled = true;// bắt đầu đếm giờ
                menuStrip1.Visible = true;// hiện menu
            }
        }

        public void PlayGame(Player player)
        {
            currentBlock = action.CreatBlock(); //khởi tạo block
            nextBlock = action.CreatBlock(); //tạo block tiếp theo
            action.DrawBlock(player, currentBlock); //vẽ
            action.DrawBlockNext(player, nextBlock);
            action.setInfo(info, timer1.Interval);
            DrawInfo(player);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == true)/// Để khắc phục lỗi khi ấn phím xóa đổi địa chỉ IP
            {
                Block block;
                action.DeleteBlock(player, currentBlock);
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        block = action.MoveLeft(player, ref currentBlock);
                        action.DrawBlock(player, block);
                        break;
                    case Keys.Right:
                        block = action.MoveRight(player, ref currentBlock);
                        action.DrawBlock(player, block);
                        break;
                    case Keys.Down:
                        block = action.MoveDown(player, ref currentBlock);
                        action.DrawBlock(player, block);
                        break;
                    case Keys.Up:
                        block = action.Rotate(player, ref currentBlock);
                        action.DrawBlock(player, block);
                        break;
                    case Keys.Space:
                        MessageBox.Show("ấn sai phím");
                        break;
                    default://vô hiệu hóa các key còn lại k sẽ bị lỗi
                        //MessageBox.Show("ấn sai phím");
                        break;
                }
            }
        }

        public void DrawInfo(Player player)
        {
            if (player.Name == "Player_Server")
            {
                label1.Text = info.Score.ToString();
                label2.Text = info.Speed.ToString();
                label3.Text = info.Level.ToString();
            }
            else
            {
                label11.Text = info.Score.ToString();
                label12.Text = info.Speed.ToString();
                label10.Text = info.Level.ToString();
            }
        }

        public void DrawInfoSend(Player player, SocketData data)
        {
            if (player.Name == "Player_Server")
            {
                label11.Text = data.Score.ToString();
                label12.Text = data.Speed.ToString();
                label10.Text = data.Level.ToString();
            }
            else
            {
                label1.Text = data.Score.ToString();
                label2.Text = data.Speed.ToString();
                label3.Text = data.Level.ToString();
            }
        }

        /// <summary>
        /// hàm chạy chính của chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            action.DeleteBlock(player, currentBlock);
            action.DrawBlock(player, action.MoveDown(player, ref currentBlock));
            if (action.ConditionDown(player, currentBlock) == false)
            {
                nextnextBlock = action.CreatBlock();
                action.DrawBlockNext(player, nextnextBlock);
                action.DrawBlockInMap(player, currentBlock);
                int kq = action.Check(player, currentBlock, info);
                if (kq == 0 || kq == -1)
                {
                    timer1.Enabled = false;
                    socket.Send(new SocketData((int)SocketCommand.END_GAME, null, null, "", 0, 0, 0));
                }
                DrawInfo(player);
                action.DrawBlock(player, currentBlock);
                currentBlock = nextBlock;
                SendData();
                nextBlock = nextnextBlock;
                action.Draw(player);
                timer1.Interval = info.Speed;
            }
        }

        public void SendData()// Send vị trí sau mỗi lần xuống cuối
        {
            try
            {
                int[,] arr = action.getMap(player);
                socket.Send(new SocketData((int)SocketCommand.SEND_DATA, arr, currentBlock.Arr, player.Name, info.Level, info.Speed, info.Score));
                Listen();
            }
            catch
            {
                timer1.Enabled = false;
                MessageBox.Show("Lỗi kết nối");
                return;
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, null, null, "", 0, 0, 0));
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// LAN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


        public void Pause()
        {
            timer1.Enabled = !timer1.Enabled;
            timerWatch.Enabled = !timerWatch.Enabled;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            socket.Send(new SocketData((int)SocketCommand.PAUSE, null, null, "", 0, 0, 0));
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void NewGame()
        {
            int[,] arr = new int[22, 10];
            timer1.Interval = 900;
            timer1.Enabled = false;
            DrawInfo(player);
            action.ResetBoard(player);
            Thread.Sleep(1000);
            PlayGame(player);
            timer1.Enabled = true;
            minutes = 4;
            second = 60;
            if (player.Name == "Player_Server")
            {
                pnlClient.BackColor = Color.Gray;
                action.UpdatePanelAfterReceive("Player_Client", arr, pnlServer, pnlClient);
                lbInfoClient.Show();
            }
            else
            {
                pnlServer.BackColor = Color.Gray;
                action.UpdatePanelAfterReceive("Player_Server", arr, pnlServer, pnlClient);
                lbInfoServer.Show();
            }

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, null, null, "", 0, 0, 0));
        }

        /// <summary>
        /// Đồng hồ đếm 5p
        /// </summary>
        #region
        //Hàm chạy count time

        
        private void timerWatch_Tick(object sender, EventArgs e)
        {
            string b1 = ""; // biến s gán khi < 10 hiện 2 số cho đẹp

            second--;
            if (second == 0)
            {
                minutes--;
                second = 59;
            }
            if (minutes == 0 && second == 01)
            {
                timerWatch.Enabled = false;
                timer1.Enabled = false;
                FiveMinutes();//Hàm xét thắng thua
                second = 0;
                
            }
            if (second < 10)
            {
                b1 = "0" + second.ToString();
            }
            else
            {
                b1 = second.ToString();
            }
            lbWatch.Text = "0" + minutes.ToString() + " : " + b1.ToString();
        }
        #endregion
        //Lắng nghe nhận dữ liệu để xử lý
        public void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data;
                    data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        //Hàm xử lý bên nhận
        public void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.SEND_DATA:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lbInfoClient.Hide();
                        lbInfoServer.Hide();
                        DrawInfoSend(player, data);
                        action.DrawBlockSend(data.Name, data.Block, pnlServerInClient, pnlClientInServer);
                        action.UpdatePanelAfterReceive(data.Name, data.Board, pnlServer, pnlClient);
                    }));
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                    }));
                    break;
                case (int)SocketCommand.PAUSE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Pause();
                    }));
                    break;
                case (int)SocketCommand.QUIT:
                    timer1.Enabled = false;
                    MessageBox.Show("Người chơi cùng đã thoát");
                    break;
                case (int)SocketCommand.END_GAME:
                    timer1.Enabled = false;
                    MessageBox.Show("Người chơi cùng đã thua .Kết thúc game.");
                    break;
                case (int)SocketCommand.MODETIME:
                    this.Invoke((MethodInvoker)(() =>
                    {   
                        ModeTime();
                    }));
                    break;
                case (int)SocketCommand.MODECLASSIC:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ModeClassic();
                    }));
                    break;
            }
            Listen();
        }

        ///Xét thắng thua trong 5p
         public void FiveMinutes()
        {
            //score
            int scoreServer = Convert.ToInt32(label1.Text);
            int scoreClient = Convert.ToInt32(label11.Text);
            //level
            int levelServer = Convert.ToInt32(label3.Text);
            int levelClient = Convert.ToInt32(label10.Text);

            if (scoreServer > scoreClient && levelServer == levelClient)
            {
                MessageBox.Show("Server Thắng");
                timer1.Enabled = false;
            }
            else if (scoreServer < scoreClient && levelServer == levelClient)
            {
                MessageBox.Show("Client Thắng");
                timer1.Enabled = false;
            }
            else if (levelServer > levelClient)
            {
                MessageBox.Show("Server Thắng");
                timer1.Enabled = false;
            }
            else if (levelServer < levelClient)
            {
                MessageBox.Show("Client Thắng");
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Hòa");
                timer1.Enabled = false;
            }
        }


    }
}
