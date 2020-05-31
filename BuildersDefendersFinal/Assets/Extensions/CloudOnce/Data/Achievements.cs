// <copyright file="Achievements.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to achievements registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Achievements
    {
        private static readonly UnifiedAchievement s_begginer = new UnifiedAchievement("Begginer",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "1096833982008"
#else
            "Begginer"
#endif
            );

        public static UnifiedAchievement Begginer
        {
            get { return s_begginer; }
        }

        private static readonly UnifiedAchievement s_amateur = new UnifiedAchievement("Amateur",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkIuLyZg_YfEAIQAQ"
#else
            "Amateur"
#endif
            );

        public static UnifiedAchievement Amateur
        {
            get { return s_amateur; }
        }

        private static readonly UnifiedAchievement s_expert = new UnifiedAchievement("Expert",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkIuLyZg_YfEAIQAw"
#else
            "Expert"
#endif
            );

        public static UnifiedAchievement Expert
        {
            get { return s_expert; }
        }

        private static readonly UnifiedAchievement s_name = new UnifiedAchievement("Name",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkIuLyZg_YfEAIQBg"
#else
            "Name"
#endif
            );

        public static UnifiedAchievement Name
        {
            get { return s_name; }
        }

        public static readonly UnifiedAchievement[] All =
        {
            s_begginer,
            s_amateur,
            s_expert,
            s_name,
        };

        public static string GetPlatformID(string internalId)
        {
            return s_achievementDictionary.ContainsKey(internalId)
                ? s_achievementDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedAchievement> s_achievementDictionary = new Dictionary<string, UnifiedAchievement>
        {
            { "Begginer", s_begginer },
            { "Amateur", s_amateur },
            { "Expert", s_expert },
            { "Name", s_name },
        };
    }
}
