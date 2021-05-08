IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE NAME = 'ygo_db')

/*********************************************************************

	FILE: ygo_db.sql
    DATE: 2020-12-10
    AUTHOR: Jory A. Wernette
    DESCRIPTION:
		Builds the database, related tables, 
		and stored procedures for the Yu-Gi-Oh Database.

*********************************************************************/


/*********************************************************************
			DROPPING THE ygo_db DATABASE
*********************************************************************/
BEGIN 
	DROP DATABASE ygo_db	
	print '' print '*** dropping database ygo_db ***'
END
GO


/*********************************************************************
			CREATING the ygo_db DATABASE
*********************************************************************/
print '' print '*** creating the database ygo_db ***'
GO
CREATE DATABASE ygo_db
GO


/*********************************************************************
			USING the ygo_db DATABASE
*********************************************************************/
print '' print '*** using database ygo_db ***'
GO
USE [ygo_db]
GO


/*********************************************************************
			CREATING the Player table
*********************************************************************/
print '' print '*** creating the Player table ***'
GO 
CREATE TABLE [dbo].[Player](
	[KonamiID]		[int]			NOT NULL,
	[Email]			[nvarchar](100) NOT NULL,
	[FirstName]		[nvarchar](50) 	NOT NULL,
	[LastName]		[nvarchar](100) NOT NULL,
	[PhoneNumber]	[nvarchar](15) 	NOT NULL,
	[PasswordHash]	[nvarchar](100) NOT NULL DEFAULT 
		'9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
	[Active]		[bit]	NOT NULL DEFAULT 1,
	CONSTRAINT [pk_konamiID] PRIMARY KEY ([KonamiID]),
	CONSTRAINT [ak_email] UNIQUE ([Email] ASC)
)
GO


/*********************************************************************
			INSERTING into the Player table
*********************************************************************/
print '' print '*** creating Player data ***'
GO
INSERT INTO [dbo].[Player]
	([KonamiID], [Email], [FirstName], [LastName], [PhoneNumber])
VALUES
	(0100506737, 'joryawernette@gmail.com', 'Jory', 'Wernette', '3194716420'),
	(0100499489, 'michaelwernette@aol.com', 'Michael', 'Wernette', '3195410958'),
	(0100588987, 'youcantsitwithus3030@icloud.com', 'Chloe', 'Woodall', '3196403502')
GO


/*********************************************************************
			CREATING the Role table
*********************************************************************/
print '' print '*** creating the Role table ***'
GO
CREATE TABLE [dbo].[Role](
	[RoleID]		[nvarchar](6) NOT NULL,
	[Description]	[nvarchar](250) NULL,
	CONSTRAINT [pk_roleID] PRIMARY KEY ([RoleID] ASC)
)
GO


/*********************************************************************
			INSERTING data into the Role table
*********************************************************************/
print '' print '*** creating Role data ***'
GO
INSERT INTO [dbo].[Role]
	([RoleID], [Description])
VALUES
	('Player', 'Any player who makes decks or looks through cards'),
	('Judge', 'A player with the authority to insert cards as they are released and to create new player accounts.')
GO


/*********************************************************************
			CREATING the PlayerRole table
*********************************************************************/
print '' print '*** creating the PlayerRole table ***'
GO
CREATE TABLE [dbo].[PlayerRole](
	[KonamiID]	[int]			NOT NULL,
	[RoleID]	[nvarchar](6) 	NOT NULL,
	CONSTRAINT [pk_konamiID_roleID] PRIMARY KEY ([KonamiID], [RoleID]),
	CONSTRAINT [fk_konamiID] FOREIGN KEY ([KonamiID])
		REFERENCES [dbo].[Player]([KonamiID]),
	CONSTRAINT [fk_roleID] FOREIGN KEY ([RoleID])
		REFERENCES [dbo].[Role]([RoleID])
)
GO

/*********************************************************************
			INSERTING data into the PlayerRole table
*********************************************************************/
print '' print '*** adding PlayerRole records ***'
GO
INSERT INTO [dbo].[PlayerRole]
		([KonamiID], [RoleID])
	VALUES
		(0100506737, 'Judge'),
		(0100499489, 'Judge'),
		(0100588987, 'Player')
GO




/*********************************************************************
			
			
			CREATING PROCEDURES FOR Players
			
			
*********************************************************************/
print '' print '*** USER PROCEDURES FOR Players ***'
GO


/*********************************************************************
			CREATING sp_authenticate_user
*********************************************************************/
print '' print '*** creating sp_authenticate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@Email			[nvarchar](100),
	@PasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		SELECT COUNT(Email)
		FROM Player
		WHERE Email = @Email
		AND PasswordHash = @PasswordHash
		AND Active = 1
	END
GO


/*********************************************************************
			CREATING sp_update_passwordhash
*********************************************************************/
print '' print '*** creating sp_update_passwordhash ***'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordhash]
	(
	@Email				[nvarchar](100),
	@OldPasswordHash	[nvarchar](100),
	@NewPasswordHash	[nvarchar](100)
	)
AS
	BEGIN
		UPDATE Player
			SET PasswordHash = @NewPasswordHash
			WHERE Email = @Email
			AND PasswordHash = @OldPasswordHash
		RETURN @@ROWCOUNT
	END
GO


/*********************************************************************
			CREATING sp_select_user_by_email
*********************************************************************/
print '' print '*** creating sp_select_user_by_email ***'
GO
CREATE PROCEDURE [dbo].[sp_select_user_by_email]
	(
	@Email				[nvarchar](100)
	)
AS
	BEGIN
		SELECT KonamiID, Email, FirstName, LastName, PhoneNumber, Active
		FROM Player
		WHERE Email = @Email
	END
GO


