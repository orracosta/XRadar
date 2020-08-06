using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbionRadar
{
    class PlayerSpell
    {
        /* SKILLS
         * 0 = weapon - 1
         * 1 = weapon - 2
         * 2 = weapon - 3
         * 3 = chest
         * 4 = head
         * 5 = boots
        */
        public static List<PlayerSpell> listSpells = new List<PlayerSpell>
        { 
            // ----------PLACAS
            // ELMO PLACAS
            new PlayerSpell(1958, "ENERGYBURST_CHANNEL"),
            new PlayerSpell(2000, "STONESKIN"),
            new PlayerSpell(2001, "BLOCK"),
            new PlayerSpell(2003, "DISRUPTIONIMMUNITY"),
            new PlayerSpell(2004, "SUMMONER_HEAL"),
            new PlayerSpell(2005, "ARTILLERY_COMMAND"),
            new PlayerSpell(2006, "SACRIFICE_HEAL"),
            new PlayerSpell(2008, "WEAPON_SILENCE"),
            new PlayerSpell(2010, "ELECTRICSHOCK"),
            new PlayerSpell(2012, "PURIFYING_SMOKE"),
            // ARMADURA DE PLACA
            new PlayerSpell(1871, "OUTOFCOMBATHEAL"),
            new PlayerSpell(1931, "TAUNT"),
            new PlayerSpell(1934, "ENRAGE"),
            new PlayerSpell(1938, "WINDWALL"),
            new PlayerSpell(1941, "ENFEEBLEAURA"),
            new PlayerSpell(1943, "MANADRAIN"),
            new PlayerSpell(1947, "ARMORCHAIN"),
            new PlayerSpell(1950, "REFLECTAREA"),
            new PlayerSpell(1953, "REFLECT_CHANNEL"),
            new PlayerSpell(1955, "FORCESHIELD"),
            // BOTA DE PLACA
            new PlayerSpell(2013, "RUN"),
            new PlayerSpell(2055, "SPRINTHOT"),
            new PlayerSpell(2056, "WANDERLUST"),
            new PlayerSpell(2058, "CHARGE_SHIELD"),
            new PlayerSpell(2060, "MAXHEALTHBUFF"),
            new PlayerSpell(2061, "ROYAL_MARCH"),
            new PlayerSpell(2066, "BATTLEFRENZY"),
            new PlayerSpell(2067, "BERSERK_SPRINT"),
            new PlayerSpell(2069, "SHOULDERTACKLE"),
            new PlayerSpell(2071, "CC_BLOCK"),
            // ----------PLACAS

            // ----------COURO
            // ELMO DE COURO
            new PlayerSpell(1981, "HOWL"),
            new PlayerSpell(1983, "SELF_CLEANSE"),
            new PlayerSpell(1984, "RETALIATE2"),
            new PlayerSpell(1985, "SUMMONER_CD_REDUCTION"),
            new PlayerSpell(1987, "GROWING_RAGE"),
            new PlayerSpell(1991, "SMELLOFBLOOD"),
            new PlayerSpell(1993, "SMOKEBOMB"),
            new PlayerSpell(1996, "ARMOR_CD_RESET"),
            new PlayerSpell(1997, "NASTY_WOUNDS"),
            // ARMADURA DE COURO
            new PlayerSpell(1900, "FLAMESHIELD"),
            new PlayerSpell(1901, "BLOODLUST"),
            new PlayerSpell(1904, "HASTE"),
            new PlayerSpell(1905, "AMBUSH"),
            new PlayerSpell(1911, "ROYAL_BANNER"),
            new PlayerSpell(1913, "STORMSHIELD"),
            new PlayerSpell(1918, "LIFESTEALAURA"),
            new PlayerSpell(1925, "BURNAURA"),
            new PlayerSpell(1927, "DYNAMIC_DEFENSE"),
            // BOTA DE COURO
            new PlayerSpell(2034, "SPRINT_CD_REDUCTION"),
            new PlayerSpell(2035, "STEALTH_REVEAL"),
            new PlayerSpell(2038, "OVERSPRINT"),
            new PlayerSpell(2039, "DODGE"),
            new PlayerSpell(2040, "JUMP"),
            new PlayerSpell(2042, "DMG_BLINK"),
            new PlayerSpell(2043, "DEATHMARK"),
            new PlayerSpell(2049, "INVISIBLE_WALK"),
            new PlayerSpell(2052, "BLINDSPOT"),
            // ----------COURO

            // ---------- PANO
            // ELMO DE PANO
            new PlayerSpell(1960, "PBAOE_KNOCKBACK"),
            new PlayerSpell(1962, "ENERGYSHIELD2"),
            new PlayerSpell(1963, "ICEBLOCK2"),
            new PlayerSpell(1965, "WEAPON_DOT"),
            new PlayerSpell(1967, "PERPETUALENERGY"),
            new PlayerSpell(1968, "ENERGYFIELD"),
            new PlayerSpell(1970, "PURGE_HELMET"),
            new PlayerSpell(1971, "INNER_CORRUPTION"),
            new PlayerSpell(1975, "AVALON_BEAM"),
            // ARMADURA DE PANO
            new PlayerSpell(1875, "FROSTSHIELD"),
            new PlayerSpell(1877, "SPEEDCASTER"),
            new PlayerSpell(1878, "LIFESAVIOR"),
            new PlayerSpell(1880, "PURGINGSHIELD2"),
            new PlayerSpell(1882, "MAGICCIRCLE"),
            new PlayerSpell(1885, "SPELLRUSH"),
            new PlayerSpell(1887, "FEAR_AURA"),
            new PlayerSpell(1889, "LEVITATE"),
            new PlayerSpell(1898, "CASTBUBBLE"),
            // BOTA DE COURO
            new PlayerSpell(2015, "SPRINTEOT"),
            new PlayerSpell(2016, "CHANNELED_RUN"),
            new PlayerSpell(2018, "BLINK"),
            new PlayerSpell(2019, "DELAYED_TELEPORT"),
            new PlayerSpell(2021, "GLASS_MOVESPEED"),
            new PlayerSpell(2022, "FROSTWALK"),
            new PlayerSpell(2026, "SWAP"),
            new PlayerSpell(2027, "DEMONWALK"),
            new PlayerSpell(2032, "HOVER_SPRINT"),
            // ----------PANO
        };

        int id;
        string uniqueName;

        PlayerSpell(int id, string uniqueName)
        {
            this.id = id;
            this.uniqueName = uniqueName;
        }
        public static PlayerSpell getSpell(int id)
        {
            return listSpells.FirstOrDefault(i => i.id == id);
        }
        public static string getSpellImage(int itemID)
        {
            PlayerSpell spell = listSpells.FirstOrDefault(i => i.id == itemID);

            if (spell != null)
                return "https://render.albiononline.com/v1/spell/" + spell.uniqueName + ".png?size=80";
            else
                return "";
        }
    }
}
