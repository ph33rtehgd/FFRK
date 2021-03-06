﻿using System.Collections.Generic;

namespace FFRKApi.Dto.Api
{
    public class LimitBreak
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public int Realm { get; set; }

        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public string RelicName { get; set; }
        public int RelicId { get; set; } //filled in during merge phase

        public IEnumerable<Status> Statuses { get; set; } //filled in during merge phase
        public IEnumerable<Other> OtherEffects { get; set; } //filled in during merge phase

        public string ImagePath { get; set; }

        public string LimitBreakName { get; set; }
        public string JapaneseName { get; set; }

        public int AbilityType { get; set; }
        public int TargetType { get; set; }
        public int AutoTargetType { get; set; }
        public int DamageFormulaType { get; set; }
        public double Multiplier { get; set; }
        public IEnumerable<int> Elements { get; set; }
        public double CastTime { get; set; }
        public string Effects { get; set; }
        public bool IsCounterable { get; set; }
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }


        public int MinimumLBPoints { get; set; }
        public int LimitBreakTier { get; set; }
        public string LimitBreakBonus { get; set; }
        public string MasteryBonus { get; set; }



        public string EnlirId { get; set; }

    }
}