/*********************************************************************
			CREATING sp_select_roles_by_konamiID
*********************************************************************/
print '' print '*** creating sp_select_roles_by_konamiID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_roles_by_konamiID]
	(
	@KonamiID				[int]
	)
AS
	BEGIN
		SELECT 	RoleID
		FROM 	PlayerRole
		WHERE 	KonamiID = @KonamiID
	END
GO


/*********************************************************************
			CREATING sp_update_player_profile_data
*********************************************************************/
print '' print '*** creating sp_update_player_profile_data ***'
GO
CREATE PROCEDURE [dbo].[sp_update_player_profile_data]
	(
	@KonamiID				[int],
	@NewEmail				[nvarchar](100),
	@NewFirstName			[nvarchar](50),
	@NewLastName			[nvarchar](50),
	@NewPhoneNumber			[nvarchar](15),	
	@OldEmail				[nvarchar](100),
	@OldFirstName			[nvarchar](50),
	@OldLastName			[nvarchar](50),
	@OldPhoneNumber			[nvarchar](15)
	)
AS
	BEGIN
		UPDATE Player
			SET Email = @NewEmail,
				FirstName = @NewFirstName,
				LastName = @NewLastName,
				PhoneNumber = @NewPhoneNumber
			WHERE KonamiID = @KonamiID
			AND Email = @OldEmail
			AND Firstname = @OldFirstName
			AND LastName = @OldLastName
			AND PhoneNumber = @OldPhoneNumber
		RETURN @@ROWCOUNT
	END
GO




/*********************************************************************
			
			
			CREATING PROCEDURES FOR Judges
			
			
*********************************************************************/
print '' print '*** USER PROCEDURES FOR Judges ***'
GO


/*********************************************************************
			CREATING sp_insert_new_user
*********************************************************************/
print '' print '*** creating sp_insert_new_user ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_new_user]
(
	@KonamiID		[int],
	@Email			[nvarchar](100),
	@FirstName		[nvarchar](50),
	@LastName		[nvarchar](100),
	@PhoneNumber	[nvarchar](15)
)
AS
	BEGIN
		INSERT INTO [dbo].[Player]
			([KonamiID], [Email], [FirstName], [LastName], [PhoneNumber])
		VALUES
			(@KonamiID, @Email, @FirstName, @LastName, @PhoneNumber)
	END
GO


/*********************************************************************
			CREATING sp_select_all_users
*********************************************************************/
print '' print '*** creating sp_select_all_users ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_users]
AS
	BEGIN
		SELECT KonamiID, Email, FirstName, LastName, PhoneNumber, Active
		FROM Player
		ORDER BY LastName ASC
	END
GO


/*********************************************************************
			CREATING sp_select_users_by_active
*********************************************************************/
print '' print '*** creating sp_select_users_by_active ***'
GO
CREATE PROCEDURE [dbo].[sp_select_users_by_active]
(
	@Active			[bit]
)
AS
	BEGIN
		SELECT KonamiID, Email, FirstName, LastName, PhoneNumber, Active
		FROM Player
		WHERE Active = @Active
		ORDER BY LastName ASC
	END
GO


/*********************************************************************
			CREATING sp_select_players_by_id
*********************************************************************/
print '' print '*** creating sp_select_players_by_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_players_by_id]
	(
	@KonamiID				[int]
	)
AS
	BEGIN
		SELECT KonamiID, Email, FirstName, LastName, PhoneNumber, Active
		FROM Player
		WHERE KonamiID = @KonamiID
	END
GO


/*********************************************************************
			CREATING sp_reset_passwordhash
*********************************************************************/
print '' print '*** creating sp_reset_passwordhash ***'
GO
CREATE PROCEDURE [dbo].[sp_reset_passwordhash]
	(
	@Email				[nvarchar](100)
	)
AS
	BEGIN
		UPDATE Player
			SET PasswordHash = '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E'
			WHERE Email = @Email
		RETURN @@ROWCOUNT
	END
GO

/*********************************************************************
			CREATING sp_reactivate_user
*********************************************************************/
print '' print '*** creating sp_reactivate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_reactivate_user]
	(
	@KonamiID			[int]
	)
AS
	BEGIN
		UPDATE Player
			SET Active = 1 
			WHERE KonamiID = @KonamiID
		RETURN @@ROWCOUNT
	END
GO

/*********************************************************************
			CREATING sp_add_playerrole
*********************************************************************/
print '' print '*** creating sp_add_playerrole ***'
GO
CREATE PROCEDURE [dbo].[sp_add_playerrole]
	(
		@KonamiID			[int],
		@RoleID				[nvarchar](25)
	)
AS
	BEGIN
		INSERT INTO PlayerRole
				([KonamiID], [RoleID])
			VALUES
				(@KonamiID, @RoleID)
		RETURN @@ROWCOUNT
	END
GO

/*********************************************************************
			CREATING sp_select_all_roles
*********************************************************************/
print '' print '*** creating sp_select_all_roles ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT 	RoleID
		FROM 	Role
		ORDER BY RoleID ASC
	END
GO

/*********************************************************************
			CREATING sp_safely_remove_playerrole
*********************************************************************/
print '' print '*** creating sp_safely_remove_playerrole ***'
GO
CREATE PROCEDURE [dbo].[sp_safely_remove_playerrole]
	(
		@KonamiID			[int],
		@RoleID				[nvarchar](25)
	)
AS
	BEGIN
		DECLARE @Judges int;

		SELECT @Judges = COUNT(RoleID)
		FROM PlayerRole
		WHERE RoleID = 'Judge';

		IF @RoleID = 'Judge' AND @Judges = 1
			BEGIN
				RETURN 0
			END
		ELSE
			BEGIN
				DELETE FROM PlayerRole
					WHERE KonamiID = @KonamiID
					  AND RoleID = @RoleID
				RETURN @@ROWCOUNT	
			END
	END
