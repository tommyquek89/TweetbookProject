﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweetbook.Contracts.V1.Requests.Queries
{
    public class GetAllPostsQuery
    {
        [FromQuery(Name = "userId")]
        public string UserId { get; set; }
    }
}
