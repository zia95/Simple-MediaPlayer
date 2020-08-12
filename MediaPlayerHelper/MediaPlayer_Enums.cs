﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayerHelper
{
    public enum State
    {
        Undefined = 0,
        Stopped = 1,
        Paused = 2,
        Playing = 3,
        ScanForward = 4,
        ScanReverse = 5,
        Buffering = 6,
        Waiting = 7,
        MediaEnded = 8,
        Transitioning = 9,
        Ready = 10,
        Reconnecting = 11,
        Last = 12
    };
    public enum MediaType
    {
        None,
        Audio,
        Video,
        Unknown
    };
    public enum MediaTag
    {
        AcquisitionTime,
        AcquisitionTimeDay,
        AcquisitionTimeMonth,
        AcquisitionTimeYear,
        AcquisitionTimeYearMonth,
        AcquisitionTimeYearMonthDay,
        AlbumID,
        AlbumIDAlbumArtist,
        AudioFormat,
        Author,
        AverageLevel,
        Bitrate,
        BuyNow,
        BuyTickets,
        CanonicalFileType,
        ContentDistributorDuration,
        Copyright,
        CurrentBitrate,
        DefaultDate,
        Description,
        DisplayArtist,
        DRMIndividualizedVersion,
        DRMKeyID,
        Duration,
        FileSize,
        FileType,
        HMEAlbumTitle,
        Is_Protected,
        IsVBR,
        LinkedFileURL,
        MediaType,
        MoreInfo,
        PeakValue,
        ProviderLogoURL,
        ProviderURL,
        RecordingTime,
        RecordingTimeDay,
        RecordingTimeMonth,
        RecordingTimeYear,
        RecordingTimeYearMonth,
        RecordingTimeYearMonthDay,
        ReleaseDate,
        ReleaseDateDay,
        ReleaseDateMonth,
        ReleaseDateYear,
        ReleaseDateYearMonth,
        ReleaseDateYearMonthDay,
        RequestState,
        SourceURL,
        SyncState,
        SyncState2,
        Title,
        TrackingID,
        UserCustom1,
        UserCustom2,
        UserEffectiveRating,
        UserLastPlayedTime,
        UserPlayCount,
        UserPlaycountAfternoon,
        UserPlaycountEvening,
        UserPlaycountMorning,
        UserPlaycountNight,
        UserPlaycountWeekday,
        UserPlaycountWeekend,
        UserRating,
        UserServiceRating,
        WM_AlbumArtist,
        WM_AlbumTitle,
        WM_Category,
        WM_Composer,
        WM_Conductor,
        WM_ContentDistributor,
        WM_ContentGroupDescription,
        WM_EncodingTime,
        WM_Genre,
        WM_GenreID,
        WM_InitialKey,
        WM_Language,
        WM_Lyrics,
        WM_MCDI,
        WM_MediaClassPrimaryID,
        WM_MediaClassSecondaryID,
        WM_Mood,
        WM_ParentalRating,
        WM_PartOfSet,
        WM_Period,
        WM_ProtectionType,
        WM_Provider,
        WM_ProviderRating,
        WM_ProviderStyle,
        WM_Publisher,
        WM_SubscriptionContentID,
        WM_SubTitle,
        WM_TrackNumber,
        WM_UniqueFileIdentifier,
        WM_WMCollectionGroupID,
        WM_WMCollectionID,
        WM_WMContentID,
        WM_Writer,
        WM_Year
    };
}