using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class Harvestable
    {
        private int id;
        private byte type;
        private byte tier;
        private Single posX;
        private Single posY;
        private byte charges;
        private byte size;

        public Harvestable(int id, byte type, byte tier, Single posX, Single posY, byte charges, byte size)
        {
            this.id = id;
            this.type = type;
            this.tier = tier;
            this.posX = posX;
            this.posY = posY;
            this.charges = charges;
            this.size = size;
        }
        public override string ToString()
        {
            return "id: " + id + " type:" + type + " tier: " + tier + " Size: " + size + " posX:" + posX + " posY: " + posY + " charges: " + charges;
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
        public int Id
        {
            get { return id; }
        }

        public byte Type
        {
            get { return type; }
            set { type = value; }
        }

        public byte Tier
        {
            get { return tier; }
            set { tier = value; }
        }

        public byte Charges
        {
            get { return charges; }
            set { charges = value; }
        }
        public byte Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
