using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]


public class RovarspraketController : ControllerBase
{

// Endpoint för att kryptera//
    [HttpPost("encrypt")]
    public ActionResult<string> Encrypt([FromBody] string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return BadRequest("Texten får inte vara null eller tom.");
        }

        string encryptedText = EncryptRovarspraket(text);
        return Ok(encryptedText);
    }
// Enpoint för att avkryptera//
    [HttpPost("decrypt")]
    public ActionResult<string> Decrypt([FromBody] string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return BadRequest("Texten får inte vara null eller tom.");
        }

        string decryptedText = DecryptRovarspraket(text);
        return Ok(decryptedText);
    }

// Funktion för att kryptera enligt Rovarspraket//
    private string EncryptRovarspraket(string input)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
        char[] result = new char[input.Length * 3];
        int index = 0;

        foreach (char c in input)
        {
            result[index++] = c;

            if (IsVowel(c, vowels))
            {
                result[index++] = 'o';
                result[index++] = c;
            }
        }

        return new string(result, 0, index);
    }

// Tar emot sträng som input och returnerar avkrypterad//
    private string DecryptRovarspraket(string input)
    {
        char[] result = new char[input.Length];
        int index = 0;

        for (int i = 0; i < input.Length; i++)
        {
            result[index++] = input[i];

            if (IsVowel(input[i], vowels) && i + 2 < input.Length && input[i + 1] == 'o' && input[i + 2] == input[i])
            {
                i += 2;
            }
        }

        return new string(result, 0, index);
    }

// Funktion returnerar 'true' om tecknet är vokal, annars 'false'
    private bool IsVowel(char character, char[] vowels)
    {
        return Array.IndexOf(vowels, char.ToLower(character)) != -1;
    }
}
