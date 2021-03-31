using McKennaTrussel_Assignment10.Models;
using McKennaTrussel_Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace McKennaTrussel_Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;

        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 0)
        {
                        ///var blah = "%Mary%";
                        ///OR you could just pass in : (string BowlerFirstNameSearch) and then do
                        ///.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE BowlerFirstName LIKE {BowlerFirstNameSearch} ORDER BY BowlerId DESC")
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    .Where(t => t.TeamId == teamid || teamid  == null)
                    .OrderBy(t => t.BowlerLastName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no team has been selected, then get the full count
                    //otherwise, only count the number from the team id that has been selected
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                TeamName = teamname
        });
                

            //.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId LIKE {TeamId} OR {TeamId} IS NULL")
                        ///.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE BowlerFirstName LIKE {blah} ORDER BY BowlerId DESC")
                        //.FromSqlRaw("SELECT * FROM Bowlers WHERE BowlerFirstName LIKE \"%Mary%\" ORDER BY BowlerId DESC")
                        //.Where(x => x.BowlerFirstName.Contains("Mary"))
                        //.OrderBy(x => x.BowlerId)
                        //.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
