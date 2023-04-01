using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class SaveDataModel
    {
        public PlayerBalanceModel PlayerBalanceModel { get; }
        public List<BusinessModel> BusinessModels { get; private set; }

        public SaveDataModel(PlayerBalanceModel playerBalanceModel, List<BusinessModel> businessModels)
        {
            PlayerBalanceModel = playerBalanceModel;
            BusinessModels = businessModels;
        }
    }
}