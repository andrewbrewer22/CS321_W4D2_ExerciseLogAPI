﻿using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityTypeMappingExtenstions
    {

        public static ActivityTypeModel ToApiModel(this ActivityType activityType)
        {
            return new ActivityTypeModel
            {
                Id = activityType.Id,
                // TODO: fill in property mappings
            };
        }

        public static ActivityType ToDomainModel(this ActivityTypeModel activityTypeModel)
        {
            return new ActivityType
            {
                Id = activityTypeModel.Id,
                // TODO: fill in property mappings
            };
        }

        public static IEnumerable<ActivityTypeModel> ToApiModels(this IEnumerable<ActivityType> activityTypes)
        {
            return activityTypes.Select(a => a.ToApiModel());
        }

        public static IEnumerable<ActivityType> ToDomainModels(this IEnumerable<ActivityTypeModel> activityTypeModels)
        {
            return activityTypeModels.Select(a => a.ToDomainModel());
        }
    }
}
