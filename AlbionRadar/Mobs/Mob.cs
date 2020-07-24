using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class Mob
    {
        int id;
        int typeId;
        Single posX;
        Single posY;
        int health;
        byte enchantmentLevel;

        public Mob(int id, int typeId, Single posX, Single posY, int health, byte enchantmentLevel)
        {
            this.id = id;
            this.typeId = typeId;
            this.posX = posX;
            this.posY = posY;
            this.health = health;
            this.enchantmentLevel = enchantmentLevel;
        }
        public override string ToString()
        {
            return "id:" + id + " typeId: " + typeId + " posX: " + posX + " posY: " + posY + " health: " + health + " charges: " + enchantmentLevel;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Single PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        public Single PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public byte EnchantmentLevel
        {
            get { return enchantmentLevel; }
            set { enchantmentLevel = value; }
        }
    }
}
