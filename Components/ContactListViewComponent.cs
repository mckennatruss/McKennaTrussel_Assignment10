using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using McKennaTrussel_Assignment10.Models;

namespace McKennaTrussel_Assignment10.Components
{
    public class ContactListViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public ContactListViewComponent (BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedTeam = RouteData?.Values["TeamName"];


            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));



                //.Select(x => x.TeamName)
                //.Distinct()
                //.OrderBy(x => x)
                //.ToList());
        }
    }
}
