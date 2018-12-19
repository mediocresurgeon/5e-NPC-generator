namespace DungeonsAndDragons5e.AbilityChecks.Skills
{
    /// <summary>
    /// A character's set of skills.
    /// </summary>
    public interface ISkillsSection
    {
        /// <summary>
        /// A character's ability to
        /// free themself from grapples,
        /// balance, and
        /// tumble.
        /// </summary>
        ISkill Acrobatics { get; }

        /// <summary>
        /// A character's ability to
        /// calm a domesticate animal,
        /// keep a mount from getting spooked,
        /// intuit an animals intentions, and
        /// control your mount during a risky maneuver.
        /// </summary>
        ISkill AnimalHandling { get; }

        /// <summary>
        /// A character's ability to recall information about
        /// magic items,
        /// identify spells, and
        /// disarm magic traps.
        /// </summary>
        ISkill Arcana { get; }

        /// <summary>
        /// A character's ability to
        /// grapple others,
        /// jump,
        /// swim,
        /// shove creatures,
        /// navigate rough terrain without losing movement.
        /// </summary>
        ISkill Athletics { get; }

        /// <summary>
        /// A character's ability to
        /// lie,
        /// disguise emotions, and
        /// play dead.
        /// </summary>
        ISkill Deception { get; }

        /// <summary>
        /// A character's ability to
        /// recall lore about families, events, places, and history,
        /// tell when/where a certain item was made,
        /// notice a person's origins based on their looks or customs.
        /// </summary>
        ISkill History { get; }

        /// <summary>
        /// A character's ability to
        /// identify whether a person is being deceitful or evasive in answering,
        /// notice what a person plans by what they're doing,
        /// perceive if someone is being mentally dominated, and 
        /// get the meaning of underlying messages.
        /// </summary>
        ISkill Insight { get; }

        /// <summary>
        /// A character's ability to
        /// intimidate someone into doing what they want,
        /// torture someone, and
        /// taunt someone into violence.
        /// </summary>
        ISkill Intimidation { get; }

        /// <summary>
        /// A character's ability to
        /// see through illusions,
        /// locate someone in an urban environment,
        /// search for specific information in books/libraries, and
        /// searching someone or an area.
        /// </summary>
        ISkill Investigation { get; }

        /// <summary>
        /// A character's ability to
        /// stabilize someone,
        /// notice a disease,
        /// provide long-term treatment, and
        /// knowing the dosages and uses for natural healing items.
        /// </summary>
        ISkill Medicine { get; }

        /// <summary>
        /// A character's ability to
        /// recall lore about beasts, plants, terrain, vegetation, and weather,
        /// identifying dangerous/poisonous food, and
        /// knowing hat plants are needed to make certain compounds/potions.
        /// </summary>
        ISkill Nature { get; }

        /// <summary>
        /// A character's ability to
        /// spot/hear hidden threats,
        /// recognize someone who's far away,
        /// find minute details, and
        /// identify a noise's source.
        /// </summary>
        ISkill Perception { get; }

        /// <summary>
        /// A character's ability to
        /// dance,
        /// sing,
        /// tell stories, and
        /// deliver a good speech.
        /// </summary>
        ISkill Performance { get; }

        /// <summary>
        /// A character's ability to
        /// convince someone to do what you want,
        /// debate,
        /// know how to behave in a social setting, and
        /// flatter or seduce someone.
        /// </summary>
        ISkill Persuasion { get; }

        /// <summary>
        /// A character's ability to
        /// recall information about deities, temples, and rituals,
        /// perform a ritual to specification, and
        /// know what would be offensive to a certain faith.
        /// </summary>
        ISkill Religion { get; }

        /// <summary>
        /// A character's ability to
        /// steal from people wihtout being notices,
        /// juggle,
        /// catch a weapon in midair (such as from a disarmed person), and
        /// perform gestures or messages without being noticed.
        /// </summary>
        ISkill SleightOfHand { get; }

        /// <summary>
        /// A character's ability to
        /// hide,
        /// move without being heard,
        /// mingle in a crowd, and
        /// follow someone.
        /// </summary>
        ISkill Stealth { get; }

        /// <summary>
        /// A character's ability to
        /// track,
        /// forage for food,
        /// hunt wild game,
        /// protect yourself from weather/terrain hazards,
        /// know which way is north and avoid getting lost, and
        /// make a decent campsite in xtreme conditions.
        /// </summary>
        ISkill Survival { get; }
    }
}