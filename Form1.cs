using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Song
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //song字串陣列存放歌曲名稱
        string[] song = new string[] {"傻子","我好像在哪見過你","十年","溫柔","勢在必行","末班車","小孩","愛你","阿飛的小蝴蝶","王妃" };
        //singer字串陣列存放歌手姓名
        string[] singer = new string[] {"林宥嘉","薛之謙","陳奕迅","五月天","陳勢安","蕭煌奇","薛之謙","陳芳語","蕭敬騰","蕭敬騰" };
        int[] no = new int[10]; //no整數陣列存放排名
        
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < no.Length; i++) //設定no陣列的初值
            {
                no[i] = i + 1;
            }
            btnSortNo_Click(sender, e); 
        }
        
        private void btnSortNo_Click(object sender, EventArgs e)
        {
            int[] temp = new int[no.Length];//宣告temp整數陣列，大小和no陣列相同
            no.CopyTo(temp, 0);   //將no陣列的內容複製到temp陣列
            Array.Sort(no, song);   //nog陣列遞增排序，song陣列同步調整
            Array.Sort(temp, singer);   //temp陣列遞增排序，singer陣列同步調整
            string msg = "排名" + "\t" + "歌手" + "\t" + "歌曲" + Environment.NewLine;
            for (int i = 0; i < song.Length; i++)
            {
                msg += no[i].ToString() + "\t" + singer[i] + "\t" + song[i] + Environment.NewLine;
            }
            txtMsg.Text = msg;  
        }
        
        private void btnSortSong_Click(object sender, EventArgs e)
        {
            string[] temp = new string[song.Length];//宣告temp字串陣列，大小和song陣列相同
            song.CopyTo(temp, 0);   //將song陣列的內容複製到temp陣列
            Array.Sort(song, no);   //song陣列遞增排序，no陣列同步調整
            Array.Sort(temp, singer);   //temp陣列遞增排序，singer陣列同步調整
            string msg = "排名" + "\t" + "歌手" + "\t" + "歌曲" + Environment.NewLine;
            for (int i = 0; i < song.Length; i++)
            {
                msg += no[i].ToString() + "\t" + singer[i] + "\t" + song[i] + Environment.NewLine;
            }
            txtMsg.Text = msg;  
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSinger.Text; //取得使用者查詢的歌手姓名
            string msg = "找不到" + search; //預設找不到
            int index = Array.IndexOf(singer, search);   //搜尋第一個歌手
            if (index >= 0) //若有找到相符的資料
            {
                msg = "排名" + "\t" + "歌手" + "\t" + "歌曲" + Environment.NewLine;
                while (index >= 0)   //當index >= 0繼續迴圈
                {
                    msg += no[index].ToString() + "\t" + singer[index] + 
                        "\t" + song[index] + Environment.NewLine; ;   //顯示資料內容
                    index = Array.IndexOf(singer, search, index + 1); //從下一筆繼續搜尋
                };
            }
            txtMsg.Text = msg;  
        }
    }
}
