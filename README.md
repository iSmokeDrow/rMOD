rMOD v0.9.5 Beta 1

Features:
	- LUA based structure files
		- Ability to load structure files when chosen or manually
		- Ability to define structures folder
		- Ability to assign unique FileName/TableName via Manage Structures GUI
		- Execution of code during row processing (load and save) by defining ProcessRow function
	- Tabs
		- Unique ability to clear current tab of all but the current structure (columns)
		- Unique ability to reload current tab data (clear current tab + load data)
		- Unique ability to reload current tab structure + data (completely reset current tab + load structure + load data)
		- Ability to close current tab
	- Loading/Saving of .rdb files
		- Ability to define save directory
		- Ability to save directly to hashed name
		- Ability to automatically append (ascii) to file names
		- Ability to select encoding
	- Loading/Saving of sql tables
		- Choice to drop/truncate target tables
		- Ability to backup target table before save operation
		- Saving mismatching epic data to tables
			- Unique ability to generate parameterized insert queries based on multiple methods
	- Unique 'GuessName' functionality (attempts to guess FileName/TableName based on structure name)
	

Structures:
	Note: there is no need to define header information
	
	Field Defintion: A field is a collection of bytes that represent specific data
	
	Defining basic rdb fields:
		The 'fields' list is a lua table containing tables of information e.generate
			field = 
			{
				{ "fieldName", FIELDTYPE },
				{ "fieldName", FIELDTYPE }
			}
		
		fieldName is simply a string which will be used as an identifier when the rdb data is displayed in rMOD
		FIELDTYPE is an identifier that determines how many bytes will be read on the particular field while process the rdb only certain FIELDTYPE can be used
		you can find them below. 
		
		!!!It should be noted that the FIELDTYPE identifier must ALWAYS be ALL CAPS and any typos will result in program errors!!!
		
		FIELDTYPE list:
		 - BYTE <single byte>
			-- Variables: length, default, show
         - BIT_VECTOR <4 byte int converted into c# System.Collections.Specialized.BitVector32>
			-- Variables: show
         - BIT_FROM_VECTOR (this field is not read from the .rdb but from the field whose name is the same as the bit_field variable)<int always 0 or 1>
			-- Variables: bit_position, bits_field, show
         - INT16 <2 byte int>
			-- Variables: default, flag, show
         - SHORT <same as INT16>
		 	-- Variables: default, flag, show
         - UINT16 <2 byte unsigned int>
		 	-- Variables: default, flag, show
         - USHORT <same as UINT16>
		 	-- Variables: default, flag, show
         - INT32 <4 byte int>
		 	-- Variables: default, flag, show
         - INT <same as INT32>
		 	-- Variables: default, flag, show
         - UINT32 <4 byte unsigned int>
		 	-- Variables: default, flag, show
         - UINT <same as UINT32>
		 	-- Variables: default, flag, show
         - INT64 <8 byte int>
		 	-- Variables: default, flag, show
         - LONG <same as INT64>
		 	-- Variables: default, flag, show
         - SINGLE <4 byte floating point int>
		 	-- Variables: default, flag, show
         - FLOAT <same as SINGLE>
		 	-- Variables: default, flag, show
         - FLOAT32 <same as SINGLE>
		 	-- Variables: default, flag, show
         - DOUBLE <8 byte floating point int>
		 	-- Variables: default, flag, show
         - FLOAT64 <same as DOUBLE>
		 	-- Variables: default, flag, show
         - DECIMAL <4 byte int converted to c# Decimal>
			-- Variables: default, flag, show
         - DATETIME <4 byte int converted to c# DATETIME>
			-- Variables: flag, show
         - STRING <c# string of variable length, requires 'length' to be assigned>
			-- Variables: length, flag, show
         - STRING_LEN <4 byte int which will define the length of a field with FIELDTYPE:STRING_BY_LEN and matching fieldName>
			-- Variables: show
         - STRING_BY_LEN <string with length defined by a field with FIELDTYPE:STRING_LEN and matching fieldName>
			-- Variables: show
		 
	Defining complex rdb fields:
		While some rdb have easily definable fields some need extra information to process correctly, such a case is the rdb db_string
		
			db_string fields example:
				fields = 
				{
					{ "name", STRING_LEN },
					{ "value", STRING_LEN },
					{ "name", STRING_BY_LEN },
					{ "value", STRING_BY_LEN },
					{ "code", INT32 },
					{ "group_id", INT32 },
					{ "unknown", BYTE, length=16, default=0, show=0 }
				}
				
			As you can see above we make use of the STRING_LEN/STRING_BY_LEN FIELDTYPE's but we also need to process 'useless' data in order
			to read the rdb properly. So we define the 'unknown' field.
			
			Sometimes we need to process data that we don't want to show, in this cage we will use the 'show' variable and set it to 0
			
			In this particular case we need to read a specific amount of bytes to properly process the 'unknown' field, while this could be done as:
			
				fields = 
				{
					{ "unknown1", INT32 },
					{ "unknown2", INT32 },
					{ "unknown3", INT32 },
					{ "unknown4", INT32 },
				}
				
			it is accomplished much easier by using the FIELDTYPE:BYTE and defining the 'length' variable as 16 !!!NOTE: only FIELDTYPE:BYTE/STRING can
			utilize the length variable!!!
			
			In this particular case we also define the 'default' variable, this variable is used when saving an rdb. For instance, had we loaded this 
			rdb's information from an SQL table we have no proper way of knowing what to place in this area of useless data. Thusly, if we already know
			there is no information here we can provide a default value of 0. !!!NOTE: FIELDTYPE:STRING can also have a default string value!!!
		
		There are however even more complex field definitions required by some rdb, in the next instance we will look at using the FIELDTYPE:BIT_VECTOR
		and FIELDTYPE:BIT_FROM_VECTOR as they are used in db_item/db_monster
		
			In db_item there are limit_* fields such as limit_deva, limit_gaia, limit_asura which limit the ability of races or classes to use that specific 
			item. See the example below:
					
				fields = 
				{
					{"limit_bits", BIT_VECTOR, show=0 },
					{"limit_deva", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=2},
					{"limit_asura", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=3},
					{"limit_gaia", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=4},
					{"limit_fighter", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=10},
					{"limit_hunter", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=11},
					{"limit_magician", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=12},
					{"limit_summoner", BIT_FROM_VECTOR, bits_field="limit_bits", bit_position=13}
				}
					
			In this particular instance we will be reading an INT from the physical rdb and converting it into individual values, in c++ this would be done
			by reading the individual bits of this section of the rdb. Unfortunately this can not be accomplished in that manner in c#, so we read the INT
			and convert it into a BitVector32 which we can then read by position.
			
			So in the above example we read the INT { "limit_bits" } and convert it into a BitVector32 by giving this field FIELDTYPE:BIT_VECTOR, the fields
			with the variable 'bits_field' of the same name 'limit_bits' are not physically read from the rdb but are generated from the "limit_bits" field by
			reading the bit at the position given by the 'bit_position' variable.
					
			So in the above example limit_magician will generate it's value by reading the bit at position 12 in the limit_bits fields.
			
			Another unique configuration of fields in db_item is repeated or duplicated fields such as 'item_use_flag' which appears twice in a row in this 
			rdb. See the example below:
			
				Example 1:
				
					fields = 
					{
						{"item_use_flag", INT32},
						{"item_use_flag", INT32, show=0} -- Use the same name so engine will copy shown value
					}
			
			If we were to load the physical rdb in this case we could define it like so:
			
				Example 2:
				
					fields = 
					{
						{"item_use_flag", INT32},
						{"item_use_flag2", INT32 }
					}
			
			and all would be good, unfortunately if we use the above structure and attempt to load the data from the ItemResource sql table we will be prompted
			by a 'column does not exist' error. In this instance we can either simply use the rdbCore engines duplicated field feature by defining the structure
			like in Example 1, which will automatically give the field with the variable 'show' set to 0 the same value as the shown field.
			
			Or we can go a little more complex by defining the value in a special LUA variable called selectStatement, in this case you would simply define the
			value as part of the sql statement like below:
			
				selectStatement = "SELECT item_use_flag, item_use_flag as item_use_flag2  FROM dbo.ItemResource"
			
			-----------------------------
		
			In the case of db_skilltree we can not read this rdb as we would the others, this is because unlike other rdb who use a single read loop based on a 
			variable called the row count (which is part of the file header) this particular rdb uses a double read loop, where its initial loop is based off 
			the count in the header and then a secondary count based off a field in the rdb itself. 
			
			Consider the below structure example:
			
				specialCase = DOUBLELOOP

				fields = 
				{
					{ "job_id", INT32, flag=LOOPCOUNTER },
					{ "skill_id", INT32 },
					{ "min_skill_lv", INT32 },
					{ "max_skill_lv", INT32 },
					{ "lv", INT32 },
					{ "job_lv", INT32 },
					{ "jp_ratio", SINGLE },
					{ "need_skill_id_1", INT32 },
					{ "need_skill_lv_1", INT32 },
					{ "need_skill_id_2", INT32 },
					{ "need_skill_lv_2", INT32 },
					{ "need_skill_id_3", INT32 },
					{ "need_skill_lv_3", INT32 },
					{ "cenhance_min", INT32 },
					{ "cenhance_max", INT32 }
				}
			
			In this rdb structure first and foremost we need to alert the rdbCore engine to the fact that this particular rdb is a special case, we will do 
			this by defining the LUA variable specialCase. In this instance our special case will be DOUBLELOOP. Once this has been defined the engine will 
			attempt to do a secondary loop during its initial read loop, this however requires the engine know which field it will be using as the count for
			the secondary loop. This is where the 'flag' variable will come into use. By defining the 'flag' variable as LOOPCOUNTER. You are not only telling
			the engine to use this field during the read process but also to count the amount of rows in loaded data that have the same "job_id" or flag=LOOPCOUNTER
			so that it can write this count back down when you are saving this particular file.
	
			!!!NOTE: at this time there is only one specialCase and it is DOUBLELOOP!!!
			
			-----------------------------
		 
			In the case of db_monster we finally have to do some row processing with our trusty ProcessRow function, in the case of this particular rdb 
			the id field has had it's bits scrambled when it was written. This means if you just load the rdb as normal you will not get the proper id.
			In order to counter act this we will need to perform some bitwise operations on this field for each row as they are loaded. For such cases rdbCore
			already has a built in feature. Simply define the ProcessRow function.
			
			Consider the below example:
			
				local encodeMap = {}
				local decodeMap = {}

				function compute_bit_swapping()
					local j, oldValue

					for i = 0,31 do
						encodeMap[i] = i;
					end

					j = 3
					for i = 0,31 do
						oldValue = encodeMap[i]
						encodeMap[i] = encodeMap[j]
						encodeMap[j] = oldValue
						j = (j + i + 3) % 32
					end

					for i = 0,31 do
						decodeMap[encodeMap[i]] = i
					end
				end

				compute_bit_swapping()
				
				ProcessRow = function (mode, row, rowNum)

					local value = row["id"]
					local result = 0
					
					if mode == READ then		
						for i = 0,31 do
							if bit32.band(bit32.lshift(1, i), value) ~= 0 then
								result = bit32.bor(result, (bit32.lshift(1, decodeMap[i])))
							end
						end
					elseif mode == WRITE then
						for i = 0,31 do
							if bit32.band(bit32.lshift(1, i), value) ~= 0 then
								result = bit32.bor(result, (bit32.lshift(1, encodeMap[i])))
							end
						end
					end
					
					row["id"] = result
				end
		
			!!!NOTE: the ProcessRow function must always present the following arguments (mode, row, rowNum)!!!
			!!!NOTE: Any function call like compute_bit_swapping() will occur automatically and doesn't need to be called manually within ProcessRow!!!
		
			In this above example we provide the encode/decode maps by defining the tables and computing the values they will hold by calling compute_bit_swapping()
			so when ProcessRow is called by the rdbCore engine it will already have access to these variables. Now you can alter the current row being processed by 
			rdbCore because it was passed into the ProcessRow function as the 'row' argument.
			
			In this case we need to perform the bitwise operation on the field "id" so we define the local value as row["id"], here you can use strongly typed names
			as the key or you can provide the oridinal value which in this case would be row[0]. Then at the end of this operation we set the row["id"] value to the 
			newly decoded value and now we have the proper id when displayed.
		
			-----------------------------
			
			The last topic we will be covering is the proper usage of the LUA variables 'sqlColumns' and 'selectStatement'
			
			These two variables should only ever be defined in the case that your provided structure (e.g. fields) can not result in a proper insert or select. For 
			instance if you are selecting data which needs to be combined from two tables in the instance of db_skill or inserting data from a rdb whose epic  or 
			structure does not match the epic or structure of the target table.
			
			Example sqlColumns for db_npcresource (for 7.3):

				-- To send rdb data to a database table of different epic you will need to define
				-- the sql table structure below, in this instance the data is going backwards to 7.2
				-- table. If you are sending information between matching epics, do not define sqlColumns
				sqlColumns = 
				{
					"id",
					"text_id",
					"name_text_id",
					"race_id",
					"sexsual_id",
					"x",
					"y",
					"z",
					"face",
					"local_flag",
					"is_periodic",
					"begin_of_period",
					"end_of_period",
					"face_x",
					"face_y",
					"face_z",
					"model_file",
					"hair_id",
					"face_id",
					"body_id",
					"weapon_item_id",
					"shield_item_id",
					"clothes_item_id",
					"helm_item_id",
					"gloves_item_id",
					"boots_item_id",
					"belt_item_id",
					"mantle_item_id",
					"necklace_item_id",
					"earring_item_id",
					"ring1_item_id",
					"ring2_item_id",
					"motion_id",
					"is_roam",
					"roaming_id",
					"standard_walk_speed",
					"standard_run_speed",
					"walk_speed",
					"run_speed",
					"attackable",
					"offensive_type",
					"spawn_type",
					"chase_range",
					"regen_time",
					"level",
					"stat_id",
					"attack_range",
					"attack_speed_type",
					"hp",
					"mp",
					"attack_point",
					"magic_point",
					"defence",
					"magic_defence",
					"attack_speed",
					"magic_speed",
					"accuracy",
					"avoid",
					"magic_accuracy",
					"magic_avoid",
					"ai_script",
					"contact_script",
					"texture_group",
					--"type" <this field does not exist in 7.2>
				}
			
			Example select for db_skill:
			
				-- Use DISCTINT keyword to avoid duplicates left by gala
				selectStatement = "SELECT DISTINCT [id],[text_id],[is_valid],[elemental],[is_passive],[is_physical_act],[is_harmful],[is_need_target],[is_corpse],[is_toggle],[toggle_group],[casting_type],[casting_level],[cast_range],[valid_range],[cost_hp],[cost_hp_per_skl],[cost_mp],[cost_mp_per_skl],[cost_mp_per_enhance],[cost_hp_per],[cost_hp_per_skl_per],[cost_mp_per],[cost_mp_per_skl_per],[cost_havoc],[cost_havoc_per_skl],[cost_energy],[cost_energy_per_skl],[cost_exp],[cost_exp_per_enhance],[cost_jp],[cost_jp_per_enhance],[cost_item],[cost_item_count],[cost_item_count_per_skl],[need_level],[need_hp],[need_mp],[need_havoc],[need_havoc_burst],[need_state_id],[need_state_level],[need_state_exhaust],[vf_one_hand_sword],[vf_two_hand_sword],[vf_double_sword],[vf_dagger],[vf_double_dagger],[vf_spear],[vf_axe],[vf_one_hand_axe],[vf_double_axe],[vf_one_hand_mace],[vf_two_hand_mace],[vf_lightbow],[vf_heavybow],[vf_crossbow],[vf_one_hand_staff],[vf_two_hand_staff],[vf_shield_only],[vf_is_not_need_weapon],[delay_cast],[delay_cast_per_skl],[delay_cast_mode_per_enhance],[delay_common],[delay_cooltime],[delay_cooltime_mode_per_enhance],[cool_time_group_id],[uf_self],[uf_party],[uf_guild],[uf_neutral],[uf_purple],[uf_enemy],[tf_avatar],[tf_summon],[tf_monster],[skill_lvup_limit],[target],[effect_type],[state_id],[state_level_base],[state_level_per_skl],[state_level_per_enhance],[state_second],[state_second_per_level],[state_second_per_enhance],[state_type],[probability_on_hit],[probability_inc_by_slv],[hit_bonus],[hit_bonus_per_enhance],[percentage],[hate_mod],[hate_basic],[hate_per_skl],[hate_per_enhance],[critical_bonus],[critical_bonus_per_skl],[var1],[var2],[var3],[var4],[var5],[var6],[var7],[var8],[var9],[var10],[var11],[var12],[var13],[var14],[var15],[var16],[var17],[var18],[var19],[var20],[jp_01],[jp_02],[jp_03],[jp_04],[jp_05],[jp_06],[jp_07],[jp_08],[jp_09],[jp_10],[jp_11],[jp_12],[jp_13],[jp_14],[jp_15],[jp_16],[jp_17],[jp_18],[jp_19],[jp_20],[jp_21],[jp_22],[jp_23],[jp_24],[jp_25],[jp_26],[jp_27],[jp_28],[jp_29],[jp_30],[jp_31],[jp_32],[jp_33],[jp_34],[jp_35],[jp_36],[jp_37],[jp_38],[jp_39],[jp_40],[jp_41],[jp_42],[jp_43],[jp_44],[jp_45],[jp_46],[jp_47],[jp_48],[jp_49],[jp_50],[desc_id],[tooltip_id],[icon_id],[icon_file_name],[is_projectile],[projectile_speed],[projectile_acceleration] FROM dbo.SkillResource s LEFT JOIN dbo.SkillJpResource sj ON sj.skill_id = s.id"
