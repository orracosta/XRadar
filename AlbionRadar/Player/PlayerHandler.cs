using AlbionRada.Player;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    public class PlayerHandler
    {
        private ConcurrentDictionary<int, Player> playersInRange;
        private ConcurrentDictionary<int, int> mountsInRange;
        private Player localPlayer;

        public PlayerHandler()
        {
            playersInRange = new ConcurrentDictionary<int, Player>();
            mountsInRange = new ConcurrentDictionary<int, int>();
            localPlayer = new Player();
        }
        public void AddPlayer(Single posX, Single posY, String nickname, String guild, String alliance, int id, short weapon, short secundaryWeapon, short helm, short armor, short boot, short bag, short cape, short mount, short potion, short food)
        {
            if (!playersInRange.Any(x => x.Key == id))
            {
                Player p = new Player(posX, posY, nickname, guild, alliance, id, weapon, secundaryWeapon, helm, armor, boot, bag, cape, mount, potion, food);
                playersInRange.TryAdd(id, p);
            }
        }
        internal void UpdatePlayerEquipment(int id, short weapon, short secundaryWeapon, short helm, short armor, short boot, short bag, short cape, short mount, short potion, short food)
        {
            if (!playersInRange.Any(x => x.Key == id))
                return;

            playersInRange[id].Weapon = weapon;
            playersInRange[id].SecundaryWeapon = secundaryWeapon;
            playersInRange[id].Helm = helm;
            playersInRange[id].Armor = armor;
            playersInRange[id].Boot = boot;
            playersInRange[id].Bag = bag;
            playersInRange[id].Cape = cape;
            playersInRange[id].Mount = mount;
            playersInRange[id].Potion = potion;
            playersInRange[id].Food = food;
        }
        public void AddMount(int id)
        {
            if (!mountsInRange.Any(x => x.Key == id))
                mountsInRange.TryAdd(id, id);
        }
        public bool RemovePlayer(int id)
        {
            return playersInRange.TryRemove(id, out _);
        }
        public bool RemoveMount(int id)
        {
            return mountsInRange.TryRemove(id, out _);
        }
        internal ConcurrentDictionary<int, Player> PlayersInRange
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
            if (!playersInRange.Any(x => x.Key == id))
                return false;

            playersInRange[id].PosX = posX;
            playersInRange[id].PosY = posY;

            return true;
        }
        public Single localPlayerPosX()
        {
            return localPlayer.PosX;
        }
        public Single localPlayerPosY()
        {
            return localPlayer.PosY;
        }
        public Player getLocalPlayer()
        {
            return localPlayer;
        }
        public bool PlayerIsMounted(int id)
        {
            return mountsInRange.Any(x => x.Key == id);
        }
    }
}
