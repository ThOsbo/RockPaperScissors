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
        public async Task<JsonResult> MakeMove(string lastMoveP1, string lastMoveP2, string difficulty, string playMode)
        {
            Common.Moves p1Move = Common.Moves.Rock;
            Common.Moves p2Move = Common.Moves.Rock;

            Common.PlayMode playModeEnumType = Common.Enum.GetEnum<Common.PlayMode>(playMode);

            switch (playModeEnumType)
            {
                case Common.PlayMode.PlayerVComputer:
                    p2Move = PlayGame.MakeMove(lastMoveP1, difficulty);
                    break;
                case Common.PlayMode.ComputerVComputer:
                    p1Move = PlayGame.MakeMove(lastMoveP2, difficulty);
                    p2Move = PlayGame.MakeMove(lastMoveP1, difficulty);
                    break;
                default:
                    break;
            }

            return Json(new { p1Move = p1Move.ToString(), p2Move = p2Move.ToString() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
