using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class SaveDataModel
    {
        public PlayerBalanceModel PlayerBalanceModel { get; }
        public IReadOnlyList<BusinessModel> BusinessModels;

        public SaveDataModel(PlayerBalanceModel playerBalanceModel, IReadOnlyList<BusinessModel> businessModels)
        {
            PlayerBalanceModel = playerBalanceModel;
            BusinessModels = businessModels;
        }
    }
}