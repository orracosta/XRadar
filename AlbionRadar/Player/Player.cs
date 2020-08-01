using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRada.Player
{
    public class Player
    {
        private Single posX;
        private Single posY;
        private string nickname;
        private string guild;
        private string alliance;
        private int id;

        // items
        private short weapon;
        private short secundaryWeapon;
        private short helm;
        private short armor;
        private short boot;
        private short bag;
        private short cape;
        private short mount;
        private short potion;
        private short food;

        public Player()
        {
            posX = 0;
            posY = 0;
            nickname = "";
            guild = "";
            alliance = "";
            id = 0;

            //items
            weapon = 0;
            secundaryWeapon = 0;
            helm = 0;
            armor = 0;
            boot = 0;
            bag = 0;
            cape = 0;
            mount = 0;
            potion = 0;
            food = 0;
        }
        public Player(Single posX, Single posY, String nickname, String guild, String alliance, int id, short weapon, short secundaryWeapon, short helm, short armor, short boot, short bag, short cape, short mount, short potion, short food)
        {
            this.posX = posX;
            this.posY = posY;
            this.nickname = nickname;
            this.guild = guild;
            this.alliance = alliance;
            this.id = id;

            // items
            this.weapon = weapon;
            this.secundaryWeapon = secundaryWeapon;
            this.helm = helm;
            this.armor = armor;
            this.boot = boot;
            this.bag = bag;
            this.cape = cape;
            this.mount = mount;
            this.potion = potion;
            this.food = food;
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
        public short Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public short SecundaryWeapon
        {
            get { return secundaryWeapon; }
            set { secundaryWeapon = value; }
        }
        public short Helm
        {
            get { return helm; }
            set { helm = value; }
        }
        public short Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public short Boot
        {
            get { return boot; }
            set { boot = value; }
        }
        public short Bag
        {
            get { return bag; }
            set { bag = value; }
        }
        public short Cape
        {
            get { return cape; }
            set { cape = value; }
        }
        public short Mount
        {
            get { return mount; }
            set { mount = value; }
        }
        public short Potion
        {
            get { return potion; }
            set { potion = value; }
        }
        public short Food
        {
            get { return food; }
            set { food = value; }
        }
    }
}
