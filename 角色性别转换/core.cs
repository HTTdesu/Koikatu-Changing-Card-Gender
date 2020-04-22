using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tool

{
    class Core
    {
        public const byte MALE = 0x00;
        public const byte FEMALE = 0x01;

        private byte[] data;
        private int index;

        public Core()
        {
            this.Init();
        }

        private void Init()
        {
            this.data = null;
            this.index = -1;
        }

        public bool SetData(byte[] data)
        {
            byte[] header = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            if(!this.MagicCheck(data, 0, header))
            {
                this.Init();
                return false;
            }
            this.index = 8;

            byte[] blockIEND = { 0x00, 0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 };
            while(true)
            {
                if (MagicCheck(data, this.index, blockIEND))
                {
                    this.index += 12;
                    break;
                }
                else
                {
                    this.index += GetBlockLength(data, this.index);
                }
            } // 跳过封面PNG

            this.index += 4 + 20 + 5; // 跳过学生证文件头
            this.index += ReadInt32(data, this.index) + 4; // 跳过学生证缩略图

            byte[] keywords = { 0x73, 0x65, 0x78 };
            byte[] checkTail = { 0xA8, 0x6C, 0x61, 0x73, 0x74, 0x6E, 0x61, 0x6D, 0x65 };
            while(true)
            {
                this.index = this.KMP(data, this.index, keywords);
                if(this.index < 0)
                {
                    this.Init();
                    return false;
                }
                this.index += keywords.Length;

                // A problem has been found that some plugins will add extra bytes behind the sex parameter
                // So, if you are facing such a problem, which means that your character card was wrongly judged
                // Commit out the 'if' below, also and a break
                // Remember, this will increase the risk of destroing your new card

                if(this.MagicCheck(data, this.index + 1, checkTail))
                {
                    break;
                }
            }

            this.data = data;
            return true;
        }

        public bool Check()
        {
            if(this.data != null && this.index >= 0)
            {
                return true;
            }
            return false;
        }

        public byte GetGender()
        {
            if(this.Check())
            {
                return this.data[this.index];
            }
            else
            {
                return 0xFF;
            }
        }

        public bool Save(string path, byte gender)
        {
            this.data[this.index] = gender;

            FileStream fout = new FileStream(path, FileMode.OpenOrCreate);
            fout.Write(this.data, 0, this.data.Length);
            fout.Flush();
            fout.Close();

            return true;
        }

        public string DefaultName(byte gender)
        {
            StringBuilder name = new StringBuilder("Koikatu_");
            if(gender == Core.MALE)
            {
                name.Append("M_");
            }
            else
            {
                name.Append("F_");
            }
            name.Append(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            name.Append(".png");

            return name.ToString();
        }

        private bool MagicCheck(byte[] target, int offset, byte[] magic)
        {
            for (int i = 0; i < magic.Length; i++)
            {
                if (target[offset + i] != magic[i])
                {
                    return false;
                }
            }

            return true;
        }

        private int ReadInt32(byte[] data, int offset)
        {
            int l = 0;
            l = l | data[offset + 3];
            l = l << 8;
            l = l | data[offset + 2];
            l = l << 8;
            l = l | data[offset + 1];
            l = l << 8;
            l = l | data[offset];

            return l;
        }

        private int GetBlockLength(byte[] card, int start)
        {
            int l = 0;
            l = l | card[start];
            l = l << 8;
            l = l | card[start + 1];
            l = l << 8;
            l = l | card[start + 2];
            l = l << 8;
            l = l | card[start + 3];

            return l + 12;
        }

        private int KMP(byte[] data, int offset, byte[] target)
        {
            int[] next = new int[target.Length];
            next[0] = 0;
            for(int i = 1, j = 0; i < next.Length; i++)
            {
                while(j > 0 && target[i] != target[j])
                {
                    j = next[j - 1];
                }

                if(target[i] == target[j])
                {
                    j++;
                }
                next[i] = j;
            }

            for (int i = offset, j = 0; i < data.Length; i++)
            {
                while(j > 0 && data[i] != target[j])
                {
                    j = next[j - 1];
                }

                if(data[i] == target[j])
                {
                    j++;
                }
                if(j == target.Length)
                {
                    return i - target.Length + 1;
                }
            }

            return -1;
        }
    }
}
