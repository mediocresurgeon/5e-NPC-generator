using System;


namespace DnD5e.Creatures.Spellcasting
{
    /// <summary>
    /// A creature's spell slots.
    /// </summary>
    internal sealed class SpellSlots : ISpellSlots
    {
        #region Fields
        private Func<byte> _casterLevel;
        private byte? _level1;
        private byte? _level2;
        private byte? _level3;
        private byte? _level4;
        private byte? _level5;
        private byte? _level6;
        private byte? _level7;
        private byte? _level8;
        private byte? _level9;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DnD5e.Creatures.Spellcasting.SpellSlots"/> class.
        /// </summary>
        /// <param name="casterLevel">The creature's caster level.</param>
        /// <exception cref="System.ArgumentNullException" />
        public SpellSlots(Func<byte> casterLevel)
        {
            this.CasterLevel = casterLevel ?? throw new ArgumentNullException(nameof(casterLevel), "Argument may not be null.");
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the caster level.
        /// </summary>
        /// <exception cref="System.ArgumentNullException" />
        public Func<byte> CasterLevel
        {
            get => _casterLevel;
            set => _casterLevel = value ?? throw new ArgumentNullException(nameof(value), "Assignment may not be null.");
        }

        /// <summary>
        /// Gets or sets the number of level 1 spell slots.
        /// </summary>
        public byte Level1
        {
            get => _level1.HasValue ? _level1.Value : GetCountLevel1();
            set => _level1 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 2 spell slots.
        /// </summary>
        public byte Level2
        {
            get => _level2.HasValue ? _level2.Value : GetCountLevel2();
            set => _level2 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 3 spell slots.
        /// </summary>
        public byte Level3
        {
            get => _level3.HasValue ? _level3.Value : GetCountLevel3();
            set => _level3 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 4 spell slots.
        /// </summary>
        public byte Level4
        {
            get => _level4.HasValue ? _level4.Value : GetCountLevel4();
            set => _level4 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 5 spell slots.
        /// </summary>
        public byte Level5
        {
            get => _level5.HasValue ? _level5.Value : GetCountLevel5();
            set => _level5 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 6 spell slots.
        /// </summary>
        public byte Level6
        {
            get => _level6.HasValue ? _level6.Value : GetCountLevel6();
            set => _level6 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 7 spell slots.
        /// </summary>
        public byte Level7
        {
            get => _level7.HasValue ? _level7.Value : GetCountLevel7();
            set => _level7 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 8 spell slots.
        /// </summary>
        public byte Level8
        {
            get => _level8.HasValue ? _level8.Value : GetCountLevel8();
            set => _level8 = value;
        }

        /// <summary>
        /// Gets or sets the number of level 9 spell slots.
        /// </summary>
        public byte Level9
        {
            get => _level9.HasValue ? _level9.Value : GetCountLevel9();
            set => _level9 = value;
        }
        #endregion

        #region Methods
        private byte GetCountLevel1()
        {
            switch(this.CasterLevel())
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case byte lvl when (3 <= lvl):
                    return 4;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel2()
        {
            switch (this.CasterLevel())
            {
                case 3:
                    return 2;
                case byte lvl when (4 <= lvl):
                    return 3;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel3()
        {
            switch (this.CasterLevel())
            {
                case 5:
                    return 2;
                case byte lvl when (6 <= lvl):
                    return 3;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel4()
        {
            switch (this.CasterLevel())
            {
                case 7:
                    return 1;
                case 8:
                    return 2;
                case byte lvl when (9 <= lvl):
                    return 3;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel5()
        {
            switch (this.CasterLevel())
            {
                case 9:
                    return 1;
                case byte lvl when (10 <= lvl && lvl <= 17):
                    return 2;
                case byte lvl when (18 <= lvl):
                    return 3;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel6()
        {
            switch (this.CasterLevel())
            {
                case byte lvl when (11 <= lvl && lvl <= 18):
                    return 1;
                case byte lvl when (19 <= lvl):
                    return 2;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel7()
        {
            switch (this.CasterLevel())
            {
                case byte lvl when (13 <= lvl && lvl <= 19):
                    return 1;
                case byte lvl when (20 <= lvl):
                    return 2;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel8()
        {
            switch (this.CasterLevel())
            {
                case byte lvl when (15 <= lvl):
                    return 1;
                default:
                    return 0;
            }
        }


        private byte GetCountLevel9()
        {
            switch (this.CasterLevel())
            {
                case byte lvl when (17 <= lvl):
                    return 1;
                default:
                    return 0;
            }
        }
        #endregion
    }
}