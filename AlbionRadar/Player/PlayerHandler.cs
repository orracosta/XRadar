using AlbionRada.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    public class PlayerHandler
    {
        private List<Player> playersInRange;
        private List<int> mountsInRange;
        private Player localPlayer;

        public PlayerHandler()
        {
            playersInRange = new List<Player>();
            mountsInRange = new List<int>();
            localPlayer = new Player();
        }
        public void AddPlayer(Single posX, Single posY, string nickname, string guild, string alliance, int id)
        {
            Player p = new Player(posX, posY, nickname, guild, alliance, id);

            if (!playersInRange.Contains(p))
                playersInRange.Add(p);
        }
        public void AddMount(int id)
        {

            if (!mountsInRange.Contains(id))
            {
                mountsInRange.Add(id);
            }

        }
        public bool RemovePlayer(int id)
        {
            return playersInRange.RemoveAll(x => x.Id == id) > 0;
        }
        public bool RemoveMount(int id)
        {
            return mountsInRange.RemoveAll(x => x == id) > 0;
        }
        internal List<Player> PlayersInRange
        {
            get { return playersInRange; }
        }
        internal Player LocalPlayer
        {
            get { return LocalPlayer; }
        }
        internal List<int> MountsInRange
        {
            get { return MountsInRange; }
        }
        public void UpdateLocalPlayerPosition(Single posX, Single posY)
        {
            localPlayer.PosX = posX;
            localPlayer.PosY = posY;
        }
        public void UpdatePlayerMount(int id, bool mount)
        {
            if (mount)
                AddMount(id);
            else
                RemoveMount(id);
        }
        internal bool UpdatePlayerPosition(int id, float posX, float posY)
        {
            var player = playersInRange.FirstOrDefault(x => x.Id == id);
            if (player != null)
            {
                player.PosX = posX;
                player.PosY = posY;

                return true;

            }

            return false;
        }
        public Single localPlayerPosX()
        {
            return localPlayer.PosX;
        }
        public Single localPlayerPosY()
        {
            return localPlayer.PosY;
        }
        public bool playerIsMounted(int id)
        {
            return mountsInRange.Contains(id);
        }
    }
}