GO


/*********************************************************************
			CREATING sp_safely_deactivate_player
*********************************************************************/
print '' print '*** creating sp_safely_deactivate_player ***'
GO
CREATE PROCEDURE [dbo].[sp_safely_deactivate_player]
	(
	@KonamiID			[int]
	)
AS
	BEGIN
		DECLARE @Judges int;

		SELECT @Judges = COUNT(RoleID)
		FROM PlayerRole
		WHERE RoleID = 'Judge'
		  AND PlayerRole.KonamiID = @KonamiID;

		IF @Judges = 1
			BEGIN
				RETURN 0
			END
		ELSE
			BEGIN
				UPDATE Player
					SET Active = 0 
					WHERE Player.KonamiID = @KonamiID
				RETURN @@ROWCOUNT
			END
	END
GO


/*********************************************************************
			CREATING sp_add_new_card
*********************************************************************/
print '' print '*** creating sp_add_new_card ***'
GO
CREATE PROCEDURE [dbo].[sp_add_new_card]
(
	@CardID			[nvarchar](10),
	@CardName		[nvarchar](75),
	@CardCategory	[nvarchar](7),
	@CardType		[nvarchar](12),
	@MonsterType	[nvarchar](13),
	@MonsterSubType	[nvarchar](8),
	@MonsterAttribute[nvarchar](6),
	@LevelRank		[int],
	@Attack			[int],
	@Defense		[int],
	@PendulumScale	[int],
	@LinkNumber		[int],
	@BanlistPlacement		[nvarchar](12),
	@CardText	[nvarchar](1000)
)
AS
	BEGIN
		INSERT INTO [dbo].[Card]
			([CardID], [CardName], [CardCategory], [CardType], [MonsterType], [MonsterSubType], [MonsterAttribute], [LevelRank], [Attack], [Defense], [PendulumScale], [LinkNumber], [BanlistPlacement], [CardText])
		VALUES
			(@CardID, @CardName, @CardCategory, @CardType, @MonsterType, @MonsterSubType, @MonsterAttribute, @LevelRank, @Attack, @Defense, @PendulumScale, @LinkNumber, @BanlistPlacement, @CardText)
	END
GO


/*********************************************************************
			CREATING sp_update_a_card
*********************************************************************/
print '' print '*** creating sp_update_a_card ***'
GO
CREATE PROCEDURE [dbo].[sp_update_a_card]
	(	
	@CardID				[nvarchar](10),
	@NewCardName		[nvarchar](75),
	@NewCardCategory	[nvarchar](7),
	@NewCardType		[nvarchar](12),
	@NewMonsterType		[nvarchar](13),
	@NewMonsterSubType	[nvarchar](8),
	@NewMonsterAttribute[nvarchar](6),
	@NewLevelRank		[int],
	@NewAttack			[int],
	@NewDefense			[int],
	@NewPendulumScale	[int],
	@NewLinkNumber		[int],
	@NewBanlistPlacement[nvarchar](12),
	@NewCardText		[nvarchar](1000),
	
	@OldCardName		[nvarchar](75),
	@OldCardCategory	[nvarchar](7),
	@OldCardType		[nvarchar](12),
	@OldMonsterType		[nvarchar](13),
	@OldMonsterSubType	[nvarchar](8),
	@OldMonsterAttribute[nvarchar](6),
	@OldLevelRank		[int],
	@OldAttack			[int],
	@OldDefense			[int],
	@OldPendulumScale	[int],
	@OldLinkNumber		[int],
	@OldBanlistPlacement[nvarchar](12),
	@OldCardText		[nvarchar](1000)
	)
AS
	BEGIN
		UPDATE Card
			SET
				CardName = @NewCardName,
				CardCategory = @NewCardCategory,
				CardType = @NewCardType,
				MonsterType = @NewMonsterType,
				MonsterSubType = @NewMonsterSubType,
				MonsterAttribute = @NewMonsterAttribute,
				LevelRank = @NewLevelRank,
				Attack = @NewAttack,
				Defense = @NewDefense,
				PendulumScale = @NewPendulumScale,
				LinkNumber = @NewLinkNumber,
				BanlistPlacement = @NewBanlistPlacement,
				CardText = @NewCardText				
			WHERE CardID = @CardID
				AND CardName = @OldCardName
				AND CardCategory = @OldCardCategory
				AND CardType = @OldCardType
				AND MonsterType = @OldMonsterType
				AND MonsterSubType = @OldMonsterSubType
				AND MonsterAttribute = @OldMonsterAttribute
				AND LevelRank = @OldLevelRank
				AND Attack = @OldAttack
				AND Defense = @OldDefense
				AND PendulumScale = @OldPendulumScale
				AND LinkNumber = @OldLinkNumber
				AND BanlistPlacement = @OldBanlistPlacement
				AND CardText = @OldCardText	
		RETURN @@ROWCOUNT
	END
GO


/*********************************************************************
			CREATING sp_update_a_cards_banlistplacement
*********************************************************************/
print '' print '*** creating sp_update_a_cards_banlistplacement ***'
GO
CREATE PROCEDURE [dbo].[sp_update_a_cards_banlistplacement]
	(
	@CardName			[nvarchar](75),
	@NewBanlistPlacement[nvarchar](12),
	
	@OldBanlistPlacement[nvarchar](12)
	)
AS
	BEGIN
		UPDATE Card
			SET
				BanlistPlacement = @NewBanlistPlacement		
			WHERE CardName = @CardName

				AND BanlistPlacement = @OldBanlistPlacement
		RETURN @@ROWCOUNT
	END
GO


