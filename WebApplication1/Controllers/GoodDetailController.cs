using Microsoft.AspNetCore.Mvc;
using System.IO;
using Repository.Model;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodDetailController : Controller
{
    [HttpGet("{goodId}")]
    public async Task<IActionResult> Get(string goodId)
    {
        string DescriptionPath = $"Assets/Content/Description/{goodId}.txt";
        string IntroducePath = $"./Assets/Content/Introduce/{goodId}.txt";
        string CharacterPath = $"./Assets/Content/Character/{goodId}.txt";
        string UsesPath = $"./Assets/Content/Uses/{goodId}.txt";
        string PlantPath = $"./Assets/Content/Plant/{goodId}.txt";

        GoodDetail goodDetail = new GoodDetail();

        if (System.IO.File.Exists(DescriptionPath))
        {
            goodDetail.Description = System.IO.File.ReadAllText(DescriptionPath);
        }
        else
        {
            //Logging
        }

        if (System.IO.File.Exists(IntroducePath))
        {
            goodDetail.Introduce = System.IO.File.ReadAllText(IntroducePath);
        }
        else
        {
            //Logging
        }

        if (System.IO.File.Exists(CharacterPath))
        {
            goodDetail.Character = System.IO.File.ReadAllText(CharacterPath);
        }
        else
        {
            //Logging
        }

        if (System.IO.File.Exists(UsesPath))
        {
            goodDetail.Uses = System.IO.File.ReadAllText(UsesPath);
        }
        else
        {
            //Logging
        }

        if (System.IO.File.Exists(PlantPath))
        {
            goodDetail.Plant = System.IO.File.ReadAllText(PlantPath);
        }
        else
        {
            //Logging
        }

        return Ok(goodDetail);
    }
}
