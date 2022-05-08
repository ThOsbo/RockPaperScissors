using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SymfosDevTest_RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SymfosDevTest_RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> MakeMove(string lastMoveP1, string lastMoveP2, int gamesPlayed, string difficulty, string playMode)
        {
            string p1Move = "";
            string p2Move = "";

            Common.PlayMode playModeEnumValue;

            if (Common.Enum.TryGetEnum(playMode, out playModeEnumValue))
            {
                switch (playModeEnumValue)
                {
                    case Common.PlayMode.PlayerVComputer:
                        p2Move = PlayGame.MakeMove(lastMoveP1, gamesPlayed, difficulty).ToString();
                        break;
                    case Common.PlayMode.ComputerVComputer:
                        p1Move = PlayGame.MakeMove(lastMoveP2, gamesPlayed, difficulty).ToString();
                        p2Move = PlayGame.MakeMove(lastMoveP1, gamesPlayed, difficulty).ToString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //returns a random move if an invalid play mode is passed
                p1Move = PlayGame.MakeRandomMove();
                p2Move = PlayGame.MakeRandomMove();
            }

            return Json(new { p1Move = p1Move, p2Move = p2Move });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
