using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    /*
     * {"Key":0,"Value":784173} = id
     * {"Key":1,"Value":[-53.0,-318.0]} = pos
     * {"Key":3,"Value":"SHARED_RANDOM_EXIT_10x10_PORTAL_SOLO"} = type
     * {"Key":4,"Value":true} = idk (is finished maybe)
     * {"Key":6,"Value":true} = already entered
     * {"Key":252,"Value":300}
     */
    class Dungeon
    {
        private int id;
        private Single posX;
        private Single posY;
        private string type;

        public Dungeon(int id, Single posX, Single posY, String type)
        {
            this.id = id;
            this.posX = posX;
            this.posY = posY;
            this.type = type;

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

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string getType()
        {
            if (type.Contains("_CORRUPT"))
                return "CORRUPT";
            else if (type.Contains("_SOLO")) 
                return "SOLO";
            else if (type.Contains("_ELITE"))
                return "ELITE";
            else
                return "GROUP";
        }

    }
}
