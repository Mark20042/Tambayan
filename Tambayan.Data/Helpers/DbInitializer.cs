using System;
using System.Collections.Generic;
using System.Text;
using Tambayan.Data.Models;

namespace Tambayan.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
            {
                var newUser = new User()
                {
                    FullName = "Mark Joseph Potot",
                    ProfilePictureUrl = "https://www.markjosephdev.me/_app/immutable/assets/me.B7g5EmB2.png"

                };

                await appDbContext.Users.AddAsync(newUser);
                await appDbContext.SaveChangesAsync();

                var newPostWithoutImage = new Post()
                {
                    Content = "Dati lang yun uy!",
                    Images = new List<PostImage>(),
                    NoReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    UserId = newUser.Id
                };



                var newPostWithImage = new Post()
                {
                    Content = "Eacakes ko pala",
                    Images = new List<PostImage>()
                    {
                        new PostImage()
                        {
                            ImageUrl = "https://xkxqjlzvieat874751.gcdn.ntruss.com/1/2026/11f0/111f00121597e16b04b50bbb367fcf6ff99028d0a74c70c87d4ebe9af0f4236ff_s_st.webp",
                            DateAdded = DateTime.UtcNow
                        }
                    },
                    NoReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    UserId = newUser.Id
                };

                await appDbContext.Posts.AddRangeAsync(newPostWithoutImage, newPostWithImage);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
