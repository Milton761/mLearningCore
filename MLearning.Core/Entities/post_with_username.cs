using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class post_with_username : Post
    {

        public post_with_username()
        { 
        
        }
        public post_with_username(Post other)
        {
            id = other.id;
            text  = other.text;
            user_id = other.user_id;
            circle_id = other.circle_id;
            created_at = other.created_at;
            updated_at = other.updated_at;
        }

        new public int id { get; set; }

        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public string image_url { get; set; }

   
    }
}
