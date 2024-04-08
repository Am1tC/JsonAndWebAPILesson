using CalculatorWebAPI.DTO;
using CalculatorWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CalculatorWebAPI.Controllers
{
    [Route("apimonkeys")]
    [ApiController]
    public class MonketController : ControllerBase
    {
        [HttpGet("ReadAllMonkeys")]

        public IActionResult readAllMonkeys()
        {
            try
            {
                MonkeyList monkeyList = new MonkeyList();
                MonkeyListDto monkeysDto = new MonkeyListDto();
                for (int i = 0; i < monkeyList.Monkeys.Count; i++)
                {
                    MonkeyDto m = new MonkeyDto
                    {
                        Name = monkeyList.Monkeys[i].Name,
                        Location = monkeyList.Monkeys[i].Location,
                        Details = monkeyList.Monkeys[i].Details,
                        ImageUrl = monkeyList.Monkeys[i].ImageUrl,
                        IsFavorite = monkeyList.Monkeys[i].IsFavorite

                    };
                    monkeysDto.Monkeys.Add(m);

                }
                return Ok(monkeyList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("ReadMonkey")]
        public IActionResult ReadMonkey([FromQuery] string name)
        {
            try
            {
                MonkeyList monkeyList = new MonkeyList();
                MonkeyListDto monkeysDto = new MonkeyListDto();
                for (int i = 0; i < monkeyList.Monkeys.Count; i++)
                {
                    if (monkeyList.Monkeys[i].Name == name)
                    {
                        return Ok(monkeyList.Monkeys[i]);
                    }
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AddMonkey")]
        public IActionResult AddMonkey([FromBody] Monkey monkey) 
        {
            try
            {
                MonkeyList monkeyList = new MonkeyList();
                MonkeyListDto monkeysDto = new MonkeyListDto();
                for (int i = 0; i < monkeyList.Monkeys.Count; i++)
                {
                    if (monkeyList.Monkeys[i].Name == monkey.Name)
                    {
                        return BadRequest();
                    }
                }
                monkeysList.Monkeys.Add(monkey);
                return Ok();



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }



    }
}


