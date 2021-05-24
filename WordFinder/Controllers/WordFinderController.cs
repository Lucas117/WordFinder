using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WordFinder.Models;
using WordFinder.Validation;

namespace WordFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordFinderController : ControllerBase
    {
        private readonly IWordFinderValidations wordFinderValidations;

        public WordFinderController(IWordFinderValidations wordFinderValidations)
        {
            this.wordFinderValidations = wordFinderValidations;
        }       

        [HttpGet("welcome")]
        public ActionResult<IEnumerable<WordFinderModel>> Get()
        {
            WordFinderModel wordFinderModel = new WordFinderModel();

            IEnumerable<string> matrix = new List<string>
            {   "AAAAAAAA",
                "AAFATAAH",
                "AAFAHAAH",
                "AAFAIAAH",
                "AAFALAAH",
                "BBFALAAH",
                "AAFTIAAH",
                "AAFDFAAH"
            };

            IEnumerable<string> wordStream = new List<string>{ "HILL", "HILL", "FALA", "TEST"};

            wordFinderModel.Matrix = matrix;
            wordFinderModel.Wordstream = wordStream;

            return Ok(new {
                Description = "Examples to test",
                wordFinderModel
            });
        }        

        [HttpPost]
        public ActionResult<IEnumerable<string>> PostV2(WordFinderModel wordFinderModel)
        {
            //There should be an exception wrapper to control differents status code for each kind of exception
            try
            {
                wordFinderValidations.ValidateMatrix(wordFinderModel.Matrix);
                return Ok(new WordFinder(wordFinderModel.Matrix).Find(wordFinderModel.Wordstream).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(409, ex.Message);
            }
        }

    }
}
