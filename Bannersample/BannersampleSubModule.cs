using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannersample
{
  public class BannersampleSubModule : MBSubModuleBase
  {    
    public override void OnCampaignStart(Game game, object starterObject)
    {
      base.OnCampaignStart(game, starterObject);
      Bannersample.Log("BannersampleSubModule.OnCampaignStart");
    }

    public override void OnGameEnd(Game game)
    {
      base.OnGameEnd(game);
      Bannersample.Log("BannersampleSubModule.OnGameEnd");
    }
    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
      Bannersample.Log("BannersampleSubModule.OnSubModuleLoad");

      // Null checks a method from the Army of Poachers Quest to prevent a bug fixed in 1.0.1
      // Bannersample.Prefix(
      //   "TaleWorlds.CampaignSystem.SandBox.Issues.MerchantArmyOfPoachersIssueBehavior",
      //   "MerchantArmyOfPoachersIssueQuest",
      //   "OnFinalize",
      //   "Bannersample.BannersampleSubModule",
      //   "OnFinalize"
      // );

      // Silently catches an exception occurring on formation change in a campaign siege as of 1.0.2
      // Bannersample.Finalize(
      //   "TaleWorlds.MountAndBlade.DetachmentManager",
      //   "Team_OnFormationsChanged",
      //   "Bannersample.Bannersample",
      //   "Catch"
      // );
    }
    
    public static bool OnFinalize(Object __instance)
    {
      Type instType = AccessTools.TypeByName("TaleWorlds.CampaignSystem.SandBox.Issues.MerchantArmyOfPoachersIssueBehavior");
      Traverse t = Traverse.Create(__instance);
      MobileParty _poachersParty = t.Field("_poachersParty").GetValue<MobileParty>();
      if(_poachersParty == null){
        Bannersample.Log("_poachersParty NULL!");
        return false;
      }
      return true;
    }
  }
}
