

using System;
using System.Collections.Generic;

namespace PortalRandkowy.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        //podstawowe informacje 
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZodiacSign { get; set; } 
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country {get; set;}

        //zakladka info

        public string Growth { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string MartialStatus { get; set; }
        public string Education { get; set; }
        public string Profession { get; set; }
        public string Children { get; set; }
        public string Languages { get; set; }

        //zakladka omnie

        public string Motto { get; set; }
        public string Description { get; set; }
        public string Personality { get; set; }
        public string LookingFor { get; set; }

        // zakladka pasje i zainteresowania

        public string Interests {get; set;}
        public string FreeTime { get; set; }
        public string Sport { get; set; }
        public string Movies { get; set; }
        public string Music { get; set; } 

        // zakldaka preferencje

        public string ILike { get; set; }
        public string IDoNotLike { get; set; }
        public string MakesMeLaugh { get; set; }
        public string ItFeelsBestIn { get; set; }
        public string FriendsWouldDescribeMe { get; set; }
        
        //zdejciea

        public ICollection<Photo> Photos {get; set;}
        


    }

}