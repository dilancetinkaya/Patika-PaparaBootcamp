using Owner.API.Model;
using System;
using System.Collections.Generic;

namespace Owner.API.Data
{
    public class OwnerData
    {
        public List<OwnerModel> GetAllOwner()
        {
            return new List<OwnerModel>
        {
            new OwnerModel
            {
                Id=1,
                Name="Dilan",
                Surname="Cetinkaya",
                Date=DateTime.Now,
                Description="description of owner 1",
                Type="typeA"

            },
             new OwnerModel
            {
                Id=2,
                Name="Robert",
                Surname="Joe",
                Date=DateTime.Now,
                Description="description of owner 2",
                Type="typeB"

            },
               new OwnerModel
            {
                Id=3,
                Name="James",
                Surname="Charlie",
                Date=DateTime.Now,
                Description="description of owner 3",
                Type="typeC"

            }
        };

        }
    }
}
