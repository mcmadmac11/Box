using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LastBox.Models;

namespace LastBox.Data
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<RegisteredUserDbContext>
    {
        protected override void Seed(RegisteredUserDbContext context)
        {
            GetBoxes().ForEach(b => context.Boxes.Add(b));
        }

        private static List<Box> GetBoxes()
        {
            var Boxes = new List<Box> {
                new Box
                {
                    Name="Drunk Box",
                    Category="Alcohol",
                    Description="Only for Drunks",
                    Cost=25
                },

                new Box
                {
                    Name="Music Box",
                    Category="Music",
                    Description="For Music Lovers",
                    Cost=15
                }
            };
            return Boxes;
        }
    }
}