/*********************************************************************
			
			
			CREATING Card Tables
			
			
*********************************************************************/
print '' print '*** CREATING Card Tables ***'
GO


/*********************************************************************
			CREATING the CardCategory table
*********************************************************************/
print '' print '*** creating the CardCategory table ***'
GO 
CREATE TABLE [dbo].[CardCategory](
	[CardCategory]			[nvarchar](7)	NOT NULL,
	[CategoryDescription]	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_cardCategory] PRIMARY KEY ([CardCategory])
)
GO


/*********************************************************************
			INSERTING data into the CardCategory table
*********************************************************************/
print '' print '*** inserting CardCategory data ***'
GO
INSERT INTO [dbo].[CardCategory]
		([CardCategory], [CategoryDescription])
	VALUES
		('Monster', 'Monsters battle against each ither or directly against either player during the Battle Phase. Monsters are the main focus of Yu-Gi-Oh!. Monster Cards are differentiated by their names, Type, Attribute, Attack, Defense, Level (or Rank or Link Rating). Monster Cards can be subdivided into Normal, Effect, Ritual, Fusion, Synchro, Xyz, Pendulum, and Link Monsters, each with a distinctive colored frame to differentiate them.'),
		('Spell', 'Spell Cards are cards with green-colored borders that have various effects to alter the play of the game. Often, a Spell Card has a single effect to provide a bonus to the user or a weakness to the opponent. Unlike Trap Cards, Spell Cards have the advantage of being able to be played without having to be Set first. Spell Cards, except Quick-Play Spell Cards, may be activated during the same turn it was Set only during the turn players Main Phase 1 or 2.'),
		('Trap', 'Trap Cards are cards with purple-colored borders that have various effects. A Trap Card must first be Set and can only be activated after the current turn has finished. After that, it may be activated during either players turn. Trap Cards are Spell Speed 2, with the exception of Counter Trap Cards, which are Spell Speed 3.')
GO


