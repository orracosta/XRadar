using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionNetwork2D
{
    public class Player
    {
        private Single posX;
        private Single posY;
        private string nickname;
        private string guild;
        private string alliance;
        private int id;

        /* ITEMS
         * 0 = item principal
         * 1 = item secundario
         * 2 = elmo
         * 3 = armadura
         * 4 = bota
         * 5 = bolsa
         * 6 = capa
         * 7 = montaria
         * 8 = comida
         * 9 = poção
        */
        private short[] items;

        /* SKILLS
         * 0 = weapon - 1
         * 1 = weapon - 2
         * 2 = weapon - 3
         * 3 = chest
         * 4 = head
         * 5 = boots
        */
        private short[] skills;

        public Player()
        {
            posX = 0;
            posY = 0;
            nickname = "";
            guild = "";
            alliance = "";
            id = 0;
            items = new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            skills = new short[] { -1, -1, -1, -1, -1, -1 };
        }
        public Player(Single posX, Single posY, String nickname, String guild, String alliance, int id, short[] items, short[] skills)
        {
            this.posX = posX;
            this.posY = posY;
            this.nickname = nickname;
            this.guild = guild;
            this.alliance = alliance;
            this.id = id;
            this.items = items;
            this.skills = skills;
        }
        public override string ToString()
        {
            return nickname + "(" + id + "):" + guild + " " + alliance + " [" + posX + " " + posY + "]";
        }
        public Single PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public Single PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Guild
        {
            get { return guild; }
            set { guild = value; }
        }
        public string Alliance
        {
            get { return alliance; }
            set { alliance = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public short[] Items
        {
            get { return items; }
            set { items = value; }
        }
        public short[] Skills
        {
            get { return skills; }
            set { skills = value; }
        }
    }
}
