using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                // TODO: fill in property mappings

            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                // TODO: fill in property mappings
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> users)
        {
            return users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> userModels)
        {
            return userModels.Select(a => a.ToDomainModel());
        }
    }
}
