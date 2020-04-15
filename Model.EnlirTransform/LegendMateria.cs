﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class LegendMateria : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public string LegendMateriaName { get; set; }
        public string JapaneseName { get; set; }
        public int Realm { get; set; }
        public string CharacterName { get; set; }
        public int CharacterId { get; set; } //filled in during merge phase
        public string ImagePath { get; set; }

        public string Effect { get; set; }
        public string MasteryBonus { get; set; }
        public string RelicName { get; set; }
        public int RelicId { get; set; }//filled in during merge phase
        public string Anima { get; set; }
        public string EnlirId { get; set; }
        public bool IsInGlobal { get; set; }
        public bool IsChecked { get; set; }
    }
}
