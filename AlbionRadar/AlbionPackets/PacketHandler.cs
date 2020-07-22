using Newtonsoft.Json;
using PhotonPackageParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class PacketHandler : PhotonParser
    {
        PlayerHandler playerHandler;

        public PacketHandler(PlayerHandler playerHandler)
        {
            this.playerHandler = playerHandler;
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
                case EventCodes.evLeave:
                    onLeaveEvent(parameters);
                    break;
                default:
                    break;
            }

            debugEventInfo(parameters, evCode, "OnEvent");

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
            debugOperationInfo(parameters, opCode, "OnRequest");

        }
        protected override void OnResponse(byte operationCode, short returnCode, string debugMessage, Dictionary<byte, object> parameters)
        {
            parameters.TryGetValue((byte)253, out object val);
            if (val == null) return;

            if (!int.TryParse(val.ToString(), out int iCode)) return;

            OperationCodes opCode = (OperationCodes)iCode;
            debugOperationInfo(parameters, opCode, "OnResponse");

        }
        private void debugEventInfo(Dictionary<byte, object> parameters, EventCodes evCode, String typeInfo)
        {
            string jsonPacket;
            jsonPacket = JsonConvert.SerializeObject(parameters.ToArray());

            //Debug.WriteLine("[{0}]{1}: {2}", typeInfo, evCode, jsonPacket);
        }
        private void debugOperationInfo(Dictionary<byte, object> parameters, OperationCodes opCode, String typeInfo)
        {
            string jsonPacket;
            jsonPacket = JsonConvert.SerializeObject(parameters.ToArray());

            //Debug.WriteLine("[{0}]{1}: {2}", typeInfo, opCode, jsonPacket);
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

            playerHandler.AddPlayer(pos[0], pos[1], nick, guild, alliance, id);
        }
        private void onLeaveEvent(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());

            if (playerHandler.RemovePlayer(id))
                playerHandler.RemovePlayer(id);
        }
        private void onEntityMovementEvent(Dictionary<byte, object> parameters)
        {
            int id = int.Parse(parameters[0].ToString());
            Byte[] a = (Byte[])parameters[1];
            Single posX = BitConverter.ToSingle(a, 9);
            Single posY = BitConverter.ToSingle(a, 13);

            bool isPlayer = playerHandler.UpdatePlayerPosition(id, posX, posY);
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

            foreach (KeyValuePair<byte, object> param in parameters)
            {
                if (param.Key == 8)
                {
                    mounted = true;
                }

            }

            playerHandler.UpdatePlayerMount(id, mounted);
        }
        #endregion
    }
}
