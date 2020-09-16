using Newtonsoft.Json;
using PhotonPackageParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionNetwork2D
{
    class PacketHandler : PhotonParser
    {
        PlayerHandler playerHandler;
        MobsHandler mobsHandler;
        HarvestableHandler harvestableHandler;
        DungeonHandler dungeonHandler;

        public PacketHandler(PlayerHandler playerHandler, MobsHandler mobsHandler, HarvestableHandler harvestableHandler, DungeonHandler dungeonHandler)
        {
            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.harvestableHandler = harvestableHandler;
            this.dungeonHandler = dungeonHandler;
        }

        protected override void OnEvent(byte code, Dictionary<byte, object> parameters)
        {
            _ = Task.Run(() =>
            {
                if (code == 2)
                {
                    onEntityMovementEvent(parameters);
                    return;
                }

                parameters.TryGetValue((byte)252, out object val);
                if (val == null) return;

                if (!int.TryParse(val.ToString(), out int iCode)) return;

                EventCodes evCode = (EventCodes)iCode;

                switch (evCode)
                {
                    case EventCodes.NewCharacter:
                        onNewCharacter(parameters);
                        break;
                    case EventCodes.Mounted:
                        onMounted(parameters);
                        break;
                    case EventCodes.NewMob:
                        onNewMob(parameters);
                        break;
                    case EventCodes.Leave:
                        onLeave(parameters);
                        break;
                    case EventCodes.NewSimpleHarvestableObjectList:
                        onNewSimpleHarvestableObjectList(parameters);
                        break;
                    case EventCodes.NewHarvestableObject:
                        onNewHarvestableObject(parameters);
                        break;
                    case EventCodes.NewSimpleHarvestableObject:
                        onNewSimpleHarvestableObject(parameters);
                        break;
                    case EventCodes.MobChangeState:
                        onMobChangeState(parameters);
                        break;
                    case EventCodes.HarvestableChangeState:
                        onHarvestableChangeState(parameters);
                        break;
                    case EventCodes.NewRandomDungeonExit:
                        onNewRandomDungeonExit(parameters);
                        break;
                    case EventCodes.CharacterEquipmentChanged:
                        onCharacterEquipmentChanged(parameters);
                        break;
                    case EventCodes.OtherGrabbedLoot:
                        onOtherGrabbedLoot(parameters);
                        break;
                    case EventCodes.GuildUpdate:
                    case EventCodes.GuildPlayerUpdated:
                        break;
                    default:
                        debugEventInfo(parameters, evCode, "OnEvent");
                        break;
                }
            });
        }
        protected override void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
        {
            _ = Task.Run(() =>
            {
                parameters.TryGetValue((byte)253, out object val);
                if (val == null) return;

                if (!int.TryParse(val.ToString(), out int iCode)) return;

                OperationCodes opCode = (OperationCodes)iCode;

                switch (opCode)
                {
                    case OperationCodes.Move:
                        onLocalPlayerMovementRequest(parameters);
                        break;
                    case OperationCodes.ChangeCluster:
                        onChangeCluster(parameters);
                        break;
                    default:
                        debugOperationInfo(parameters, opCode, "OnRequest");
                        break;
                }
            });
        }
        protected override void OnResponse(byte operationCode, short returnCode, string debugMessage, Dictionary<byte, object> parameters)
        {
            _ = Task.Run(() =>
            {
                parameters.TryGetValue((byte)253, out object val);
                if (val == null) return;

                if (!int.TryParse(val.ToString(), out int iCode)) return;

                OperationCodes opCode = (OperationCodes)iCode;

                switch (opCode)
                {
                    case OperationCodes.Join:
                        opJoin(parameters);
                        break;
                    default:
                        debugOperationInfo(parameters, opCode, "OnResponse");
                        break;
                }
            });
        }
        private void debugEventInfo(Dictionary<byte, object> parameters, EventCodes evCode, String typeInfo)
        {
            string jsonPacket;
            jsonPacket = JsonConvert.SerializeObject(parameters.ToArray());

            Debug.WriteLine("[{0}]{1}: {2}", typeInfo, evCode, jsonPacket);
        }
        private void debugOperationInfo(Dictionary<byte, object> parameters, OperationCodes opCode, String typeInfo)
        {
            string jsonPacket;
            jsonPacket = JsonConvert.SerializeObject(parameters.ToArray());

            Debug.WriteLine("[{0}]{1}: {2}", typeInfo, opCode, jsonPacket);
        }

        #region OnEvents
        private void onNewRandomDungeonExit(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            Single[] loc = (Single[])parameters[1];
            Single posX = (Single)loc[0];
            Single posY = (Single)loc[1];
            String type = (string)parameters[3].ToString();

            dungeonHandler.AddDungeon(id, posX, posY, type);
        }
        private void onNewCharacter(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            string nick = parameters[1].ToString();
            object oGuild = "";
            object oAlliance = "";
            parameters.TryGetValue((byte)8, out oGuild);
            parameters.TryGetValue((byte)43, out oAlliance);
            string guild = oGuild == null ? "" : oGuild.ToString();
            string alliance = oGuild == null ? "" : oAlliance.ToString();
            Single[] pos = (Single[])parameters[13];
            short[] items = new short[10];
            short[] skills = new short[6];
            int faction = int.Parse(parameters[45].ToString());

            if (parameters[33].GetType() == typeof(Byte[]))
            {
                int index = 0;
                Byte[] itemList = (Byte[])parameters[33];
                foreach (Byte b in itemList)
                {
                    if (index >= 10)
                        break;

                    items[index] = Convert.ToInt16(b);
                    index++;
                }
            }
            else
            {
                int index = 0;
                Int16[] itemList = (Int16[])parameters[33];
                foreach (Int16 b in itemList)
                {
                    if (index >= 10)
                        break;

                    items[index] = b;
                    index++;
                }
            }

            if (parameters[35].GetType() == typeof(Byte[]))
            {
                int index = 0;
                Byte[] skillList = (Byte[])parameters[35];
                foreach (Byte b in skillList)
                {
                    if (index >= 6)
                        break;

                    skills[index] = Convert.ToInt16(b);
                    index++;
                }
            }
            else
            {
                int index = 0;
                Int16[] skillList = (Int16[])parameters[35];
                foreach (Int16 b in skillList)
                {
                    if (index >= 6)
                        break;

                    skills[index] = b;
                    index++;
                }
            }

            playerHandler.AddPlayer(pos[0], pos[1], nick, guild, alliance, id, items, skills, faction);

        }
        private void onCharacterEquipmentChanged(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            short[] items = new short[10];
            short[] skills = new short[6];

            if (parameters[2].GetType() == typeof(Byte[]))
            {
                int index = 0;
                Byte[] itemList = (Byte[])parameters[2];
                foreach (Byte b in itemList)
                {
                    if (index >= 10)
                        break;

                    items[index] = Convert.ToInt16(b);
                    index++;
                }
            }
            else
            {
                int index = 0;
                Int16[] itemList = (Int16[])parameters[2];
                foreach (Int16 b in itemList)
                {
                    if (index >= 10)
                        break;

                    items[index] = b;
                    index++;
                }
            }

            if (parameters[5].GetType() == typeof(Byte[]))
            {
                int index = 0;
                Byte[] skillList = (Byte[])parameters[5];
                foreach (Byte b in skillList)
                {
                    if (index >= 6)
                        break;

                    skills[index] = Convert.ToInt16(b);
                    index++;
                }
            }
            else
            {
                int index = 0;
                Int16[] skillList = (Int16[])parameters[5];
                foreach (Int16 b in skillList)
                {
                    if (index >= 6)
                        break;

                    skills[index] = b;
                    index++;
                }
            }

            //Debug.WriteLine("w1:{0},w2:{1},w3:{2},c:{3},h:{4},b:{5}", skills[0], skills[1], skills[2], skills[3], skills[4], skills[5]);
            playerHandler.UpdatePlayerEquipment(id, items, skills);
        }
        private void onNewMob(Dictionary<byte, object> parameters)
        {
            if (!parameters.ContainsKey(13))
                return;

            int id = int.Parse(parameters[0].ToString());
            int typeId = int.Parse(parameters[1].ToString());
            Single[] loc = (Single[])parameters[8];
            DateTime timeA = new DateTime(long.Parse(parameters[9].ToString()));
            DateTime timeB = new DateTime(long.Parse(parameters[16].ToString()));
            DateTime timeC = new DateTime(long.Parse(parameters[20].ToString()));
            Single posX = (Single)loc[0];
            Single posY = (Single)loc[1];
            int health = int.Parse(parameters[13].ToString());
            int rarity = int.Parse(parameters[20].ToString());

            mobsHandler.AddMob(id, typeId, posX, posY, health);
        }
        private void onLeave(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());

            playerHandler.RemovePlayer(id);
            playerHandler.RemoveMount(id);
            mobsHandler.RemoveMob(id);
            dungeonHandler.RemoveDungeon(id);
        }
        private void onEntityMovementEvent(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            Byte[] a = (Byte[])parameters[1];
            Single posX = BitConverter.ToSingle(a, 9);
            Single posY = BitConverter.ToSingle(a, 13);

            bool isPlayer = playerHandler.UpdatePlayerPosition(id, posX, posY);

            if (!isPlayer)
                mobsHandler.UpdateMobPosition(id, posX, posY);
        }
        private void onNewSimpleHarvestableObjectList(Dictionary<byte, object> parameters)
        {
            List<int> idList = new List<int>();
            if (parameters[0].GetType() == typeof(Byte[]))
            {
                Byte[] typeListByte = (Byte[])parameters[0]; //list of types
                foreach (Byte b in typeListByte)
                    idList.Add(b);
            }
            else if (parameters[0].GetType() == typeof(Int16[]))
            {
                Int16[] typeListByte = (Int16[])parameters[0]; //list of types
                foreach (Int16 b in typeListByte)
                    idList.Add(b);
            }
            else
            {
                Console.WriteLine("onNewSimpleHarvestableObjectList type error: " + parameters[0].GetType());
                return;
            }
            try
            {
                Byte[] typesList = (Byte[])parameters[1]; //list of types
                Byte[] tiersList = (Byte[])parameters[2]; //list of tiers
                Single[] posList = (Single[])parameters[3]; //list of positions X1, Y1, X2, Y2 ...
                Byte[] sizeList = (Byte[])parameters[4]; //size

                for (int i = 0; i < idList.Count; i++)
                {
                    int id = int.Parse(idList.ElementAt(i).ToString());
                    byte type = byte.Parse(typesList[i].ToString());
                    byte tier = byte.Parse(tiersList[i].ToString());
                    Single posX = (Single)posList[i * 2];
                    Single posY = (Single)posList[i * 2 + 1];
                    Byte count = byte.Parse(sizeList[i].ToString());
                    byte charges = (byte)0;

                    harvestableHandler.AddHarvestable(id, type, tier, posX, posY, charges, count);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("eL: " + e.ToString());
            }
        }
        private void onNewHarvestableObject(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            byte type = byte.Parse(parameters[5].ToString()); //TODO - check if 5 is type
            byte tier = byte.Parse(parameters[7].ToString()); //Tier
            Single[] loc = (Single[])parameters[8];
            Single posX = (Single)loc[0];
            Single posY = (Single)loc[1];
            byte charges = (byte)0;
            byte size = (byte)0;

            if (parameters.ContainsKey(10))
                size = byte.Parse(parameters[10].ToString());

            if (parameters.ContainsKey(11))
                charges = byte.Parse(parameters[11].ToString());

            harvestableHandler.AddHarvestable(id, type, tier, posX, posY, charges, size);
        }
        private void onNewSimpleHarvestableObject(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
        }
        private void onHarvestableChangeState(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            byte charges = 0;
            byte amount = 0;

            if (parameters.ContainsKey(1))
                amount = byte.Parse(parameters[1].ToString());

            if (parameters.ContainsKey(2))
                charges = byte.Parse(parameters[2].ToString());

            harvestableHandler.UpdateHarvestable(id, amount, charges);
        }
        private void onMobChangeState(Dictionary<byte, object> parameters)
        {
            int mobId = int.Parse(parameters[0].ToString());
            byte enchantmentLevel = 0;

            if (parameters.ContainsKey(1))
                enchantmentLevel = byte.Parse(parameters[1].ToString());

            mobsHandler.UpdateMobEnchantmentLevel(mobId, enchantmentLevel);

        }
        private void onOtherGrabbedLoot(Dictionary<byte, object> parameters)
        {
            if (!PlayerLoot.canAdd)
                return;

            if (!parameters.ContainsKey(4) || !parameters.ContainsKey(5))
                return;

            string userName = parameters[2].ToString();
            short itemID = short.Parse(parameters[4].ToString());
            int amount = int.Parse(parameters[5].ToString());

            string itemName = PlayerItem.getLocalizedNameItem(itemID);

            if (itemName == "NONE")
                return;

            PlayerLoot.addLog(userName, itemName, amount);
        }
        #endregion

        #region OnRequests
        private void onLocalPlayerMovementRequest(Dictionary<byte, object> parameters)
        {
            // 373,6958 -358,3227 top of map
            //-375,2436 366,6795 bottom of map
            Single[] location = (Single[])parameters[1]; //if we switch to [3] we will have future position of player instead of 'right now'
            Single posX = Single.Parse(location[0].ToString());
            Single posY = Single.Parse(location[1].ToString());

            playerHandler.UpdateLocalPlayerPosition(posX, posY);
        }
        private void onChangeCluster(Dictionary<byte, object> parameters)
        {
            this.harvestableHandler.HarvestableList.Clear();
            this.mobsHandler.MobList.Clear();
            this.dungeonHandler.DungeonList.Clear();
            this.playerHandler.PlayersInRange.Clear();
            this.playerHandler.MountsInRange.Clear();
        }
        private void onMounted(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            bool mounted = false;

            if (parameters.ContainsKey(8))
                mounted = true;

            playerHandler.UpdatePlayerMount(id, mounted);
        }
        #endregion

        #region OnResponse
        private void opJoin(Dictionary<byte, object> parameters)
        {
            string nick = parameters[2].ToString();
            object oGuild = "";
            object oAlliance = "";
            parameters.TryGetValue((byte)51, out oGuild);
            parameters.TryGetValue((byte)69, out oAlliance);
            string guild = oGuild == null ? "" : oGuild.ToString();
            string alliance = oGuild == null ? "" : oAlliance.ToString();
            Single[] pos = (Single[])parameters[9];
            int faction = int.Parse(parameters[42].ToString());

            playerHandler.updateLocalPlayer(pos[0], pos[1], nick, guild, alliance, faction);
        }
        #endregion
    }
}
