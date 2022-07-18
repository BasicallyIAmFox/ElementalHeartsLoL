using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.IO;
using static ElementalHeartsLoL.ElementalHeartsLoL;

namespace ElementalHeartsLoL
{
	public class ElementalHeartsLoL : Mod
	{
		internal const byte BossCategory = 1;
		internal const byte HardmodeCategory = 2;
		internal const byte OtherCategory = 3;
		internal const byte PreHardmodeCategory = 4;

		internal static Dictionary<string, Heart> NameByHeart = new();

		public override void Load()
		{
			Dictionary<string, Heart> _dummy;
			_dummy = new()
			{
				#region Bosses
				{ "KingSlimeHeart", new("KingSlimeHeart") { category = BossCategory, boss = true, dropNPC = NPCID.KingSlime } },
				{ "EyeOfCthulhuHeart", new("EyeOfCthulhuHeart") { category = BossCategory, boss = true, dropNPC = NPCID.EyeofCthulhu, overrideName = "Eye of Cthulhu Heart" } },
				{ "EaterOfWorldsHeart", new("EaterOfWorldsHeart") { category = BossCategory, boss = true, dropNPC = NPCID.EaterofWorldsHead, overrideName = "Eater of Worlds Heart" } },
				{ "BrainOfCthulhuHeart", new("BrainOfCthulhuHeart") { category = BossCategory, boss = true, dropNPC = NPCID.BrainofCthulhu, overrideName = "Brain of Cthulhu Heart" } },
				{ "QueenBeeHeart", new("QueenBeeHeart") { category = BossCategory, boss = true, dropNPC = NPCID.QueenBee } },
				{ "SkeletronHeart", new("SkeletronHeart") { category = BossCategory, boss = true, dropNPC = NPCID.SkeletronHead } },
				{ "DeerHeart", new("DeerHeart") { category = BossCategory, boss = true, dropNPC = NPCID.Deerclops } },
				{ "WallOfFleshHeart", new("WallOfFleshHeart") { category = BossCategory, boss = true, dropNPC = NPCID.BrainofCthulhu, overrideName = "Wall of Flesh Heart" } },

				{ "QueenSlimeHeart", new("QueenSlimeHeart") { category = BossCategory, boss = true, dropNPC = NPCID.QueenSlimeBoss } },
				{ "SoulOfSightHeart", new("SoulOfSightHeart") { category = BossCategory, boss = true, dropNPC = NPCID.Retinazer, overrideName = "Soul of Sight Heart" } },
				{ "SoulOfMightHeart", new("SoulOfMightHeart") { category = BossCategory, boss = true, dropNPC = NPCID.TheDestroyer, overrideName = "Soul of Might Heart" } },
				{ "SoulOfFrightHeart", new("SoulOfFrightHeart") { category = BossCategory, boss = true, dropNPC = NPCID.SkeletronPrime, overrideName = "Soul of Fright Heart" } },
				{ "PlanteraHeart", new("PlanteraHeart") { category = BossCategory, boss = true, dropNPC = NPCID.Plantera } },
				{ "GolemHeart", new("GolemHeart") { category = BossCategory, boss = true, dropNPC = NPCID.Golem } },
				{ "DukeFishronHeart", new("DukeFishronHeart") { category = BossCategory, boss = true, dropNPC = NPCID.DukeFishron } },
				{ "EmpressOfLightHeart", new("EmpressOfLightHeart") { category = BossCategory, boss = true, dropNPC = NPCID.HallowBoss, overrideName = "Empress of Light Heart" } },
				{ "LunaticCultistHeart", new("LunaticCultistHeart") { category = BossCategory, boss = true, dropNPC = NPCID.CultistBoss } },
				{ "MoonLordHeart", new("MoonLordHeart") { category = BossCategory, boss = true, dropNPC = NPCID.MoonLordCore } },
				#endregion

				#region Hardmode
				{ "AdamantiteHeart", new("AdamantiteHeart") { category = HardmodeCategory, station = TileID.AdamantiteForge, material = ItemID.AdamantiteOre } },
				{ "BubbleHeart", new("BubbleHeart") { category = HardmodeCategory, shopNPC = NPCID.PartyGirl, value = 10000 } },
				{ "ChlorophyteHeart", new("ChlorophyteHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.ChlorophyteOre } },
				{ "CobaltHeart", new("CobaltHeart") { category = HardmodeCategory, station = TileID.Furnaces, material = ItemID.CobaltOre } },
				{ "CogHeart", new("CogHeart") { category = HardmodeCategory, shopNPC = NPCID.Steampunker, value = 1000000 } },
				{ "CrystalHeart", new("CrystalHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.CrystalShard } },
				{ "CursedFlameHeart", new("CursedFlameHeart") { category = HardmodeCategory, station = TileID.CrystalBall, material = ItemID.CursedFlame } },
				{ "DiscordHeart", new("DiscordHeart") { category = HardmodeCategory, station = TileID.DemonAltar, material = ItemID.RodofDiscord } },
				{ "EctoplasmHeart", new("EctoplasmHeart") { category = HardmodeCategory, station = TileID.CrystalBall, material = ItemID.Ectoplasm } },
				{ "FleshHeart", new("FleshHeart") { category = HardmodeCategory, station = TileID.FleshCloningVat, material = ItemID.FleshBlock } },
				{ "FlightHeart", new("FlightHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.SoulofFlight } },
				{ "IchorHeart", new("IchorHeart") { category = HardmodeCategory, station = TileID.CrystalBall, material = ItemID.Ichor } },
				{ "LesionHeart", new("LesionHeart") { category = HardmodeCategory, station = TileID.LesionStation, material = ItemID.LesionBlock } },
				{ "LightHeart", new("LightHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.SoulofLight } },
				{ "LuminiteHeart", new("LuminiteHeart") { category = HardmodeCategory, station = TileID.LunarCraftingStation, material = ItemID.LunarOre } },
				{ "MythrilHeart", new("MythrilHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.MythrilOre } },
				{ "NightHeart", new("NightHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.SoulofNight } },
				{ "OrichalcumHeart", new("OrichalcumHeart") { category = HardmodeCategory, station = TileID.MythrilAnvil, material = ItemID.OrichalcumOre } },
				{ "PalladiumHeart", new("PalladiumHeart") { category = HardmodeCategory, station = TileID.Furnaces, material = ItemID.PalladiumOre } },
				{ "PearlsandHeart", new("PearlsandHeart") { category = HardmodeCategory, station = TileID.HeavyWorkBench, material = ItemID.PearlsandBlock } },
				{ "PearlstoneHeart", new("PearlstoneHeart") { category = HardmodeCategory, station = TileID.Furnaces, material = ItemID.PearlsandBlock } },
				{ "PearlwoodHeart", new("PearlwoodHeart") { category = HardmodeCategory, station = TileID.Trees, material = ItemID.Pearlwood } },
				{ "PinkIceHeart", new("PinkIceHeart") { category = HardmodeCategory, station = TileID.IceMachine, material = ItemID.PinkIceBlock } },
				{ "RainbowHeart", new("RainbowHeart") { category = HardmodeCategory, station = TileID.Anvils, material = ItemID.RainbowBrick, alpha = delegate (Color lightColor) { return Main.DiscoColor; } } },
				{ "SpookyWoodHeart", new("SpookyWoodHeart") { category = HardmodeCategory, station = TileID.Trees, material = ItemID.SpookyWood } },
				{ "TitaniumHeart", new("TitaniumHeart") { category = HardmodeCategory, station = TileID.AdamantiteForge, material = ItemID.TitaniumOre } },
#endregion

				#region Pre Hardmode
				{ "AmberHeart", new("AmberHeart") { category = PreHardmodeCategory, station = TileID.TreeAmber, material = ItemID.Amber } },
				{ "AmethystHeart", new("AmethystHeart") { category = PreHardmodeCategory, station = TileID.TreeAmethyst, material = ItemID.Amethyst } },
				{ "BorealWoodHeart", new("BorealWoodHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.BorealWood } },
				{ "CactusHeart", new("CactusHeart") { category = PreHardmodeCategory, station = TileID.Cactus, material = ItemID.Cactus } },
				{ "CandyCaneHeart", new("CandyCaneHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.CandyCaneBlock } },
				{ "CloudHeart", new("CloudHeart") { category = PreHardmodeCategory, station = TileID.SkyMill, material = ItemID.Cloud } },
				{ "CoralstoneHeart", new("CoralstoneHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.CoralstoneBlock } },
				{ "CrimsandHeart", new("CrimsandHeart") { category = PreHardmodeCategory, station = TileID.HeavyWorkBench, material = ItemID.CrimsandBlock } },
				{ "CrimstoneHeart", new("CrimstoneHeart") { category = PreHardmodeCategory, station = TileID.HeavyWorkBench, material = ItemID.CrimstoneBlock } },
				{ "CrimtaneHeart", new("CrimtaneHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.CrimtaneOre } },
				{ "DemoniteHeart", new("DemoniteHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.DemoniteOre } },
				{ "DiamondHeart", new("DiamondHeart") { category = PreHardmodeCategory, station = TileID.TreeDiamond, material = ItemID.Diamond } },
				{ "DirtHeart", new("DirtHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.DirtBlock } },
				{ "DynastyHeart", new("DynastyHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.DynastyWood } },
				{ "EbonsandHeart", new("EbonsandHeart") { category = PreHardmodeCategory, station = TileID.HeavyWorkBench, material = ItemID.EbonsandBlock } },
				{ "EbonstoneHeart", new("EbonstoneHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.EbonstoneBlock } },
				{ "EmeraldHeart", new("EmeraldHeart") { category = PreHardmodeCategory, station = TileID.TreeEmerald, material = ItemID.Emerald } },
				{ "EnchantedHeart", new("EnchantedHeart") { category = PreHardmodeCategory, station = TileID.DemonAltar, material = ItemID.EnchantedSword } },
				{ "FossilHeart", new("FossilHeart") { category = PreHardmodeCategory, station = TileID.Extractinator, material = ItemID.DesertFossil } },
				{ "GlassHeart", new("GlassHeart") { category = PreHardmodeCategory, station = TileID.GlassKiln, material = ItemID.Glass } },
				{ "GoldHeart", new("GoldHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.GoldOre } },
				{ "GraniteHeart", new("GraniteHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.GraniteBlock } },
				{ "HayHeart", new("HayHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.Hay } },
				{ "HellstoneHeart", new("HellstoneHeart") { category = PreHardmodeCategory, station = TileID.Hellforge, material = ItemID.Hellstone } },
				{ "HoneyHeart", new("HoneyHeart") { category = PreHardmodeCategory, station = TileID.HoneyDispenser, material = ItemID.HoneyBlock } },
				{ "IceHeart", new("IceHeart") { category = PreHardmodeCategory, station = TileID.IceMachine, material = ItemID.IceBlock } },
				{ "IronHeart", new("IronHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.IronOre } },
				{ "LeadHeart", new("LeadHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.LeadOre } },
				{ "LifeCrystalHeart", new("LifeCrystalHeart") { category = PreHardmodeCategory, station = TileID.DemonAltar, material = ItemID.LifeCrystal, extraTooltip = "Dedicated to AdamChromeE!" } },
				{ "MarbleHeart", new("MarbleHeart") { category = PreHardmodeCategory, station = TileID.WorkBenches, material = ItemID.MarbleBlock } },
				{ "MeteoriteHeart", new("MeteoriteHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.Meteorite } },
				{ "MushroomHeart", new("MushroomHeart") { category = PreHardmodeCategory, station = TileID.Sawmill, material = ItemID.GlowingMushroom } },
				{ "ObsidianHeart", new("ObsidianHeart") { category = PreHardmodeCategory, station = TileID.Hellforge, material = ItemID.Obsidian } },
				{ "PalmWoodHeart", new("PalmWoodHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.PalmWood } },
				{ "PlatinumHeart", new("PlatinumHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.PlatinumOre } },
				{ "PumpkinHeart", new("PumpkinHeart") { category = PreHardmodeCategory, station = TileID.Sawmill, material = ItemID.Pumpkin } },
				{ "PurpleIceHeart", new("PurpleIceHeart") { category = PreHardmodeCategory, station = TileID.IceMachine, material = ItemID.PurpleIceBlock } },
				{ "RainCloudHeart", new("RainCloudHeart") { category = PreHardmodeCategory, station = TileID.SkyMill, material = ItemID.RainCloud } },
				{ "RedIceHeart", new("RedIceHeart") { category = PreHardmodeCategory, station = TileID.IceMachine, material = ItemID.RedIceBlock } },
				{ "RichMahoganyHeart", new("RichMahoganyHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.RichMahogany } },
				{ "RubyHeart", new("RubyHeart") { category = PreHardmodeCategory, station = TileID.Extractinator, material = ItemID.Ruby } },
				{ "SandHeart", new("SandHeart") { category = PreHardmodeCategory, station = TileID.HeavyWorkBench, material = ItemID.SandBlock } },
				{ "SapphireHeart", new("SapphireHeart") { category = PreHardmodeCategory, station = TileID.Extractinator, material = ItemID.Sapphire } },
				{ "ShadewoodHeart", new("ShadewoodHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.Shadewood } },
				{ "SilverHeart", new("SilverHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.SilverOre } },
				{ "SlimeHeart", new("SlimeHeart") { category = PreHardmodeCategory, station = TileID.Solidifier, material = ItemID.Gel } },
				{ "SnowCloudHeart", new("SnowCloudHeart") { category = PreHardmodeCategory, station = TileID.SkyMill, material = ItemID.SnowCloudBlock } },
				{ "StoneHeart", new("StoneHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.StoneBlock } },
				{ "SunplateHeart", new("SunplateHeart") { category = PreHardmodeCategory, station = TileID.SkyMill, material = ItemID.SunplateBlock } },
				{ "TinHeart", new("TinHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.TinOre } },
				{ "TopazHeart", new("TopazHeart") { category = PreHardmodeCategory, station = TileID.Extractinator, material = ItemID.Topaz } },
				{ "TungstenHeart", new("TungstenHeart") { category = PreHardmodeCategory, station = TileID.Furnaces, material = ItemID.TungstenOre } },
				{ "WoodHeart", new("WoodHeart") { category = PreHardmodeCategory, station = TileID.Trees, material = ItemID.Wood } },
#endregion
			};

			foreach (KeyValuePair<string, Heart> sh in _dummy)
				NameByHeart.Add(sh.Key, sh.Value);

			foreach (string s in NameByHeart.Keys.ToList())
				AddContent(new HeartItem() { name = s, heart = NameByHeart[s] });
		}

		public override void Unload() => NameByHeart = null;
	}

	[Autoload(false)]
	public class HeartItem : ModItem
	{
		public Heart heart;
		public int? rarity;
		public int givenHP;
		public string tag;
		public string name;

		public override bool IsLoadingEnabled(Mod mod) => !heart.joke;

		protected override bool CloneNewInstances => true;
		public override string Name => name;

		public override string Texture
		{
			get
			{
				string a = "PreHardmode";
				if (heart.category == BossCategory)
					a = "Boss";
				else if (heart.category == HardmodeCategory)
					a = "Hardmode";
				else if (heart.category == OtherCategory)
					a = "Other";
				return $"{Mod.Name}/Assets/{a}/{Name}";
			}
		}

		private void Initialize()
		{
			if (heart.material != 0)
				rarity = new Item(heart.material).rare;
			else
				rarity = !heart.boss ? ItemRarityID.White : ItemRarityID.Expert;

			if (heart.boss)
				givenHP = (int)(Math.Round(EHConfig.Instance.EHLovePower * 2.0 / 5.0) * 5.0);
			else
				givenHP = ((rarity ?? heart.rarity) + 1) * EHConfig.Instance.EHLovePower;

			tag = heart.name;
		}

		public override void Load()
		{
			if (heart.dropNPC == -1 && heart.shopNPC == -1) // avoid loading empty
				return;

			Mod.AddContent(new EHNPC() { mod = Mod, boss = Name, sell = heart.shopNPC, drop = heart.dropNPC});
		}

		public override ModItem Clone(Item newEntity)
		{
			HeartItem item = (HeartItem)base.Clone(newEntity);
			item.heart = heart;
			item.rarity = rarity;
			item.givenHP = givenHP;
			item.tag = (string)tag?.Clone();
			item.name = (string)name?.Clone();
			return item;
		}

		public override void SetStaticDefaults()
		{
			Initialize();

			DisplayName.SetDefault(heart.overrideName == string.Empty ? Regex.Replace(Name, "[A-Z]", " $0").Trim() : heart.overrideName);
			Tooltip.SetDefault("Dummy tooltip");
			SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.rare = !heart.boss ? (rarity ?? heart.rarity) : ItemRarityID.Expert;
			Item.expert = heart.boss;
			Item.expertOnly = heart.boss;

			if (heart.material != ItemID.None)
				Item.value = (int)(new Item(heart.material).value * CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[heart.material] / 1.25f);
			else
				Item.value = heart.value;

			if (heart.boss && heart.dropNPC != -1)
				Item.value = (int)ContentSamples.NpcsByNetId[heart.dropNPC].value / 10;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.FindIndex(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
			if (index != -1)
			{
				string text = $"Permanently increases maximum life by {givenHP}";
				if (heart.extraTooltip != string.Empty)
					text += "\n" + heart.extraTooltip;

				string maxConsumiation;
				if (EHConfig.Instance.EHMaxHearts == 1)
				{
					if (Main.LocalPlayer.GetModPlayer<EHTracker>().used.ContainsKey(tag))
						maxConsumiation = $"[Max Consumed]";
					else
						maxConsumiation = "[0/1]";
				}
				else if (EHConfig.Instance.EHMaxHearts > 1)
				{
					if (Main.LocalPlayer.GetModPlayer<EHTracker>().used.ContainsKey(tag))
						maxConsumiation = $"[{Main.LocalPlayer.GetModPlayer<EHTracker>().used[tag]}/{EHConfig.Instance.EHMaxHearts}]";
					else
						maxConsumiation = $"[0/{EHConfig.Instance.EHMaxHearts}]";
				}
				else
				{
					maxConsumiation = "[Disabled]";
				}

				tooltips[index].Text = text;

				tooltips.Insert(index + 1, new(Mod, $"{Mod.Name}:Consumptiation", maxConsumiation) { OverrideColor = Color.Lerp(Color.White, Color.Teal, 0.2f) });

				if (heart.boss && !EHConfig.Instance.EHBossEnabled)
					tooltips.Insert(index + 2, new(Mod, $"{Mod.Name}:BossDisabled", "[Boss Hearts Disabled]") { OverrideColor = Color.Crimson });

				if (!heart.boss && !EHConfig.Instance.EHMaterialEnabled)
					tooltips.Insert(index + 2, new(Mod, $"{Mod.Name}:MaterialDisabled", "[Material Hearts Disabled]") { OverrideColor = Color.Crimson });
			}
		}

		public override bool? UseItem(Player player)
		{
			player.statLifeMax2 += givenHP;
			player.statLife += givenHP;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(givenHP, true);
			}

			if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag))
			{
				IDictionary<string, int> used = player.GetModPlayer<EHTracker>().used;
				string key = tag;
				used[key] += givenHP;
			}
			else
			{
				player.GetModPlayer<EHTracker>().used.Add(tag, givenHP);
			}

			return true;
		}

		public override Color? GetAlpha(Color lightColor) => heart.alpha?.Invoke(lightColor) ?? base.GetAlpha(lightColor);

		public override void AddRecipes()
		{
			if (!heart.boss && heart.dropNPC == -1 && heart.shopNPC == -1 && ModContent.GetInstance<EHConfig>().EHMaterialEnabled && heart.material != ItemID.None)
			{
				if (CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[heart.material] == 1)
				{
					CreateRecipe(1)
						.AddIngredient(heart.material, 1)
						.AddTile(heart.station)
						.Register();

					Recipe.Create(heart.material, 1)
						.AddIngredient(this, 1)
						.AddTile(TileID.Extractinator)
						.Register();
				}
				else
				{
					CreateRecipe(1)
						.AddIngredient(heart.material, CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[heart.material] * EHConfig.Instance.EHRecipeDifficulty)
						.AddTile(heart.station)
						.Register();

					Recipe.Create(heart.material, Math.Max(1, (int)(CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[heart.material] * ModContent.GetInstance<EHConfig>().EHRecipeDifficulty / 1.25)))
						.AddIngredient(this, 1)
						.AddTile(TileID.Extractinator)
						.Register();
				}
			}
		}
	}

	[Autoload(false)]
	internal class EHNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		protected override bool CloneNewInstances => true;
		public override GlobalNPC Clone(NPC from, NPC to)
		{
			EHNPC npc = (EHNPC)base.Clone(from, to);
			npc.boss = boss;
			npc.sell = sell;
			npc.drop = drop;
			return npc;
		}

		public override string Name => boss;

		public Mod mod;
		public string boss;
		public int sell;
		public int drop;

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (sell != -1 && type == sell)
				shop.item[nextSlot++].SetDefaults(Mod.Find<ModItem>(boss).Type);
		}

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (drop != -1)
			{
				IItemDropRule rule;
				if (drop == NPCID.Retinazer && npc.type >= NPCID.Retinazer && npc.type <= NPCID.Spazmatism)
				{
					rule = new LeadingConditionRule(new Conditions.MissingTwin());
					rule.OnSuccess(ItemDropRule.BossBag(Mod.Find<ModItem>(boss).Type));
					npcLoot.Add(rule);
					return;
				}

				if (drop == NPCID.EaterofWorldsHead && npc.type >= NPCID.EaterofWorldsHead && npc.type <= NPCID.EaterofWorldsTail)
				{
					goto bossLabel;
				}

			bossLabel:
				rule = new LeadingConditionRule(new Conditions.LegacyHack_IsABoss());
				rule.OnSuccess(ItemDropRule.BossBag(Mod.Find<ModItem>(boss).Type));
				npcLoot.Add(rule);
			}
		}
	}

	public struct Heart
	{
		public delegate Color? GetAlpha(Color lightColor);

		public readonly string name;
		public bool joke = false;
		public int rarity = -2;
		public short material = ItemID.None;
		public int station = -1;
		public bool boss = false;
		public GetAlpha alpha = null;
		public byte category = PreHardmodeCategory;
		public int value = 100;
		public string overrideName = string.Empty;
		public string extraTooltip = string.Empty;

		public int shopNPC = -1;
		public int dropNPC = -1;

		public Heart(string name) => this.name = name;
	}

	internal class EHTracker : ModPlayer
	{
		public IDictionary<string, int> used = new Dictionary<string, int>();

		public override void ResetEffects()
		{
			if (used != null)
			{
				foreach (KeyValuePair<string, int> usedEH in used)
				{
					Player.statLifeMax2 += usedEH.Value;
				}
			}
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = Mod.GetPacket(256);
			packet.Write(Player.statLifeMax2);
			packet.Send(toWho, fromWho);
		}

		public override void SaveData(TagCompound tag)
		{
			tag["usedKeys"] = used.Keys.ToList();
			tag["usedValues"] = used.Values.ToList();
		}

		public override void LoadData(TagCompound tag)
		{
			var keys = tag.Get<List<string>>("usedKeys");
			var values = tag.Get<List<int>>("usedValues");
			used = keys.Zip(values, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
		}
	}

	internal class EHConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static EHConfig Instance;

		public override bool Autoload(ref string name)
		{
			Instance = this;
			return true;
		}
		
#pragma warning disable CS0649
		[Header("Basic Settings")]
		[BackgroundColor(255, 87, 51, 255)]
		[DefaultValue(false)]
		[Label("Legacy Elemental Hearts (Default: False)")]
		[Tooltip("Enables all Legacy hearts if enabled.")]
		public bool Legacy;

		[BackgroundColor(255, 64, 159, 255)]
		[DefaultValue(false)]
		[Label("Show Bonus HP Info (Default: False)")]
		[Tooltip("Similar to the compass, but it shows your Elemental Hearts buff stats.")]
		public bool EHInfoEnabled;

		[BackgroundColor(128, 141, 158, 255)]
		[DefaultValue(false)]
		[Label("Enable Consumption Wave (Default: False)")]
		[Tooltip("Toggle the beautiful effect. (In case you need to consume a lot in a short time?)")]
		public bool EHWaveEnabled;

		[Header("Advanced Settings (Recomended: Do Not Touch.)")]
		[BackgroundColor(255, 0, 102, 150)]
		[DefaultValue(1)]
		[Range(0, 100)]
		[ReloadRequired]
		[Label("Max Heart Consumption (Default: 1)")]
		[Tooltip("Changes the amount of times you can consume each heart.")]
		public int EHMaxHearts;

		[BackgroundColor(255, 130, 243, 150)]
		[DefaultValue(2)]
		[Range(1, 100)]
		[ReloadRequired]
		[Label("Love Power (Default: 2)")]
		[Tooltip("Changes the amount of bonus HP you recieve upon consumption.")]
		public int EHLovePower;

		[BackgroundColor(135, 255, 235, 150)]
		[DefaultValue(1)]
		[Range(1, 100)]
		[ReloadRequired]
		[Label("Recipe Difficulty (Default: 1)")]
		[Tooltip("Changes the amount of recources you need to craft each heart.")]
		public int EHRecipeDifficulty;

		[DefaultValue(true)]
		[ReloadRequired]
		[Label("Enable Boss Hearts (Default: True)")]
		[Tooltip("Allow boss hearts to be crafted/used.")]
		public bool EHBossEnabled;

		[DefaultValue(true)]
		[ReloadRequired]
		[Label("Enable Material Hearts (Default: True)")]
		[Tooltip("Allow material hearts to be crafted/used.")]
		public bool EHMaterialEnabled;

		[Category("Advanced")]
		[DefaultValue(true)]
		[ReloadRequired]
		[Label("Enable Other Hearts (Default: True)")]
		[Tooltip("Allow other hearts to be crafted/used.")]
		public bool EHOtherEnabled;

		/*[Category("Advanced")]
		[BackgroundColor(128, 117, 121, 150)]
		[DefaultValue(false)]
		[Label("Enable Legacy Backup Logs (Recomended: False)")]
		[Tooltip("Should only enable if you know what you are doing.")]
		public bool RoamingLogsEnabled;*/

#pragma warning restore CS0649
	}
}