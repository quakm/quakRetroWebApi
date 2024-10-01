using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Core.Entities;

public class UserSettingsEntity
{
    public int UserId { get; set; }
    public int AchievementScore { get; set; }
    public int DailyRespectPoints { get; set; }
    public int DailyPetRespectPoints { get; set; }
    public int RespectsGiven { get; set; }
    public int RespectsReceived { get; set; }
    public int GuildId { get; set; }
    public string CanChangeName { get; set; }
    public string CanTrade { get; set; }
    public string IsCitizen { get; set; }
    public int CitizenLevel { get; set; }
    public int HelperLevel { get; set; }
    public int TradelockAmount { get; set; }
    public int CfhSend { get; set; }
    public int CfhAbusive { get; set; }
    public int CfhWarnings { get; set; }
    public int CfhBans { get; set; }
    public string BlockFollowing { get; set; }
    public string BlockFriendRequests { get; set; }
    public string BlockRoomInvites { get; set; }
    public int VolumeSystem { get; set; }
    public int VolumeFurni { get; set; }
    public int VolumeTrax { get; set; }
    public string OldChat { get; set; }
    public string BlockCameraFollow { get; set; }
    public int ChatColor { get; set; }
    public int HomeRoom { get; set; }
    public int OnlineTime { get; set; }
    public string Tags { get; set; }
    public int ClubExpireTimestamp { get; set; }
    public int LoginStreak { get; set; }
    public int RentSpaceId { get; set; }
    public int RentSpaceEndtime { get; set; }
    public int HofPoints { get; set; }
    public string BlockAlerts { get; set; }
    public int TalentTrackCitizenshipLevel { get; set; }
    public int TalentTrackHelpersLevel { get; set; }
    public string IgnoreBots { get; set; }
    public string IgnorePets { get; set; }
    public string Nux { get; set; }
    public int MuteEndTimestamp { get; set; }
    public string AllowNameChange { get; set; }
    public string PerkTrade { get; set; }
    public int ForumsPostCount { get; set; }
    public int UiFlags { get; set; }
    public string HasGottenDefaultSavedSearches { get; set; }
    public int HcGiftsClaimed { get; set; }
    public int LastHcPayday { get; set; }
    public int MaxRooms { get; set; }
    public int MaxFriends { get; set; }
}
