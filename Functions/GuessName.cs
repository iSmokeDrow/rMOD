using rMOD.Structures;
using DataCore;

namespace rMOD.Functions
{
    public class GuessName
    {
        public static string Result(string name, NameType type)
        {
            string inName = name.ToLower();
            string outName = string.Empty;

            if (inName.Contains("creatureenhance"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_creatureenhance";
                        break;
                    case NameType.Table:
                        outName = "CreatureEnhance";
                        break;
                }
            }
            else if (inName.Contains("creature"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_creature";
                        break;
                    case NameType.Table:
                        outName = "CreatureResource";
                        break;
                }
            }
            else if (inName.Contains("effect"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_effectresource";
                        break;
                    case NameType.Table:
                        outName = "EffectResource";
                        break;
                }
            }
            else if (inName.Contains("exp"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_exp";
                        break;
                    case NameType.Table:
                        outName = "LevelResource";
                        break;
                }
            }
            else if (inName.Contains("state"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_tenacity";
                        break;
                    case NameType.Table:
                        outName = "StateResource";
                        break;
                }
            }
            else if (inName.Contains("string"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_string";
                        break;
                    case NameType.Table:
                        outName = "StringResource";
                        break;
                }
            }
            else if (inName.Contains("itemeffect"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_itemeffectresource";
                        break;
                    case NameType.Table:
                        outName = "ItemEffectResource";
                        break;
                }
            }
            else if (inName.Contains("item"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_item";
                        break;
                    case NameType.Table:
                        outName = "ItemResource";
                        break;
                }
            }
            else if (inName.Contains("field"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_fieldpropresource";
                        break;
                    case NameType.Table:
                        outName = "FieldPropResource";
                        break;
                }
            }
            else if (inName.Contains("npc"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_npcresource";
                        break;
                    case NameType.Table:
                        outName = "NpcResource";
                        break;
                }
            }
            else if (inName.Contains("monster"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_monster";
                        break;
                    case NameType.Table:
                        outName = "MonsterResource";
                        break;
                }
            }
            else if (inName.Contains("questlink"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_questlink";
                        break;

                    case NameType.Table:
                        outName = "QuestLinkResource";
                        break;
                }
            }
            else if (inName.Contains("quest"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_quest";
                        break;
                    case NameType.Table:
                        outName = "QuestResource";
                        break;
                }
            }
            else if (inName.Contains("skilltree"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_skiltree";
                        break;
                    case NameType.Table:
                        outName = "SkillTreeResource";
                        break;
                }
            }
            else if (inName.Contains("skill"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_skill";
                        break;
                    case NameType.Table:
                        outName = "SkillResource";
                        break;
                }
            }
            else if (inName.Contains("world"))
            {
                switch (type)
                {
                    case NameType.File:
                        outName = "db_worldlocation";
                        break;
                    case NameType.Table:
                        outName = "WorldLocation";
                        break;
                }
            }

            return outName;
        }
    }
}
