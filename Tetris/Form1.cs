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
            Control.CheckForIllegalCrossThreadCalls = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
        public void PlayGame(Player player)
        {
            currentBlock = action.CreatBlock();
            nextBlock = action.CreatBlock();
            action.DrawBlock(player, currentBlock);
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
            //Listen();
        }

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

        public void SendData()
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

        private void button1_Click(object sender, EventArgs e)//button Connect
        {
            socket.IP = txtIP.Text.Trim();
            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                pnlServer.Visible = true;
                pnlClient.Visible = true;
                pnlServerInClient.Visible = false;
                pnlLogin.Visible = false;
                socket.isServer = true;
            }
            else
            {
                pnlServer.Visible = true;
                pnlClient.Visible = true;
                pnlClientInServer.Visible = false;
                pnlLogin.Visible = false;
                socket.isServer = false;
                Listen();
            }

            if (socket.isServer == true)
            {
                lbName.Text = "Player Server";
                action.Init(pnlServer);
                // board.ShowBoard2(pnlClient);
                pnlClient.BackColor = Color.Gray;
                lbInfoClient.Text = "Chờ thông tin từ Client";
            }
            else
            {
                lbName.Text = "Player Client";
                action.Init2(pnlClient);
                pnlServer.BackColor = Color.Gray;
                lbInfoServer.Text = "Chờ thông tin từ Server";
                // board.ShowBoard1(pnlServer);
            }
            player = action.setPlayer(socket.isServer, pnlServer, pnlClient);
            PlayGame(player);
            timer1.Enabled = true;
        }

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
            }
            Listen();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            }
        }
        public void Pause()
        {
            timer1.Enabled = !timer1.Enabled;
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
            if(player.Name == "Player_Server")
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
    }
}
