using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tool
{
    public partial class Window : Form
    {
        private Core core;

        public Window()
        {
            InitializeComponent();
            this.txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.core = new Core();

            this.lblCard.Click += new EventHandler(delegate (object sender1, EventArgs e1)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "PNG角色卡|*.png";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    FileInfo f = new FileInfo(Path.GetFullPath(file.FileName));
                    FileStream fin = new FileStream(f.FullName, FileMode.Open);
                    byte[] fc = new byte[f.Length];
                    fin.Read(fc, 0, fc.Length);
                    fin.Close();

                    if (this.core.SetData(fc))
                    {
                        byte gender = this.core.GetGender();
                        switch (gender)
                        {
                            case Core.MALE:
                                this.rbtnMale.Checked = true;
                                break;
                            case Core.FEMALE:
                                this.rbtnFemale.Checked = true;
                                break;
                            default:
                                MessageBox.Show("无效的人物卡", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("无效的人物卡", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Image card = Image.FromStream(new MemoryStream(fc));
                    if ((double)card.Width / (double)card.Height > (double)this.lblCard.Width / (double)this.lblCard.Height)
                    {
                        double scale = (double)card.Width / (double)this.lblCard.Width;
                        this.lblCard.Image = card.GetThumbnailImage(this.lblCard.Width, (int)(card.Height / scale), null, IntPtr.Zero);
                    }
                    else
                    {
                        double scale = (double)card.Height / (double)this.lblCard.Height;
                        this.lblCard.Image = card.GetThumbnailImage((int)(card.Width / scale), this.lblCard.Height, null, IntPtr.Zero);
                    }

                    

                    this.lblCard.Text = "";
                    this.txtCard.Text = Path.GetFileNameWithoutExtension(file.FileName);
                }
            });

            this.btnPath.Click += new EventHandler(delegate (object sender1, EventArgs e1)
            {
                FolderBrowserDialog dir = new FolderBrowserDialog();
                if (dir.ShowDialog() == DialogResult.OK)
                {
                    this.txtPath.Text = dir.SelectedPath;
                }
            });

            this.btnActive.Click += new EventHandler(delegate (object sender1, EventArgs e1)
            {
                if(!this.core.Check())
                {
                    MessageBox.Show("未选择人物卡", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Directory.Exists(txtPath.Text))
                {
                    MessageBox.Show("输出路径不存在或不合法", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte gender = this.rbtnMale.Checked ? Core.MALE : Core.FEMALE;
                if (string.IsNullOrWhiteSpace(txtFilename.Text))
                {
                    string name = this.core.DefaultName(gender);
                    if (MessageBox.Show("未指定输出文件名，将使用" + name + "作为默认文件名，可以吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        this.txtFilename.Text = name;
                    }
                    else
                    {
                        return;
                    }
                }

                string outputName = this.formatOutputPath();
                if (File.Exists(outputName))
                {
                    if (MessageBox.Show(outputName + "已存在，确定要替换吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                if (this.core.Save(outputName, gender))
                {
                    MessageBox.Show("已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("似乎哪里没对", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private string formatOutputPath()
        {
            string s = txtFilename.Text;
            if (!s.ToLower().EndsWith(".png"))
            {
                s += ".png";
            }
            if (this.txtPath.Text.EndsWith("\\") || this.txtPath.Text.EndsWith("/"))
            {
                s = Path.GetFullPath(this.txtPath.Text + s);
            }
            else
            {
                s = Path.GetFullPath(this.txtPath.Text + "/" + s);
            }
            return s;
        }
    }
}
