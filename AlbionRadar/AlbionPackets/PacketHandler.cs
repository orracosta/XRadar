using Newtonsoft.Json;
using PhotonPackageParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbionRadar
{
    class PacketHandler : PhotonParser
    {
        PlayerHandler playerHandler;
        MobsHandler mobsHandler;
        HarvestableHandler harvestableHandler;

        public PacketHandler(PlayerHandler playerHandler, MobsHandler mobsHandler, HarvestableHandler harvestableHandler)
        {
            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.harvestableHandler = harvestableHandler;
        }

        protected override void OnEvent(byte code, Dictionary<byte, object> parameters)
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
                case EventCodes.evNewCharacter:
                    onNewCharacterEvent(parameters);
                    break;
                case EventCodes.evMounted:
                    onMounted(parameters);
                    break;
                case EventCodes.evNewMob:
                    onNewMob(parameters);
                    break;
                case EventCodes.evLeave:
                    onLeaveEvent(parameters);
                    break;
                case EventCodes.evNewSimpleHarvestableObjectList:
                    onNewSimpleHarvestableObjectList(parameters);
                    break;
                case EventCodes.evNewHarvestableObject:
                    onNewHarvestableObject(parameters);
                    break;
                case EventCodes.evMobChangeState:
                    onMobChangeState(parameters);
                    break;
                case EventCodes.evJoinFinished:
                    onJoinFinished(parameters);
                    break;
                case EventCodes.evHarvestableChangeState:
                    onHarvestableChangeState(parameters);
                    break;
                case EventCodes.evRandomDungeonPositionInfo:
                case EventCodes.evNewRandomDungeonExit:
                    debugEventInfo(parameters, evCode, "OnEvent");
                    break;
                default:
                    break;
            }
            //debugEventInfo(parameters, evCode, "OnEvent");

        }
        protected override void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
        {
            parameters.TryGetValue((byte)253, out object val);
            if (val == null) return;

            if (!int.TryParse(val.ToString(), out int iCode)) return;

            OperationCodes opCode = (OperationCodes)iCode;

            switch (opCode)
            {
                case OperationCodes.opMove:
                    onLocalPlayerMovementRequest(parameters);
                    break;
                default:
                    break;
            }

            //debugOperationInfo(parameters, opCode, "OnRequest");

        }
        protected override void OnResponse(byte operationCode, short returnCode, string debugMessage, Dictionary<byte, object> parameters)
        {
            parameters.TryGetValue((byte)253, out object val);
            if (val == null) return;

            if (!int.TryParse(val.ToString(), out int iCode)) return;

            OperationCodes opCode = (OperationCodes)iCode;

            switch (opCode)
            {
                case OperationCodes.opJoin:
                    onJoin(parameters);
                    break;
                default:
                    break;
            }

            //debugOperationInfo(parameters, opCode, "OnResponse");

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
        private void onNewCharacterEvent(Dictionary<byte, object> parameters)
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

            Settings.needBeepSound(guild, alliance);
            playerHandler.AddPlayer(pos[0], pos[1], nick, guild, alliance, id);
        }
        private void onNewMob(Dictionary<byte, object> parameters)
        {
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
        private void onLeaveEvent(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());

            if (playerHandler.RemovePlayer(id))
                playerHandler.RemoveMount(id);
            else
                mobsHandler.RemoveMob(id);
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
            List<int> a0 = new List<int>();
            if (parameters[0].GetType() == typeof(Byte[]))
            {
                Byte[] typeListByte = (Byte[])parameters[0]; //list of types
                foreach (Byte b in typeListByte)
                    a0.Add(b);
            }
            else if (parameters[0].GetType() == typeof(Int16[]))
            {
                Int16[] typeListByte = (Int16[])parameters[0]; //list of types
                foreach (Int16 b in typeListByte)
                    a0.Add(b);
            }
            else
            {
                Console.WriteLine("onNewSimpleHarvestableObjectList type error: " + parameters[0].GetType());
                return;
            }
            try
            {
                Byte[] a1 = (Byte[])parameters[1]; //list of types
                Byte[] a2 = (Byte[])parameters[2]; //list of tiers
                Single[] a3 = (Single[])parameters[3]; //list of positions X1, Y1, X2, Y2 ...
                Byte[] a4 = (Byte[])parameters[4]; //size

                for (int i = 0; i < a0.Count; i++)
                {
                    int id = (int)a0.ElementAt(i);
                    byte type = (byte)a1[i];
                    byte tier = (byte)a2[i];
                    Single posX = (Single)a3[i * 2];
                    Single posY = (Single)a3[i * 2 + 1];
                    Byte count = (byte)a4[i];
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
            byte charges = byte.Parse(parameters[11].ToString());
            byte size = 0;

            harvestableHandler.AddHarvestable(id, type, tier, posX, posY, charges, size);
        }
        private void onHarvestableChangeState(Dictionary<byte, object> parameters)
        {
            int id;
            byte charges;
            byte amount = 0;

            if (!int.TryParse(parameters[0].ToString(), out id)) return;
            if (!byte.TryParse(parameters[2].ToString(), out charges)) return;

            if (parameters.ContainsKey(1))
                amount = byte.Parse(parameters[1].ToString());

            harvestableHandler.UpdateHarvestable(id, amount, charges);
        }
        private void onMobChangeState(Dictionary<byte, object> parameters)
        {
            int mobId = 0;
            byte enchantmentLevel = 0;

            if (!int.TryParse(parameters[0].ToString(), out mobId)) return;
            if (!byte.TryParse(parameters[1].ToString(), out enchantmentLevel)) return;

            mobsHandler.UpdateMobEnchantmentLevel(mobId, enchantmentLevel);

        }
        private void onJoinFinished(Dictionary<byte, object> parameters)
        {
            this.harvestableHandler.HarvestableList.Clear();
            this.mobsHandler.MobList.Clear();
        }
        #endregion

        #region OnResponses
        private void onJoin(Dictionary<byte, object> parameters)
        {
            if (!parameters.ContainsKey(9))
                return;

            Single[] location = (Single[])parameters[9];
            Single posX = Single.Parse(location[0].ToString());
            Single posY = Single.Parse(location[1].ToString());

            playerHandler.UpdateLocalPlayerPosition(posX, posY);
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
        private void onMounted(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            bool mounted = false;

            if (parameters.ContainsKey(8))
                mounted = true;

            playerHandler.UpdatePlayerMount(id, mounted);
        }
        #endregion
    }
}