/*********************************************************************
			CREATING the CardType table
*********************************************************************/
print '' print '*** creating the CardType table ***'
GO 
CREATE TABLE [dbo].[CardType](
	[TypeName] 			[nvarchar](12) 	NOT NULL,
	[TypeDescription] 	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_typeName] PRIMARY KEY ([TypeName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the CardType table
*********************************************************************/
print '' print '*** inserting CardType data ***'
GO
INSERT INTO [dbo].[CardType]
		([TypeName], [TypeDescription])
	VALUES
		('Normal', 'Normal Monsters are colored yellow, are Main Deck monsters with no monster effects. In the card description box (which contains the effect on Effect Monsters), Normal Monsters include a brief description of its lore. A Normal Spell Card is a Spell Speed 1 Spell Card, so it cannot chain to other effects. Normal Trap Cards are Spell Speed 2, and can be used in response to the effects of everything that is classified as Spell Speed 1, such as Effect Monsters, and Spell Cards, or Spell Speed 2, which include Quick Effects, most other Trap Cards, and Quick-Play Spell Cards.'),
		('Effect', 'Effect Monsters are Monster Cards with an orange color border. Effect Monsters necessarily have at least one card effect or condition.'),
		('Fusion', 'Fusion Monsters are a type of Monster Card. The color of their card frame is violet. These cards are placed in the Extra Deck.To be properly Special Summoned, Fusion Monsters must first be Fusion Summoned (unless otherwise specified). If they leave the Extra Deck without being properly Special Summoned, they cannot be Special Summoned while they are banished or in the Graveyard. Most Fusion Monsters have a set of Fusion Materials, which are listed on the first line of the cards text. These are the materials used to perform the Summon of that monster. Like other Extra Deck monsters, Fusion Monsters cannot exist in the hand or Main Deck. If a Fusion Monster would be moved to the hand or Main Deck, it is returned to the Extra Deck instead.'),
		('Synchro', 'Synchro Monsters are a type of Monster Card. The color of their card frame is white. These cards are placed in the Extra Deck. To be properly Special Summoned, Synchro Monsters must first be Synchro Summoned. If they leave the Extra Deck without being Synchro Summoned, they cannot be Special Summoned while they are banished or in the Graveyard. Like other Extra Deck monsters, Synchro Monsters cannot exist in the hand or Main Deck. If a Synchro Monster would be moved to the hand or Main Deck, it is returned to the Extra Deck instead.'),
		('Xyz', 'Xyz Monsters is a type of Monster Card that is colored black. They are stored in the Extra Deck. The card frame is also stylized by having it appear as if one is flying through space with many stars in the frame. Like other Extra Deck monsters, Xyz Monsters cannot exist in the hand or Main Deck. If an Xyz Monster would be moved to the hand or Main Deck, it is returned to the Extra Deck instead. Like other Extra Deck monsters, if an Xyz Monster is not Xyz Summoned first, it cannot be Special Summoned from the Graveyard or while banished (unless it specifies another way to properly Special Summon it).'),
		('Link', 'A Link Monster is a type of Monster Card. The color of their card frame is dark blue, which is similar to that of a Ritual Monster, but with a hexagonal pattern similar to a honeycomb structure. These cards are placed in the Extra Deck. Like other Extra Deck monsters, Link Monsters cannot exist in either the hand or the Main Deck. If a Link Monster would be moved to the hand or Main Deck, it is returned to the Extra Deck instead. If a Link Monster is not Link Summoned first, it cannot be Special Summoned from the Graveyard or while banished (unless it specifies another way to properly Special Summon it).'),
		('Ritual', 'Ritual Monsters, colored blue, are monsters that must be Special Summoned with a Ritual Spell Card and belong in the Main Deck. Ritual Monsters are Special Summon-only monsters. This means that they cannot be Normal Summoned or Tribute Summoned from the hand and cannot be Special Summoned from the Graveyard or while banished unless they were first Ritual Summoned.'),
		('Field', 'Field Spell Cards have the advantage of being able to change the entire state of play for its controllers or for both players side of the field. They are Spell Speed 1 and are placed on the Field Zone, apart from the Spell & Trap Zones.'),
		('Quick-Effect', 'Quick-Play Spell Cards, known as Instant Spell Cards, are a type of Spell Card that are Spell Speed 2. The turn player can activate Quick-Play Spell Cards from their hand during any Phase of their turn; either player can activate Set Quick-Play Spell cards during any Phase in either players turn, except during the turn they are Set.'),
		('Continuous', 'A Continuous Spell Card is a Spell Speed 1 Spell Card that stays on the field once it is activated. Similarly a Continuous Trap Card is a Card that stays on the field once it is activated, but is a Spell Speed 2 Card since it is a Trap Card.'),
		('Counter', 'Counter Trap Cards are a unique Trap card type that are of Spell Speed 3. Being the only cards/effects that are Spell Speed 3, only other Counter Trap Cards can be activated in response to them. Most of them can only be activated to negate or punish the activations of other cards, or Summons of monsters. Although there are some that can be used to start a Chain on their own by the mechanic, such as "Intercept" and "Drastic Drop Off", their activation requirements is against an action that does not start a chain.')
GO


/*********************************************************************
			CREATING the MonsterType table
*********************************************************************/
print '' print '*** creating the MonsterType table ***'
GO 
CREATE TABLE [dbo].[MonsterType](
	[MonsterTypeName] 			[nvarchar](13) 	NOT NULL,
	[MonsterTypeDescription] 	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_monsterTypeName] PRIMARY KEY ([MonsterTypeName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the MonsterType table
*********************************************************************/
print '' print '*** inserting MonsterType data ***'
GO
INSERT INTO [dbo].[MonsterType]
		([MonsterTypeName], [MonsterTypeDescription])
	VALUES
		('Aqua', 'Aqua is a monster Type that has power over water or ice. They may also represent aquatic or amphibious creatures that do not fall under the category of Fish or Sea Serpent, like sea-borne mammals and amphibians. In the same respect, most Aqua-Type monsters are WATER monsters, though Aqua-Type monsters for almost every other Attribute do exist. Aqua-Type effects are varied, but many of the best focus on hand control.'),
		('Beast', 'Beast is a Type of monster consisting mainly of wild animals. They are typically EARTH Attribute monsters, although LIGHT and FIRE monsters of this type are not uncommon. Beast-Type monsters are often overlooked, but often have great utility. Because they are relatively low in number compared to more popular monster types, there is no one specific theme or strategy common to them, though many have effects that assist them during the Battle Phase. Many Beasts are weaker utility monsters that splash well into other Decks.'),
		('Beast-Warrior', 'Beast-Warrior is a Type of monster that usually resembles anthropomorphic animals or other half-man, half-animal creatures such as centaurs. Their effects generally apply after destroying a monster, and help them destroy monsters more easily. Many of their effects also deal with Normal Monsters.'),
		('Cyberse','Appearance-wise, Cyberse Monsters resemble creatures and humanoids strongly connected to elements of digital technology and cyberspace. At times though, they tend to resemble other various monster types (most commonly Machine and Psychic monsters, with the humanoids bearing design elements from the TRON franchise). Their general theme revolves around swarming the field with weak monsters to easily Link Summon powerful Link Monsters, and they also have lots of monsters that gain effects when banished in a similar vein to Psychic monsters.'),
		('Dinosaur','Dinosaur is a type of monster that primarily relies on beatdown tactics and sometimes Monster effects, to help a Duelist prevail in a Duel. There are many high-level Dinosaur-Type monsters, so the general strategy for them is to Summon their high-Level monsters as quickly as possible.'),
		('Divine-Beast','Divine-Beast , called God Cards in the manga, is a Type used for the Egyptian God Cards: "Slifer the Sky Dragon", "Obelisk the Tormentor", and "The Winged Dragon of Ra".'),
		('Dragon','Dragon is a Type of Monster representing mythological serpentine, reptile, avian like beings that are typically fire-breathing creatures that symbolize chaos, brutality, fierceness and intimidation. Dragons tend to be the strongest or key boss monster in numerous Deck types in addition one of the most established and powerful Monster Types in the entire franchise. Ever since the inception of the Yu-Gi-Oh! Trading Card franchise, Dragon monsters have been known for having an Attack power greater than any other type of monster in the game in addition to being the one of the most popular monster Types.'),
		('Fairy','Fairy is a Type of monster often represented by beings such as sprites, angels, or in some occasions, anything that represents organic and mechanical beings of advanced extraterrestrial origin. They are primarily LIGHT, although there are also those of all six common Attributes.'),
		('Fiend','Fiend is a monster Type symbolizing darkness, wickedness, perniciousness, and diabolical horror. They are often demons, devils or ghosts, and are almost exclusively DARK-Attribute. The majority of Fiends focus on offensive beatdown tactics and destroying the opponents cards, as well as pressuring the opponent by cornering them with stun and lockdown effects, banishing effects, or deck milling.'),
		('Fish','Fish rely heavily on using removal to allow them to perform their OTK without interruption. Many Fish support monsters have effects that require the presence or Tribute of another Fish to activate, or focus on manipulating advantage through banishing'),
		('Insect','Insect monsters are a versatile, and somewhat well-supported Type of Monster that go hand-in-hand with Plant-Type monsters. The common attributes associated with them are EARTH and WIND. They typically act like their namesake by swarming the field, and can sometimes prove to be quite an annoyance to players by using their unique abilities. '),
		('Machine','Machine is a Type of monster representing robots, transportation vehicles (including spacecraft) and other mechanical objects. Machine monsters are powerful, and in some cases, fearsome to face in battle. They rely on high ATK as well as a variety of powerful effects, and they have some of the strongest Fusion Monsters. Most Machine monsters have DARK, EARTH, or LIGHT Attributes. Their general strategy varies, but they often have the ability to negate the effects of specific opposing cards and/or destroy them.'),
		('Plant','The usual Attributes associated with Plants are EARTH or WATER. Plant cards usually revolve around swarming and regenerating back onto the field. Unlike Zombies, Plants are often used to fuel effects such as negations rather than for strictly attacking purposes. They have many cards that allow them to be Special Summoned from the Deck and hand but mostly from the Graveyard. Cards like "Lonefire Blossom", "Plant Food Chain", "Lord Poison", "Gigaplant", "The World Tree" and "Miracle Fertilizer" all add major support to bringing back a swarm of Plant monsters to overwhelm the opponent.'),
		('Psychic','Psychic monsters often resemble cyberpunk androids, cybernetically-enhanced humans, or strange mutants, and often feature elements of cyberspace, circuit board patterns, green coloring, and yellow electricity in their art.'),
		('Pyro','Pyro is a Type of monster that is almost always of the FIRE Attribute, and represent control over FIRE, or they may be an embodiment of fire itself. Their effects often involve the dealing of effect damage to the opponent.'),
		('Reptile','Reptiles have come into their own as a Type that focuses on controlling the opponent with the use of Counters. Many Reptiles focus upon weakening the opponent instead of strengthening themselves, often leaving the opponent powerless. Because of this, Reptile-based decks and archetypes focus on tactics that reward patience and strategy over simplicity and brute force.'),
		('Rock','Rock monsters are an often-overlooked Type, though there were many released in The Lost Millennium. Usually, Rock monsters belong to the EARTH Attribute and possess high DEF and defense-related card effects. A significant number of Rock monsters have effects related to Flip Summoning or have the ability to flip themselves face-down again.'),
		('Sea Serpent','Sea Serpent is a Type of monster representing mythological, dragon-like creatures living in the sea.'),
		('Spellcaster','Spellcaster is a Type of Monster consisting of beings that control magic, such as witches, wizards, and mages. The majority of these creatures contain effects and can be very versatile Monsters, used often with support of Spell Cards.'),
		('Thunder','Thunder monsters are generally LIGHT, although there are EARTH, WATER or WIND minorities as well. Thunder monsters usually represent beings with electrical powers. Many Thunder card effects and support cards focus upon destroying the opponents monsters by effect.'),
		('Warrior','Warrior Monsters are a diverse, versatile, and popular Type of Monster Card. There are Warriors of every Attribute, primarily EARTH, DARK and LIGHT. The Warrior-Type is the most human-like Type of monster, consisting of many human knights, brawlers, rogues, etc.'),
		('Winged-Beast','Winged-Beast Monsters represent creatures of flight such as birds, bats, and harpies.'),
		('Wyrm','A Wyrm is a Type of monster that resemble dragons, but unlike the Dragon-Type Monsters, they take more of a spiritual, mythical, metaphysical look.'),
		('Zombie','Zombie is a Type of monster representing undead beings, including mummies, skeletons, vampires and ghosts. Their focus is swarming the field from the Graveyard.'),
		('','This card does not have a Type.')
GO


/*********************************************************************
			CREATING the MonsterSubType table
*********************************************************************/
print '' print '*** creating the MonsterSubType table ***'
GO 
CREATE TABLE [dbo].[MonsterSubType](
	[MonsterSubTypeName] 			[nvarchar](8) 	NOT NULL,
	[MonsterSubTypeDescription] 	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_monsterSubTypeName] PRIMARY KEY ([MonsterSubTypeName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the MonsterSubType table
*********************************************************************/
print '' print '*** inserting MonsterSubType data ***'
GO
INSERT INTO [dbo].[MonsterSubType]
		([MonsterSubTypeName], [MonsterSubTypeDescription])
	VALUES
		('Flip','Flip Monsters are Effect Monsters with the ability "Flip". A Flip effect is a type of Trigger Effect that is preceded by "FLIP:". This kind of effect meets its activation timing when the Flip monster on the field is flipped from face-down to a face-up, even during the Damage Step.'),
		('Gemini','Gemini Monsters are Effect Monsters with the "Gemini" ability. They are treated as Normal Monsters on the field and in the GY, and can gain their effects by performing an additional Normal Summon on them while they are face-up on the field.'),
		('Pendulum','A Pendulum Monster, also known as a Pendulum Card, is a type of Monster Card that is half green. In addition to normal usages, a Pendulum Monster can also be activated from the hand as a Spell Card in a Pendulum Zone; if there are Pendulum Monsters in both Pendulum Zones, the player can perform a Pendulum Summon. So far, Normal, Effect, Fusion, Synchro and Xyz Pendulum Monsters have been seen. Pendulum Monsters can also be Tuner, Flip and Spirit monsters.'),
		('Spirit','Spirit Monsters are Effect Monsters with the ability "Spirit". Each of this type of monster has an effect that returns it to its owners hand during the End Phase of the turn it is Normal Summoned or flipped face-up (or the turn it is Special Summoned in case of Spirit monsters that must be Special Summoned). The designs of most Spirit monsters are based on icons from Eastern mythology and all have very similar backgrounds.'),
		('Toon','Toon Monsters are cartoonized counterparts of existing monsters, having some reliance on the card "Toon World". Toon monsters exist as separate cards than their non-Toon counterpart, with whom they share no direct in-game relationship. They are capable of attacking the opponent directly and while they benefit from the card "Toon World", they can be used without it.'),
		('Tuner','Tuner Monsters are required for the Synchro Summon of a Synchro Monster. Normal, Fusion, Effect, Pendulum, and Synchro Monsters themselves can all be Tuner monsters, although some card effects can treat non-Tuner monsters as Tuners. Flip and Union monsters and Special Summon Monsters can also be Tuner monsters.'),
		('Union','Union Monsters are Effect Monsters with the "Union" ability. Each Union monster has an effect that allows it to equip itself to a monster as an Equip Spell Card or unequip itself to Special Summon itself to a Monster Zone.'),
		('','This card does not have a SubType.')
GO


/*********************************************************************
			CREATING the MonsterAttribute table
*********************************************************************/
print '' print '*** creating the MonsterAttribute table ***'
GO 
CREATE TABLE [dbo].[MonsterAttribute](
	[AttributeName] 		[nvarchar](6) 	NOT NULL,
	[AttributeDescription] 	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_attributeName] PRIMARY KEY ([AttributeName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the MonsterAttribute table
*********************************************************************/
print '' print '*** inserting MonsterAttribute data ***'
GO
INSERT INTO [dbo].[MonsterAttribute]
		([AttributeName], [AttributeDescription])
	VALUES
		('Dark', 'DARK monsters and the cards akin to them can work with many different Deck Types, and rarely does a typical deck lack at least one. Because they are so widespread, DARK monsters have themes comparable to many other Attributes. DARK monsters specialize in more than any other Attribute are card effects relating to the Graveyard, often by using it as a resource in some way. In terms of lore, a large number of "evil" and demonic monsters are DARK, but the attribute itself is not strictly associated with evil.'),
		('Divine', 'The DIVINE Attribute  only used on the Egyptian God Cards.'),
		('Earth', 'EARTH monsters are powerful cards focused on both brute strength and rock-solid defense. EARTH monsters tie with DARK for being among the most numerous and widespread; unless a deck is specifically themed around a particular Attribute, it will almost always have a few EARTH monsters. Decks dedicated to EARTH will often be able to pound an unprepared opponent into the dust; though they rely less heavily upon special effects to win the day, what effects they do have often enhance their combat abilities.'),
		('Fire', 'FIRE is an Attribute commonly associated with Pyro, Dragon, Dinosaur and Machine-Type monsters, though it is not uncommon in other Types such as Warrior or even Beast. FIRE is diametrically opposed to WATER, but there is no direct advantage.'),
		('Light', 'Light monsters are the historic opposites of DARK Monsters. Some LIGHT cards focus on overwhelming offensive power, such as the "Blue-Eyes White Dragon" and the fusion forms of "Cyber Dragon", but others focus on positively reinforcing the player instead of directly damaging the opponent, such as by increasing their Life Points or allowing the player to draw extra cards from their Deck. LIGHT monsters will in general either be highly offensive or highly defensive with little middle ground.'),
		('Water', 'WATER is a very versatile Attribute, and even has a semi-viable Deck based around such monsters, the Water Deck. The Monster Types typically associated with WATER are Aqua, Fish, and Sea Serpent, though Plants and Reptiles are not uncommonly WATER monsters. WATER is usually thought of as the opposite to FIRE, though there is no real advantage for either Attribute over each other.'),
		('Wind', 'Wind is an Attribute commonly associated with Winged Beast-Type monsters, though Insect, Fairy, Dragon, and Psychic-Type WIND monsters are not uncommon. There are many cards for the removal and/or destruction of Spell and Trap Cards that make reference to the Natural Phenomena related to Wind like "Mystical Space Typhoon", "Twister", "Typhoon", "Tornado", "Dust Tornado", "Heavy Storm", "Cyclone Boomerang", "Malevolent Catastrophe", "Harpies Feather Duster", "Pendulum Storm" etc.'),
		('','This card does not have an attribute.')
GO


/*********************************************************************
			CREATING the BanlistPlacement table
*********************************************************************/
print '' print '*** creating the BanlistPlacement table ***'
GO 
CREATE TABLE [dbo].[BanlistPlacement](
	[BanlistPlacementName] 		[nvarchar](12) 	NOT NULL,
	[BanlistPlacementDescription] 	[nvarchar](750) NOT NULL,
	CONSTRAINT [pk_banlistPlacementName] PRIMARY KEY ([BanlistPlacementName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the BanlistPlacement table
*********************************************************************/
print '' print '*** inserting BanlistPlacement data ***'
GO
INSERT INTO [dbo].[BanlistPlacement]
		([BanlistPlacementName], [BanlistPlacementDescription])
	VALUES
		('Forbidden','A player can have 0 copies of a Forbidden Card in their deck.'),
		('Limited','A player can have 1 copy of a Limited Card in their deck.'),
		('Semi-Limited','A player can have 2 copies of a Semi-Limited Card in their deck.'),
		('Unlimited','A player can have 3 copies of an Unlimited Card in their deck.')
GO


/*********************************************************************
			CREATING the Card table
*********************************************************************/
print '' print '*** creating the Card table ***'
GO 
CREATE TABLE [dbo].[Card](
	[CardID]		[nvarchar](10)		NOT NULL, -- LOB-EN001
	[CardName]		[nvarchar](75)	NOT NULL, -- Blue-Eyes White Dragon
	[CardCategory]	[nvarchar](7) 	NOT NULL, -- Monster
	[CardType]		[nvarchar](12)	NOT NULL, -- Normal
	[MonsterType]	[nvarchar](13) 	NUll,	  -- Dragon
	[MonsterSubType][nvarchar](8)	NULL,	  -- NULL
	[MonsterAttribute] [nvarchar](6)NULL,	  -- Light
	[LevelRank]		[int]			NULL,	  -- NULL
	[Attack]		[int]			NULL,	  -- 3000
	[Defense]		[int]			NULL,	  -- 2500
	[PendulumScale]	[int]			NULL,	  -- NULL
	[LinkNumber]	[int]			NULL,	  -- NULL
	[BanlistPlacement][nvarchar](12)NOT NULL, -- Unlimited
	[CardText]		[nvarchar](1000)NOT NULL,
	[Active]		[bit]			NOT NULL DEFAULT 1,
	CONSTRAINT [pk_cardName] PRIMARY KEY ([CardName] ASC),
	CONSTRAINT [fk_cardCategory] FOREIGN KEY ([CardCategory]) 
		REFERENCES [dbo].[CardCategory]([CardCategory]),
	CONSTRAINT [fk_cardType] FOREIGN KEY ([CardType])
		REFERENCES [dbo].[CardType]([TypeName]),
	CONSTRAINT [fk_monsterType] FOREIGN KEY ([MonsterType])
		REFERENCES [dbo].[MonsterType]([MonsterTypeName]),
	CONSTRAINT [fk_monsterSubType] FOREIGN KEY ([MonsterSubType])
		REFERENCES [dbo].[MonsterSubType]([MonsterSubTypeName]),
	CONSTRAINT [fk_monsterAttribute] FOREIGN KEY ([MonsterAttribute])
		REFERENCES [dbo].[MonsterAttribute]([AttributeName]),
	CHECK (LevelRank < 13),
	CHECK (PendulumScale < 13),
	CHECK (LinkNumber < 7),
	CONSTRAINT [fk_banlistPlacement] FOREIGN KEY ([BanlistPlacement])
		REFERENCES [dbo].[BanlistPlacement]([BanlistPlacementName]),
	CONSTRAINT [ak_cardID] UNIQUE ([CardID] ASC),
	CONSTRAINT [ak_cardName] UNIQUE ([CardName] ASC)
)
GO


/*********************************************************************
			INSERTING data into the Card table
*********************************************************************/
print '' print '*** inserting Card data ***'
GO
INSERT INTO [dbo].[Card]
		([CardID], [CardName], [CardCategory], [CardType], [MonsterType], [MonsterSubType], [MonsterAttribute], [LevelRank], [Attack], [Defense], [PendulumScale], [LinkNumber], [BanlistPlacement], [CardText])
	VALUES
	/* 		TEMPLATE
	('[CardID]', '[CardName]', '[CardCategory]', '[CardType]', '[MonsterType]', '[MonsterSubType]', '[MonsterAttribute]', '[LevelRank]', '[Attack]', '[Defense]', '[PendulumScale]', '[LinkNumber', '[BanlistPlacement]', '[CardText]')
	*/
		('LOB-EN000', 'Tri-Horned Dragon', 'Monster', 'Normal', 'Dragon', '', 'Light', 8, 2850, 2350, '', '', 'Unlimited', 'An unworthy dragon with three sharp horns sprouting from its head.'),
		('LOB-EN001', 'Blue-Eyes White Dragon', 'Monster', 'Normal', 'Dragon', '', 'Light', 8, 3000, 2500
		, '', '', 'Unlimited', 'This legendary dragon is a powerful engine of destruction. Virtually invincible, very few have faced this awesome creature and lived to tell the tale.'),
		('LOB-EN002', 'Hitotsu-Me Giant', 'Monster', 'Normal', 'Beast-Warrior', '', 'Earth', 4, 1200, 1000
		, '', '', 'Unlimited', 'A one-eyed behemoth with thick, powerful arms made for delivering punishing blows.'),
		('LOB-EN003', 'Flame Swordsman', 'Monster', 'Fusion', 'Warrior', '', 'Fire', 5, 1800, 1600
		, '', '', 'Unlimited', '"Flame Manipulator" + "Masaki the Legendary Swordsman".')
GO


/*********************************************************************
			
			
			CREATING Card related stored procedures
			
			
*********************************************************************/
print '' print '*** CREATING Card related stored procedures ***'
GO


/*********************************************************************
			CREATING sp_select_all_cards
*********************************************************************/
print '' print '*** creating sp_select_all_cards ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_cards]
AS
	BEGIN
		SELECT 	CardID, CardName, CardCategory, CardType, MonsterType, MonsterSubType, MonsterAttribute, LevelRank, Attack, Defense, PendulumScale, LinkNumber, BanlistPlacement, CardText
		FROM 	Card
		ORDER BY CardName ASC
	END
GO


/*********************************************************************
			CREATING sp_select_cards_by_banlist_placement
*********************************************************************/
print '' print '*** creating sp_select_cards_by_banlist_placement ***'
GO
CREATE PROCEDURE [dbo].[sp_select_cards_by_banlist_placement]
	(
		@BanlistPlacement	[nvarchar](12)
	)
AS
	BEGIN
		SELECT 	CardID, CardName, CardCategory, CardType, MonsterType, MonsterSubType, MonsterAttribute, LevelRank, Attack, Defense, PendulumScale, LinkNumber, BanlistPlacement, CardText
		FROM 	Card
		ORDER BY CardName ASC
	END
GO

/*********************************************************************
			CREATING sp_select_card_by_card_name
*********************************************************************/
print '' print '*** creating sp_select_card_by_card_name ***'
GO
CREATE PROCEDURE [dbo].[sp_select_card_by_card_name]
	(
		@CardName	[nvarchar](75)
	)
AS
	BEGIN
		SELECT 	CardID, CardName, CardCategory, CardType, MonsterType, MonsterSubType, MonsterAttribute, LevelRank, Attack, Defense, PendulumScale, LinkNumber, BanlistPlacement, CardText
		FROM 	Card
		WHERE CardName = @CardName
		ORDER BY CardName ASC
	END
GO



